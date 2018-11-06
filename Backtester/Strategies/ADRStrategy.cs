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

        protected override TradeInstruction ProcessStrategy(MarketPrice marketPrice)
        {
            if (adrIndicator.Value > 0.03m)
            {
                return new TradeInstruction(TradeDirection.Buy, 1);
            }

            else
            {
                return TradeInstruction.None;
            }
        }
    }
}
