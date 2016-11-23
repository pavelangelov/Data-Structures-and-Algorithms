using System.Collections.Generic;

using Utils.Models;

namespace _06.RemoveNumberIfOccureOddNumberOfTimes
{
    public class Startup
    {
        public static void Main()
        {
            var logger = new ConsoleLogger();
            var occureKeys = new Dictionary<int, int>();
            var numbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            foreach (var number in numbers)
            {
                if (occureKeys.ContainsKey(number))
                {
                    occureKeys[number]++;
                }
                else
                {
                    occureKeys.Add(number, 1);
                }
            }

            foreach (var number in numbers)
            {
                if (occureKeys[number] % 2 == 0)
                {
                    logger.Write(number + " ");
                }
            }

            logger.WriteLine();
        }
    }
}
