using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Common
{
    public static class StringHandler
    {
        /// <summary>
        /// Insert spaces before uppercase letters not followed by another uppercase letter.
        /// </summary>
        /// <param name="str">String to modify.</param>
        /// <returns>Modified string.</returns>
        public static string InsertSpaces(this string str)
        {
            for (int i = 1; i < str.Length; i++)
            {
                if (Char.IsUpper(str[i]) && !Char.IsUpper(str[i - 1]))
                {
                    str.Insert(i, " ");
                }
            }

            return str;
        }
    }
}
