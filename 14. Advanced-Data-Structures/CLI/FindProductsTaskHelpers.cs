using Wintellect.PowerCollections;

using Framework;

namespace CLI
{
    public static class FindProductsTaskHelpers
    {
        public static OrderedBag<Product> GenerateBag(int numberOfProducts)
        {
            var bag = new OrderedBag<Product>();
            for (int i = 0; i < numberOfProducts; i++)
            {
                bag.Add(new Product($"Product #{i}", i + 0.2m));
            }

            return bag;
        }

        public static OrderedBag<Product>.View FindProductsInRange(OrderedBag<Product> bag, decimal startPrice, decimal endPrice)
        {
            var products = bag.Range(new Product("Product", Constants.ProductPriceFrom), true, new Product("Product", Constants.ProductPriceTo), true);

            return products;
        }
    }
}
