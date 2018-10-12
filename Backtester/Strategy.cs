using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtester
{

    interface IStrategy
    {
        TradeDirection ProcessData(MarketPrice marketPrice);
    }

    class TestStrategy : IStrategy
    {
        public TradeDirection ProcessData(MarketPrice marketPrice)
        {
            if (marketPrice.Date == new DateTime(2018, 2, 1))
            {
                return TradeDirection.Buy;
            }
            else if (marketPrice.Date == new DateTime(2018, 3, 1))
            {
                return TradeDirection.Sell;
            }
            else
            {
                return TradeDirection.None;
            }
        }
    }
}
