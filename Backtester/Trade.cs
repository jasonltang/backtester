using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtester
{
    public class Trade
    {
        public DateTime Date { get; set; }
        public TradeDirection TradeDirection { get; set; }
        public int Units { get; set; }
        public decimal Price { get; set; }

        public Trade(DateTime date, TradeDirection tradeDirection, int units, decimal price)
        {
            Date = date;
            TradeDirection = tradeDirection;
            Units = units;
            Price = price;
        }
    }
}
