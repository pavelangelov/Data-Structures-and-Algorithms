using Framework;
using Framework.Contracts;

namespace CLI
{
    public static class PriorityQueueTaskHelpers
    {
        public static void FillQueue(PriorityQueue<int> queue, int numberOfElements, ILogger logger)
        {
            for (int i = 1; i <= numberOfElements; i++)
            {
                logger.WriteLine($"Insert {i} in the Queue.");
                queue.Insert(i);
                logger.WriteLine($"Current Top: {queue.Peek()}");
            }
        }

        public static void EmptyTheQueue(PriorityQueue<int> queue, ILogger logger)
        {
            var length = queue.Size;
            for (int i = 0; i < length; i++)
            {
                logger.WriteLine($"Pull: {queue.Pull()}");
                logger.WriteLine($"Current Queue length: {queue.Size}");
            }
        }
    }
}
