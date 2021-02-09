using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Common
{
    public static class LogHandler
    {
        /// <summary>
        /// Read all content from file.
        /// </summary>
        /// <param name="filePath">Path of file.</param>
        /// <param name="delimiter">Delimitor used in file.</param>
        /// <returns>List of string arrays, where each array is the fields in a line.</returns>
        public static async Task<List<string[]>> ReadLogAsync(string filePath, char delimiter)
        {
            List<string[]> content = new List<string[]>();
            await Task.Run(() =>
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        content.Add(reader.ReadLine().Split(delimiter));
                    }
                }
            });

            return content;
        }
    }
}
