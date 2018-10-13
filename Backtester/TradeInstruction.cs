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

        public TradeInstruction(TradeDirection tradeDirection, int units)
        {
            TradeDirection = tradeDirection;
            Units = units;
        }

        public static TradeInstruction None = new TradeInstruction(tradeDirection:TradeDirection.None, units:0);
    }
}
