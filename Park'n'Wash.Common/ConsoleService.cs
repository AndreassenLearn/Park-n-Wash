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
            foreach (IPrintable printable in printables)
            {
                Console.WriteLine(printable.PrintableString());
            }
        }
        
        /// <summary>
        /// Print list of numbered items to the console.
        /// </summary>
        /// <param name="printables">List of <see cref="IPrintable"/> to print.</param>
        public static void PrintToConsoleNumbered(List<IPrintable> printables)
        {
            int n = 0;
            foreach (IPrintable printable in printables)
            {
                n++;
                Console.WriteLine(n + ". " + printable.PrintableString());
            }
        }
        
        /// <summary>
        /// Print an item to the console.
        /// </summary>
        /// <param name="printable"><see cref="IPrintable"/> to print.</param>
        public static void PrintToConsole(this IPrintable printable)
        {
            Console.WriteLine(printable.PrintableString());
        }

        /// <summary>
        /// Clear console.
        /// </summary>
        public static void Clear()
        {
            //Console.Clear();
        }
    }
}
