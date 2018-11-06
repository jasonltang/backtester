using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtester
{
    public abstract class ExitCondition
    {
        public abstract bool ShouldExit(MarketPrice marketPrice);
    }

    public class TimeBasedExitCondition : ExitCondition
    {
        private int _numDaysElapsed = 0;
        private int _tradeDuration;

        public TimeBasedExitCondition(int tradeDuration)
        {
            _tradeDuration = tradeDuration;
        }

        public override bool ShouldExit(MarketPrice marketPrice)
        {
            _numDaysElapsed++;
            if (_numDaysElapsed >= _tradeDuration)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
