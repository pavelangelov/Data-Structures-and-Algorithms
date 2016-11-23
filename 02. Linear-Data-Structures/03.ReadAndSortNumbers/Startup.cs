using System.Collections.Generic;
using System.Linq;

using Utils.Models;

namespace _03.ReadAndSortNumbers
{
    public class Startup
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var logger = new ConsoleLogger();

            var numbers = TaskHelper.GetNumbers(reader, logger).ToList();

            SortNumbers(numbers);

            logger.WriteLine(string.Join(", ", numbers));
        }

        private static void SortNumbers(IList<int> numbers)
        {
            int temp = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < numbers.Count - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        temp = numbers[j + 1];
                        numbers[j + 1] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }
        }
    }
}
