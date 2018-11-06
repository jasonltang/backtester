using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtester.Strategies
{
    class FixedDateStrategy : Strategy
    {
        protected override Bet ProcessStrategy(MarketPrice marketPrice)
        {
            if (marketPrice.Date == new DateTime(2018, 2, 1))
            {
                return new Bet(TradeDirection.Buy, 1, new TimeBasedExitCondition(5));
            }
            else if (marketPrice.Date == new DateTime(2018, 3, 1))
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
