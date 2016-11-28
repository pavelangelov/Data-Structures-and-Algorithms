using System;

namespace Pattern
{
    class Startup
    {

        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var pattern = new PatternDrawer().GetFigure(input);

            Console.WriteLine(pattern);
        }
    }
}