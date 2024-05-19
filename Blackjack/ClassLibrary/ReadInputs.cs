using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ReadMethods
    {
        /// <summary>
        /// Reads an integer from the console within a specified range.
        /// </summary>
        /// <param name="prompt">The prompt to display to the user.</param>
        /// <param name="min">The minimum acceptable value (inclusive).</param>
        /// <param name="max">The maximum acceptable value (inclusive).</param>
        /// <returns>The integer input by the user.</returns>
        public static int ReadInteger(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {

            while (true)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int userNumber) && userNumber >= min && userNumber <= max)
                {
                    return userNumber;
                }
                else
                {
                    Console.WriteLine($"Please enter a number between {min} and {max}.");
                }
            }
        }

        /// <summary>
        /// Presents a list of options to the user and reads their choice.
        /// </summary>
        /// <param name="prompt">The prompt to display to the user.</param>
        /// <param name="options">The list of options to display.</param>
        /// <param name="selection">The user's selected option (1-based index).</param>
        public static void ReadChoice(string prompt, string[] options, out int selection)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            Console.WriteLine();

            selection = ReadInteger(prompt, 1, options.Length);
        }



    } 

}