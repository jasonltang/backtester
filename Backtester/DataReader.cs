using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtester
{
    interface IDataReader
    {
        List<MarketPrice> GetData();
    }

    class TestDataReader : IDataReader
    {
        public List<MarketPrice> GetData()
        {
            var data = new List<MarketPrice>();
            for (int i = 1; i < 100; i++)
            {
                DateTime date = new DateTime(2018, 1, 1).AddDays(i);
                decimal price = 100 + (decimal)i / 10;
                data.Add(new MarketPrice() { Date = date, Price = price });
            }
            return data;
        }
    }
}
