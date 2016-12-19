using System;

using Framework;

namespace CLI
{
    class Startup
    {
        static void Main()
        {
            var queue = new PriorityQueue<int>(2);

            FillQueue(queue, 10);

            EmptyTheQueue(queue);

            // Check if there is extra values :)
            Console.WriteLine($"Remove: {queue.Pull()}");
            Console.WriteLine($"Current Top: {queue.Peek()}");

            // Check if it`s strill working
            FillQueue(queue, 3);
            EmptyTheQueue(queue);
        }

        private static void FillQueue(PriorityQueue<int> queue, int numberOfElements)
        {
            for (int i = 1; i <= numberOfElements; i++)
            {
                Console.WriteLine($"Insert {i} in the Queue.");
                queue.Insert(i);
                Console.WriteLine($"Current Top: {queue.Peek()}");
            }
        }

        private static void EmptyTheQueue(PriorityQueue<int> queue)
        {
            var length = queue.Size;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Remove: {queue.Pull()}");
                Console.WriteLine($"Current Top: {queue.Peek()}");
            }
        }
    }
}
