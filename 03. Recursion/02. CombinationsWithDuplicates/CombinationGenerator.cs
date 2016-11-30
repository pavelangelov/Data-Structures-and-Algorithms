using System;
using System.Linq;

using Framework.Contracts;

namespace _02.CombinationsWithDuplicates
{
    public class CombinationGenerator
    {
        private ILogger logger;
        private int n;
        private int k;

        public CombinationGenerator(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            this.logger = logger;
        }

        public void Run(int n, int k)
        {
            var depth = Enumerable.Range(0, k)
                                    .Select(x => 1)
                                    .ToArray();
            this.n = n;
            this.k = k;

            RecuriveLoopSimulation(depth, 0, 0);
        }

        private void RecuriveLoopSimulation(int[] depth, int currentIndex, int start)
        {
            if (currentIndex >= k)
            {
                this.logger.WriteLine(string.Join(", ", depth));
            }
            else
            {
                for (int i = start; i < n; i++)
                {
                    depth[currentIndex] = i + 1;
                    RecuriveLoopSimulation(depth, currentIndex + 1, i);
                }
            }
        }
    }
}
