using System;
using System.Linq;

using Framework.Contracts;

namespace _01.NestedLoopsRecursiveSimulation
{
    public class RecursiveSimulation
    {
        private ILogger logger;

        public RecursiveSimulation(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            this.logger = logger;
        }

        public void LoopsSimulation(int level)
        {
            var depth = Enumerable.Range(0, level)
                                    .Select(x => 1)
                                    .ToArray();
            RecuriveLoopSimulation(depth, level, level);
        }

        private void RecuriveLoopSimulation(int[] depth, int counter, int level)
        {
            for (int i = 0; i < counter; i++)
            {
                if (level <= 1)
                {
                    this.logger.WriteLine(string.Join(", ", depth));
                }
                else
                {
                    RecuriveLoopSimulation(depth, counter, level - 1);
                }

                depth[counter - level]++;
            }

            depth[counter - level] = 1;
        }
    }
}
