using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtester
{
    interface ISimulator
    {
        void Simulate(bool printPnl);
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

        public void Simulate(bool printPnl = false)
        {
            List<MarketPrice> prices = _dataReader.GetData();
            _trades = GetTrades(prices);
            _pnl = GetPnL();
            if (printPnl)
            {
                Console.WriteLine(this._pnl);
            }
        }

        private List<Trade> GetTrades(List<MarketPrice> prices)
        {
            return new List<Trade>(); //TODO
        }

        private decimal GetPnL()
        {
            return 0; //TODO
        }
    }
}
