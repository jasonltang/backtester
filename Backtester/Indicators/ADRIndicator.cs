using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtester.Indicators
{
    class ADRIndicator : Indicator
    {
        private List<MarketPrice> _prices = new List<MarketPrice>();
        private int _numDays;


        public ADRIndicator(int numDays)
        {
            _numDays = numDays;
        }

        public override void Calculate(MarketPrice marketPrice)
        {
            _prices.Add(marketPrice);
            if (_prices.Count > _numDays + 1) // e.g. we need 11 days to calculate 10 daily changes
            {
                _prices.RemoveAt(0);
            }
            if (_prices.Count == 1)
            {
                Value = 0;
            }
            else
            {
                Value = GetDailyRangeValues().Average();
            }
        }

        private IEnumerable<decimal> GetDailyRangeValues()
        {
            for (int i = 1; i < _prices.Count; i++)
            {
                yield return Math.Abs(_prices[i].Price - _prices[i - 1].Price);
            }
        }
    }
}
