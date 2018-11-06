using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backtester.Strategies;


namespace Backtester
{
    interface ISimulator
    {
        bool Simulate(bool printTrades, bool printPnl);
    }

    class ConcreteSimulator : ISimulator
    {
        private IDataReader _dataReader;
        private Strategy _strategy;
        private List<Trade> _trades;
        private List<Bet> _bets;
        private decimal _pnl;
        public ConcreteSimulator(IDataReader dataReader, Strategy strategy)
        {
            this._dataReader = dataReader;
            this._strategy = strategy;
        }

        public bool Simulate(bool printTrades = false, bool printStats = true)
        {
            if (!_dataReader.GetData(out List<MarketPrice> prices))
            {
                return false;
            }
            ProcessDataToGenerateBets(prices);
            GetTradesFromBets();
            GeneratePnL(prices.Last());

            if (printTrades)
            {
                PrintTrades();
            }

            if (printStats)
            {
                PrintStats();
            }
            return true;
        }

        private void ProcessDataToGenerateBets(List<MarketPrice> prices)
        {
            _bets = new List<Bet>();
            foreach (MarketPrice marketPrice in prices)
            {
                ExitExpiredBets(marketPrice);
                AddBetIfExists(_strategy.ProcessData(marketPrice), marketPrice);
            }
        }

        private void ExitExpiredBets(MarketPrice currentPrice)
        {
            var openBets = _bets.Where(b => b.Status == BetStatus.Open);
            foreach (Bet bet in openBets)
            {
                if (bet.ShouldExit(currentPrice))
                {
                    var exitDirection = bet.TradeDirection == TradeDirection.Buy ? TradeDirection.Sell : TradeDirection.Buy;
                    bet.ExitTrade = new Trade(currentPrice.Date, exitDirection, bet.Units, currentPrice.Price);
                    bet.Status = BetStatus.Closed;
                }
            }
        }

        private void GetTradesFromBets()
        {
            _trades = new List<Trade>();
            foreach (Bet bet in _bets)
            {
                _trades.Add(bet.EntryTrade);
                if (bet.ExitTrade != null)
                {
                    _trades.Add(bet.ExitTrade);
                }
            }
            _trades = _trades.OrderBy(t => t.Date).ToList();
        }

        private void PrintTrades()
        {
            TextBoxWriter.WriteLine("List of trades (Date, direction, units, price):");
            foreach(Trade trade in _trades)
            {
                TextBoxWriter.WriteLine(
                    $"{trade.Date.ToString("d/M/yyyy")} ".PadRight(12) +
                    $"{trade.TradeDirection} ".PadRight(6) +
                    $"{trade.Units} ".PadRight(5) +
                    $"{trade.Price}");
            }
            TextBoxWriter.WriteLine();
            int totalBuys = _trades.Where(t => t.TradeDirection == TradeDirection.Buy).Sum(t => t.Units);
            int totalSells = _trades.Where(t => t.TradeDirection == TradeDirection.Sell).Sum(t => t.Units);
            TextBoxWriter.WriteLine($"Total bought quantity: {totalBuys}");
            TextBoxWriter.WriteLine($"Total sold quantity: {totalSells}");
            TextBoxWriter.WriteLine();
        }

        private void PrintStats()
        {
            TextBoxWriter.WriteMessage($"Total PnL: {this._pnl}");
            // TODO: Add more stuff here
        }

        private void AddBetIfExists(Bet bet, MarketPrice marketPrice)
        {
            if (bet != Bet.None)
            {
                bet.EntryTrade = new Trade(marketPrice.Date, bet.TradeDirection, bet.Units, marketPrice.Price);
                _bets.Add(bet);
            }
        }

        private void GeneratePnL(MarketPrice lastPrice)
        {
            int buys = 0, sells = 0;
            decimal runningPnl = 0;
            foreach (Trade trade in _trades)
            {
                switch (trade.TradeDirection)
                {
                    case TradeDirection.Buy:
                        runningPnl -= (trade.Price * trade.Units);
                        buys += trade.Units;
                        break;
                    case TradeDirection.Sell:
                        runningPnl += (trade.Price * trade.Units);
                        sells += trade.Units;
                        break;
                    default:
                        break;
                }
            }
            int remainingPosition = buys - sells;
            decimal unrealisedPnL = remainingPosition * lastPrice.Price;
            _pnl = runningPnl + unrealisedPnL;
        }
    }
}
