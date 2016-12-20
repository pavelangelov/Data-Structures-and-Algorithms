using System.Diagnostics;

using Framework;
using Framework.Contracts;

namespace CLI
{
    class Startup
    {
        static void Main()
        {
            var logger = new ConsoleLogger();

            // Task 1. PriorityQueue<T>
            PriorityQueueTest(logger);

            // Task 2. Get products in price range using OrderedBag<T>
            FindProductsInRangeTest(logger);

        }

        private static void PriorityQueueTest(ILogger logger)
        {
            logger.WriteLine(Constants.PriorityQueueTaskMessage);
            var queue = new PriorityQueue<int>(2);

            PriorityQueueTaskHelpers.FillQueue(queue, 10, logger);

            PriorityQueueTaskHelpers.EmptyTheQueue(queue, logger);

            // Check if there is extra values :) This should throw.
            // logger.WriteLine(queue.Pull());

            PriorityQueueTaskHelpers.FillQueue(queue, 3, logger);
            PriorityQueueTaskHelpers.EmptyTheQueue(queue, logger);

            logger.WriteLine(Constants.Separator);
        }

        private static void FindProductsInRangeTest(ILogger logger)
        {
            var watch = new Stopwatch();
            logger.WriteLine(Constants.GetProductsInRangeMessage);

            watch.Start();
            var bag = FindProductsTaskHelpers.GenerateBag(Constants.NumberOfProducts);
            watch.Stop();
            logger.WriteLine($"Time for adding {Constants.NumberOfProducts} products -> {watch.Elapsed} seconds.");

            watch.Reset();
            watch.Start();
            var productsInRange = bag.Range(new Product("Product", Constants.ProductPriceFrom), true, new Product("Product", Constants.ProductPriceTo), true);
            watch.Stop();
            logger.WriteLine($"Time for getting {productsInRange.Count} products in price range [{Constants.ProductPriceFrom}, {Constants.ProductPriceTo}] -> {watch.Elapsed} seconds.");

            logger.WriteLine(Constants.Separator);
        }
    }
}
