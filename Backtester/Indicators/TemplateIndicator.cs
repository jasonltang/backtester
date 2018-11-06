using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtester.Indicators
{
    class TemplateIndicator : Indicator
    {
        private List<MarketPrice> _prices = new List<MarketPrice>();
        private int _numDays;

        public TemplateIndicator(int numDays)
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
            Value = 0; // Some function of _prices
        }
    }
}
