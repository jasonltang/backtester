using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backtester.Indicators;

namespace Backtester.Strategies
{
    class TemplateStrategy : Strategy
    {
        Indicator numDaysIndicator;
        Indicator adrIndicator;
        // Add more indicators here and add them to the constructor

        public TemplateStrategy(int shortMA, int longMA)
        {
            numDaysIndicator = new NumDaysIndicator();
            adrIndicator = new ADRIndicator(10);
            indicatorsToProcess.Add(numDaysIndicator);
            indicatorsToProcess.Add(adrIndicator);
        }
        protected override TradeInstruction ProcessStrategy(MarketPrice marketPrice)
        {
            // Strategy logic here - edit however you like
            if (numDaysIndicator.Value == 20)
            {
                return new TradeInstruction(TradeDirection.Buy, 1);
            }
            {
                return TradeInstruction.None;
            }
        }
    }
}
