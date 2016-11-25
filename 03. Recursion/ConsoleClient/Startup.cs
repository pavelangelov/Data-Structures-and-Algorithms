using System.Collections.Generic;

using _01.NestedLoopsRecursiveSimulation;
using _02.CombinationsWithDuplicates;
using _04.Permutations;
using _05.VariationsGenerator;
using Framework.Models;

namespace ConsoleClient
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var logger = new ConsoleLogger();
            var reader = new ConsoleReader();

            // Task 1 -> Write a recursive program that simulates the execution of n nested loopsfrom 1 to n.
            var recLoops = new RecursiveSimulation(logger);
            recLoops.LoopsSimulation(3);

            // Task 2->Write a recursive program for generating and printing all the combinations with duplicatesof k elements from n-element set.

            // This not works
            var combinations = new CombinationGenerator(logger);
            combinations.Run(3, 2);

            // Task 4 -> Write a recursive program for generating and printing all permutations of the numbers 1, 2, ..., n for given integer number n

            var permutations = new Permutation(logger);
            permutations.PrintPermutations(3);

            // Task 5 -> Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations Vkn).
            var set = new string[] { "hi", "a", "b", "c" };
            var collection = new List<string>();
            var variations = new VariationGenerator().GetVariations(set, collection, 3, 2);

            logger.WriteLine(string.Join(", ", collection));
            
        }
    }
}
