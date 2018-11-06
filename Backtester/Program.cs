// TODO: Calculate risk/reward ratio and compare against simulated random trades with same average magnitude, returning a p-value.
// More results, e.g. stdev of returns, p-value, etc.
// More complex simulations, e.g. multiple markets
// Create more strategies.
// Need proper entry/exit logic pairs.


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
