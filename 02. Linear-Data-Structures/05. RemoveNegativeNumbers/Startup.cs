using System.Linq;

using Utils.Models;

namespace _05.RemoveNegativeNumbers
{
    public class Startup
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var logger = new ConsoleLogger();

            var numbers = TaskHelper.GetNumbers(reader, logger)
                                    .Where(x => x >= 0)
                                    .ToList();

            logger.WriteLine(string.Join(", ", numbers));
        }
    }
}
