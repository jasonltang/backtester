using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backtester
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataReader dataReader = new TestDataReader();
            IStrategy strategy = new TestStrategy();
            ISimulator simulator = new ConcreteSimulator(dataReader, strategy);
            simulator.Simulate(printPnl:true);
        }
    }
}
