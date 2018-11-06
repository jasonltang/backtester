using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backtester.Indicators;

namespace Backtester.Strategies
{
    class MovingAverageStrategy : Strategy
    {
        Indicator numDaysIndicator;
        Indicator adrIndicator;
        Indicator movingAverageIndicatorShort;
        Indicator movingAverageIndicatorLong;

        public MovingAverageStrategy(int shortMA, int longMA)
        {
            numDaysIndicator = new NumDaysIndicator();
            adrIndicator = new ADRIndicator(10);
            movingAverageIndicatorShort = new MovingAverageIndicator(shortMA);
            movingAverageIndicatorLong = new MovingAverageIndicator(longMA);
            indicatorsToProcess.Add(numDaysIndicator);
            indicatorsToProcess.Add(adrIndicator);
            indicatorsToProcess.Add(movingAverageIndicatorShort);
            indicatorsToProcess.Add(movingAverageIndicatorLong);
        }
        protected override TradeInstruction ProcessStrategy(MarketPrice marketPrice)
        {
            if (numDaysIndicator.Value < 10)
            {
                return TradeInstruction.None;
            }
            decimal movingAverageStrength = (movingAverageIndicatorShort.Value - movingAverageIndicatorLong.Value) / adrIndicator.Value;
            if (movingAverageStrength > 4m)
            {
                return new TradeInstruction(TradeDirection.Buy, 1);
            }
            else if (movingAverageStrength < -4m)
            {
                return new TradeInstruction(TradeDirection.Sell, 1);
            }
            else
            {
                return TradeInstruction.None;
            }
        }
    }
}
