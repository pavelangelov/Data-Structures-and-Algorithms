using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddNumber
{
    class Startup
    {
        static void Main()
        {
            var numbers = new HashSet<long>();
            var n = long.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var number = long.Parse(Console.ReadLine());
                if (numbers.Contains(number))
                {
                    numbers.Remove(number);
                }
                else
                {
                    numbers.Add(number);
                }
            }

            Console.WriteLine(numbers.First());
        }
    }
}
