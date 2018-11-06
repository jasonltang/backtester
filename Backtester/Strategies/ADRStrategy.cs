using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backtester.Indicators;

namespace Backtester.Strategies
{
    class ADRStrategy : Strategy
    {
        Indicator adrIndicator;

        public ADRStrategy()
        {
            adrIndicator = new ADRIndicator(5);
            indicatorsToProcess.Add(adrIndicator);
        }

        protected override Bet ProcessStrategy(MarketPrice marketPrice)
        {
            if (adrIndicator.Value > 0.03m)
            {
                return new Bet(TradeDirection.Buy, 1, new TimeBasedExitCondition(5));
            }

            else
            {
                return Bet.None;
            }
        }
    }
}
