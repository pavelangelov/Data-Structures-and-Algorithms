using System.Collections.Generic;

using Utils.Contracts;
using Utils.Models;

namespace _02.ReverseNumbers
{
    public class Startup
    {
        public static void Main()
        {
            ILogger logger = new ConsoleLogger();
            IReader reader = new ConsoleReader();

            Stack<int> numbers = GetNumbers(reader, logger);

            PrintReversedNumbers(numbers, logger);
        }

        private static void PrintReversedNumbers(Stack<int> numbers, ILogger logger)
        {
            logger.Write("[ ");
            while (numbers.Count > 0)
            {
                if (numbers.Count == 1)
                {
                    logger.Write(numbers.Pop().ToString());
                    break;
                }
                logger.Write($"{numbers.Pop()}, ");
            }

            logger.Write(" ]");
            logger.WriteLine();
        }

        private static Stack<int> GetNumbers(IReader reader, ILogger logger)
        {
            var input = reader.ReadLine();
            var numbers = new Stack<int>();

            while (!string.IsNullOrEmpty(input))
            {
                int number;

                if (int.TryParse(input, out number))
                {
                    numbers.Push(number);
                }
                else
                {
                    logger.WriteLine($"The passed string '{input}' is not convertible to integer! Try again.");
                }

                input = reader.ReadLine();
            }

            return numbers;
        }
    }
}
