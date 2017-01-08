using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var wins = 0;
            for (int i = balls[0]; i <= balls[1]; i++)
            {
                if (Game(i, possibleTurns, true))
                {
                    wins++;
                }
            }

            Console.WriteLine(wins);
        }

        static bool Game(int numberOfBalls, int[] possibleTurns, bool isFirstPlayer)
        {
            if (numberOfBalls <= 0)
            {
                return false;
            }
            foreach (var turn in possibleTurns)
            {
                if (turn > numberOfBalls)
                {
                    continue;
                }
                if(!Game(numberOfBalls - turn, possibleTurns, !isFirstPlayer))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
