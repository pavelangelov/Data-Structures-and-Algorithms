using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversePolishNotation
{
    class Program
    {
        static void Main(string[] args)
        {
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
