using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Backtester
{
    interface ISimulator
    {
        void Simulate(bool printTrades, bool printPnl);
    }

    class ConcreteSimulator : ISimulator
    {
        private IDataReader _dataReader;
        private IStrategy _strategy;
        private List<Trade> _trades;
        private decimal _pnl;
        public ConcreteSimulator(IDataReader dataReader, IStrategy strategy)
        {
            this._dataReader = dataReader;
            this._strategy = strategy;
        }

        public void Simulate(bool printTrades = false, bool printPnl = false)
        {
            List<MarketPrice> prices = _dataReader.GetData();
            GenerateTrades(prices);
            GeneratePnL();

            if (printTrades)
            {
                PrintTrades();
            }

            if (printPnl)
            {
                PrintPnl();
            }
        }

        private void GenerateTrades(List<MarketPrice> prices)
        {
            _trades = new List<Trade>();
            foreach (MarketPrice marketPrice in prices)
            {
                AddTradeInstructionIfExists(_strategy.ProcessData(marketPrice), marketPrice);
            }
        }

        private void PrintTrades()
        {
            Console.WriteLine("List of trades (Date, direction, units, price):");
            foreach(Trade trade in _trades)
            {
                Console.WriteLine(
                    $"{trade.Date.ToString("d/M/yyyy")} ".PadRight(12) +
                    $"{trade.TradeDirection} ".PadRight(6) +
                    $"{trade.Units} ".PadRight(5) +
                    $"{trade.Price}");
            }
            Console.WriteLine();
        }

        private void PrintPnl()
        {
            Console.WriteLine($"Total PnL: {this._pnl}");
            Console.WriteLine();
        }

        private void AddTradeInstructionIfExists(TradeInstruction tradeInstruction, MarketPrice marketPrice)
        {
            if (tradeInstruction != TradeInstruction.None)
            {
                var trade = new Trade(
                    marketPrice.Date,
                    tradeInstruction.TradeDirection,
                    tradeInstruction.Units,
                    marketPrice.Price); //Can attach some slippage logic here later
                _trades.Add(trade);
            }
        }

        private void GeneratePnL()
        {
            decimal runningPnl = 0;
            foreach (Trade trade in _trades)
            {
                switch (trade.TradeDirection)
                {
                    case TradeDirection.Buy:
                        runningPnl -= (trade.Price * trade.Units);
                        break;
                    case TradeDirection.Sell:
                        runningPnl += (trade.Price * trade.Units);
                        break;
                    default:
                        break;
                }
            }
            _pnl = runningPnl;
        }
    }
}
