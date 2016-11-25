using System;
using System.Linq;

using Framework.Contracts;

namespace _02.CombinationsWithDuplicates
{
    public class CombinationGenerator
    {
        private ILogger logger;

        public CombinationGenerator(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            this.logger = logger;
        }

        public void Run(int loopsCount, int combinationsCount)
        {
            var depth = Enumerable.Range(0, combinationsCount)
                                    .Select(x => 1)
                                    .ToArray();
            RecuriveLoopSimulation(depth, loopsCount, combinationsCount);
        }

        private void RecuriveLoopSimulation(int[] depth, int counter, int current)
        {
            for (int i = 0; i < counter; i++)
            {
                if (current <= 1)
                {
                    this.logger.WriteLine(string.Join(", ", depth));
                }
                else
                {
                    RecuriveLoopSimulation(depth, counter, current - 1);
                }

                depth[depth.Length - current]++;
            }

            depth[depth.Length - current] = current;
        }
    }
}
