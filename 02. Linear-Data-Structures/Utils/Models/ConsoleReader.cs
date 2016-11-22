using System;

using Utils.Contracts;

namespace Utils.Models
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            var input = Console.ReadLine();

            return input;
        }
    }
}
