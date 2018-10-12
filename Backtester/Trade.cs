using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtester
{
    class Trade
    {
        public DateTime date;
        public TradeDirection tradeDirection;
        public int units;
        public decimal price;

        public Trade(DateTime date, TradeDirection tradeDirection, int units, decimal price)
        {
            this.date = date;
            this.tradeDirection = tradeDirection;
            this.units = units;
            this.price = price;
        }
    }
}
