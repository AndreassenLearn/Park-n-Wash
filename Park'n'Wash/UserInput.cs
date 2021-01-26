using System;
using System.Collections.Generic;
using System.Text;

namespace Park_n_Wash
{
    class UserInteraction
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
