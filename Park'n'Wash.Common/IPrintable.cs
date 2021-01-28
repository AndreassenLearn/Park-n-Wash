using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Common
{
    public interface IPrintable
    {
        /// <summary>
        /// Generate a string representing the <see cref="IPrintable"/>.
        /// </summary>
        /// <returns>String intended to be written to text file or console.</returns>
        public string PrintableString();
    }
}
