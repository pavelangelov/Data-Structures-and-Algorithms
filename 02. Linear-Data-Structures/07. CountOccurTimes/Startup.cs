using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Models;

namespace _07.CountOccurTimes
{
    public class Startup
    {
        public static void Main()
        {
            var logger = new ConsoleLogger();
            var occureKeys = new Dictionary<int, int>();
            var numbers = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

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

            foreach (var occure in occureKeys)
            {
                logger.WriteLine($"{occure.Key} -> {occure.Value} times");
            }
        }
    }
}
