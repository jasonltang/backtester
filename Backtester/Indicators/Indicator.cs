using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtester.Indicators
{
    public abstract class Indicator
    {
        public abstract void Calculate(MarketPrice marketPrice);
        public decimal Value { get; set; } = 0;
    }
}
