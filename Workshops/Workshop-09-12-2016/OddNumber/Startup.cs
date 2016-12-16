using System;

namespace OddNumber
{
    class Startup
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            long result = 0;
            for (int i = 0; i < n; i++)
            {
                var currentNumber = long.Parse(Console.ReadLine());
                result ^= currentNumber;
            }

            Console.WriteLine(result);
        }
    }
}