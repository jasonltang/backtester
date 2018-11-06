using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backtester.Indicators;

namespace Backtester.Strategies
{

    public abstract class Strategy
    {
        protected List<Indicator> indicatorsToProcess = new List<Indicator>();
        public TradeInstruction ProcessData(MarketPrice marketPrice)
        {
            ProcessIndicators(marketPrice);
            return ProcessStrategy(marketPrice);
        }
        private void ProcessIndicators(MarketPrice marketPrice)
        {
            foreach(Indicator indicator in indicatorsToProcess)
            {
                indicator.Calculate(marketPrice);
            }
        }
        protected abstract TradeInstruction ProcessStrategy(MarketPrice marketPrice);
    }
}
