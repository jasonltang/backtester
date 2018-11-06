using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtester.Indicators
{
    class NumDaysIndicator : Indicator
    {
        public override void Calculate(MarketPrice marketPrice)
        {
            Value++;
        }
    }
}
