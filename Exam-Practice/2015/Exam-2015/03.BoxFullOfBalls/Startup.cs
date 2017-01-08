using System;
using System.Linq;

namespace _03.BoxFullOfBalls
{
    class Startup
    {
        static void Main(string[] args)
        {
            var possibleTurns = Console.ReadLine()
                                        .Split(' ')
                                        .Select(int.Parse)
                                        .ToArray();
            var balls = Console.ReadLine()
                                .Split(' ')
                                .Select(int.Parse)
                                .ToArray();
            
            var end = balls[1];
            var isWin = new bool[end + 1];

            for (int i = 1; i <= end; i++)
            {
                foreach (var move in possibleTurns)
                {
                    if (move > i)
                    {
                        continue;
                    }

                    if (!isWin[i - move])
                    {
                        isWin[i] = true;
                    }
                }
            }

            var wins = 0;
            for (int i = balls[0]; i <= balls[1]; i++)
            {
                if (isWin[i])
                {
                    wins++;
                }
            }

            Console.WriteLine(wins);
        }
    }
}
