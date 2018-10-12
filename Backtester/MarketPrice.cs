using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtester
{
    class MarketPrice
    {
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public MarketPrice(DateTime date, decimal price)
        {
            Date = date;
            Price = price;
        }
    }
}
