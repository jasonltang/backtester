using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtester
{
    public enum TradeDirection
    {
        Buy = 1,
        Sell = 2,
        None = 3
    }

    public enum BetStatus
    {
        Open = 1,
        Closed = 0
    }
}
