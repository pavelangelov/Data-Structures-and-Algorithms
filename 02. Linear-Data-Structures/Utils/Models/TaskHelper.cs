using System.Collections.Generic;

using Utils.Contracts;

namespace Utils.Models
{
    public static class TaskHelper
    {
        public static ICollection<int> GetNumbers(IReader reader, ILogger logger)
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

        public static Stack<int> GetStackWithNumbers(IReader reader, ILogger logger)
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
