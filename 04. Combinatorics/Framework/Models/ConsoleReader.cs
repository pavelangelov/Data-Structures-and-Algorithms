using System;

using Framework.Contracts;

namespace ConsoleClient.Models
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
