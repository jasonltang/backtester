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
        public Bet ProcessData(MarketPrice marketPrice)
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
        protected abstract Bet ProcessStrategy(MarketPrice marketPrice);
    }
}
