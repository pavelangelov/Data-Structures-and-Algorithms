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

            var numbers = TaskHelper.GetNumbers(reader, logger);

            PrintSumAndAverage(numbers, logger);
        }

        private static void PrintSumAndAverage(ICollection<int> numbers, ILogger logger)
        {
            var sum = numbers.Sum();
            double average = sum / (double)numbers.Count;

            logger.WriteLine($"The sum of all numbers is: {sum}");
            logger.WriteLine($"The average value is: {average}");
        }
    }
}
