using System.Collections.Generic;
using System.Linq;

using Utils.Contracts;
using Utils.Models;

namespace _01.CalculateSumAndAverage
{
    public class Startup
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            ILogger logger = new ConsoleLogger();

            ICollection<int> numbers = GetNumbers(reader, logger);

            PrintSumAndAverage(numbers, logger);
        }

        private static void PrintSumAndAverage(ICollection<int> numbers, ILogger logger)
        {
            var sum = numbers.Sum();
            double average = sum / (double)numbers.Count;

            logger.WriteLine($"The sum of all numbers is: {sum}");
            logger.WriteLine($"The average value is: {average}");
        }

        private static ICollection<int> GetNumbers(IReader reader, ILogger logger)
        {
            var input = reader.ReadLine();
            var numbers = new List<int>();

            while (!string.IsNullOrEmpty(input))
            {
                int number;

                if (int.TryParse(input, out number))
                {
                    numbers.Add(number);
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
