using System;

namespace Pattern
{
    class Startup
    {
        static void Main(string[] args)
        {
            /*                  Some sample test inputs
             *  input: 1
             *  result: urd
             *  ===========================================================================
             *  input: 2
             *  result: ruluurdrurddldr
             *  ===========================================================================
             *  input: 3
             *  result: urdrrulurulldluuruluurdrurddldrrruluurdrurddldrddlulldrdldrrurd
             */

            var input = int.Parse(Console.ReadLine());
            var pattern = new PatternDrawer().GetFigure(input);

            Console.WriteLine(pattern);
        }
    }
}