// TODO: 
// Price-based exit condition.
// Calculate risk/reward ratio and compare against simulated random trades with same average magnitude, returning a p-value.
// More results, e.g. stdev of returns, p-value, etc.
// Need ability to load multiple csv files.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backtester
{
    class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
