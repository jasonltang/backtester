using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtester.Indicators
{
    class MovingAverageIndicator : Indicator
    {
        private List<MarketPrice> _prices = new List<MarketPrice>();
        private int _numDays;

        public MovingAverageIndicator(int numDays)
        {
            _numDays = numDays;
        }

        public override void Calculate(MarketPrice marketPrice)
        {
            _prices.Add(marketPrice);
            if (_prices.Count > _numDays)
            {
                _prices.RemoveAt(0);
            }
            
            Value = _prices.Select(p => p.Price).Average();
        }
    }
}
