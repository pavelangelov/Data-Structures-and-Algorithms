using _01.SumOfSubsequence;
using _02.Binomial_theorem;
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

            // ============================================================================
            // Task 1. Sum of subsequences.
            var pr = new SubSequence(logger);
            pr.Calculate(reader);

            /* 
             * Test 1.
                4 2	
                numbers => 1 2 3 4
                result = 30

                Test 2.
                5 3
                numbers => 1 –5 7 10 –3
                result 40
            */

            // ============================================================================
            // Task 2. (firstNumber + secondNumber) ^ n
            var binominal = new Binominal();
            binominal.Start(reader, logger);

            /*
             * Test 1.
                (a+z)
                1	
                result => (a^1)+(z^1)
                
                Test 2.
                (c+y)
                3	
                result => (c^3)+3(c^2)(y^1)+3(c^1)(y^2)+(y^3)

             */
        }
    }
}
