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

            var numbers = TaskHelper.GetStackWithNumbers(reader, logger);

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
    }
}
