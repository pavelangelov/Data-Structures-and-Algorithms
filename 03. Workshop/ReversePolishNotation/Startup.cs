using System;
using System.Collections.Generic;

namespace ReversePolishNotation
{
    class Startup
    {
        static void Main()
        {
            /*                          Some test inputs and their results
             *      
             *  input: 7 8 +
             *  result: 15
             *  =====================================================================
             *  input: 3 4 5 * +
             *  result: 23
             *  =====================================================================
             *  input: 254 488 & 61 / 771 24 | * 394 3 428 | 141 171 & + | / 654 *
             *  result: 1308
             * */

            var input = Console.ReadLine().Split(' ');

            var numbers = new Stack<long>();

            for (int i = 0; i < input.Length; i++)
            {
                int number;
                if (int.TryParse(input[i], out number))
                {
                    numbers.Push(number);
                }
                else
                {
                    var sign = input[i];
                    var secondValue = numbers.Pop();
                    var firstValue = numbers.Pop();

                    var result = ProceedCalculation(sign, firstValue, secondValue);

                    numbers.Push(result);
                }
            }

            Console.WriteLine(numbers.Pop());
        }

        private static long ProceedCalculation(string operation, long firstValue, long secondValue)
        {
            long result;
            switch (operation)
            {
                case "+":
                    result = firstValue + secondValue;
                    break;
                case "-":
                    result = firstValue - secondValue;
                    break;
                case "*":
                    result = firstValue * secondValue;
                    break;
                case "/":
                    result = firstValue / secondValue;
                    break;
                case "&":
                    result = firstValue & secondValue;
                    break;
                case "|":
                    result = firstValue | secondValue;
                    break;
                case "^":
                    result = firstValue ^ secondValue;
                    break;
                default:
                    throw new ArgumentException("operator");
            }

            return result;
        }
    }
}
