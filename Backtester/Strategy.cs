using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtester
{

    interface IStrategy
    {
        TradeInstruction ProcessData(MarketPrice marketPrice);
    }

    class TestStrategy : IStrategy
    {
        public TradeInstruction ProcessData(MarketPrice marketPrice)
        {
            if (marketPrice.Date == new DateTime(2018, 2, 1))
            {
                return new TradeInstruction(TradeDirection.Buy, 1);
            }
            else if (marketPrice.Date == new DateTime(2018, 3, 1))
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
