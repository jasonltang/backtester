using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtester
{
    class TradeInstruction
    {
        public TradeDirection TradeDirection { get; set; }
        public int Units { get; set; }

        public static TradeInstruction None = new TradeInstruction()
        {
            TradeDirection = TradeDirection.None,
            Units = 0
        };
    }
}
