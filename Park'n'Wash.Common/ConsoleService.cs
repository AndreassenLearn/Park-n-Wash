using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Common
{
    public static class ConsoleService
    {
        /// <summary>
        /// Print list of items to the console.
        /// </summary>
        /// <param name="printables">List of <see cref="IPrintable"/> to print.</param>
        public static void PrintToConsole(List<IPrintable> printables)
        {
            foreach (var printable in printables)
            {
                Console.WriteLine(printable.PrintableString());
            }
        }
    }
}
