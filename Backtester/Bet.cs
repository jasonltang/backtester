using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtester
{
    public class Bet
    {
        public Trade EntryTrade;
        public Trade ExitTrade;
        public BetStatus Status;

        public TradeDirection TradeDirection;
        public int Units;
        public ExitCondition ExitCondition;

        public Bet(TradeDirection tradeDirection, int units, ExitCondition exitCondition)
        {
            this.TradeDirection = tradeDirection;
            this.Units = units;
            this.ExitCondition = exitCondition;
            Status = BetStatus.Open;
        }

        public bool ShouldExit(MarketPrice marketPrice)
        {
            return ExitCondition.ShouldExit(marketPrice);
        }

        public static Bet None = new Bet(TradeDirection.None, 0, null);
    }
}
