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
        protected override Bet ProcessStrategy(MarketPrice marketPrice)
        {
            if (numDaysIndicator.Value < 10)
            {
                return Bet.None;
            }
            decimal movingAverageStrength = (movingAverageIndicatorShort.Value - movingAverageIndicatorLong.Value) / adrIndicator.Value;
            if (movingAverageStrength > 4m)
            {
                return new Bet(TradeDirection.Buy, 1, new TimeBasedExitCondition(5));
            }
            else if (movingAverageStrength < -4m)
            {
                return new Bet(TradeDirection.Sell, 1, new TimeBasedExitCondition(5));
            }
            else
            {
                return Bet.None;
            }
        }
    }
}
