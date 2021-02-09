using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park_n_Wash.Common
{
    public class UserInteraction
    {
        /// <summary>
        /// Get int value from user, in given interval. Retry until a valid value has been entered.
        /// </summary>
        /// <param name="min">Minimum return value.</param>
        /// <param name="max">Maximum return value.</param>
        /// <returns>User input as int.</returns>
        static public int GetInt(int min = Int32.MinValue, int max = Int32.MaxValue)
        {
            int input;
            do
            {
                if (Int32.TryParse(Console.ReadLine(), out input) && (input >= min && input <= max))
                    break;
                else
                    InvalidValue();
            } while (true);

            return input;
        }

        /// <summary>
        /// Get int value from user, in given interval. Retry until a valid value has been entered. Also prints title and field.
        /// </summary>
        /// <param name="title">Title text.</param>
        /// <param name="field">Field text suffixed with ": ".</param>
        /// <param name="min">Minimum return value.</param>
        /// <param name="max">Maximum return value.</param>
        /// <returns>User input as int.</returns>
        static public int GetInt(string title, string field, int min = Int32.MinValue, int max = Int32.MaxValue)
        {
            Title(title);
            Console.Write($"{field}: ");
            return GetInt(min, max);
        }

        /// <summary>
        /// Get char value from user. Retry until a valid value has been entered.
        /// </summary>
        /// <param name="validChars">User input has to be one of these chars. If null; all chars is valid.</param>
        /// <returns>User input as char.</returns>
        static public char GetChar(List<char> validChars = null)
        {
            char input;
            do
            {
                if (Char.TryParse(Console.ReadLine(), out input) && validChars == null || validChars.Contains(input))
                    break;
                else
                    InvalidValue();
            } while (true);

            return input;
        }

        /// <summary>
        /// Let user choose between multiple numbered options.
        /// </summary>
        /// <param name="options">List of options to choose from.</param>
        /// <param name="title">Title displayed above options.</param>
        /// <returns>List index of chosen option; -1 if 'options' is null or empty.</returns>
        static public int SelectOption(List<string> options, string title = "Choose one")
        {
            if (options == null || options.Count == 0)
                return -1;

            Title(title);
            for (int i = 1; i <= options.Count; i++)
            {
                Console.WriteLine(i + ". " + options[i - 1]);
            }

            return GetInt(1, options.Count) - 1;
        }

        /// <summary>
        /// Let user choose between multiple numbered options.
        /// </summary>
        /// <param name="options">List of options to choose from.</param>
        /// <param name="title">Title displayed above options.</param>
        /// <returns>Option chosen by index.</returns>
        static public IPrintable SelectOption(List<IPrintable> options, string title = "Choose one")
        {
            Title(title);
            for (int i = 1; i <= options.Count; i++)
            {
                Console.WriteLine(i + ". " + options[i - 1].PrintableString());
            }

            return options[GetInt(1, options.Count) - 1];
        }

        /// <summary>
        /// Let user answer with yes or no.
        /// </summary>
        /// <param name="question">Question to ask user.</param>
        /// <returns>True if user enters 'Y' or 'y' and false if 'N' or 'n'.</returns>
        static public bool YesNo(string question)
        {
            Console.Write($"{question}? (Y/N): ");
            List<char> positive = new List<char>() { 'Y', 'y' };
            List<char> valid = new List<char>() { 'N', 'n' };
            valid.AddRange(positive);
            if (positive.Contains(GetChar(valid))) return true;

            return false;
        }

        /// <summary>
        /// Print title to the console.
        /// </summary>
        /// <param name="title">Title text.</param>
        static private void Title(string title)
        {
            Console.WriteLine("##### " + title + " #####");
        }

        /// <summary>
        /// Print a message to the console.
        /// </summary>
        static public void NoFreeSpots()
        {
            Console.WriteLine("Sorry, but there's no more free spots of the desired type.");
        }

        /// <summary>
        /// Print a message to the console.
        /// </summary>
        static private void InvalidValue()
        {
            Console.Write("Invalid input, try again: ");
        }
    }
}
