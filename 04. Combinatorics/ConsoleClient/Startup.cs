using _01.SumOfSubsequence;
using ConsoleClient.Models;
using Framework.Models;

namespace ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            var logger = new ConsoleLogger();
            var reader = new ConsoleReader();
            /* 
                4 2	
                numbers => 1 2 3 4
                result = 30

                5 3
                numbers => 1 –5 7 10 –3
                result 40
            */
            var pr = new SubSequence(logger);
            pr.Calculate(reader);
        }
    }
}
