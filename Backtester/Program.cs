//TODO: Convert from console application to a windows form application

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

            IDataReader dataReader = new CsvDataReader();
            IStrategy strategy = new TestStrategy();
            ISimulator simulator = new ConcreteSimulator(dataReader, strategy);
            simulator.Simulate(printTrades:true, printPnl:true);
        }
    }
}
