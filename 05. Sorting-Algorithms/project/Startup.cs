namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Startup
    {
        internal static void Main(string[] args)
        {
            var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            Console.WriteLine("All items before sorting:");
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            Console.WriteLine("SelectionSorter result:");
            collection.Sort(new SelectionSorter<int>());
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            Console.WriteLine("Quicksorter result:");
            collection.Sort(new Quicksorter<int>());
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            Console.WriteLine("MergeSorter result:");
            collection.Sort(new MergeSorter<int>());
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            Console.WriteLine("Linear search 101:");
            Console.WriteLine(collection.LinearSearch(101));
            Console.WriteLine();

            Console.WriteLine("Binary search 101:");
            Console.WriteLine(collection.BinarySearch(101));
            Console.WriteLine();

            Console.WriteLine("Shuffle:");
            collection.Shuffle();
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            Console.WriteLine("Shuffle again:");
            collection.Shuffle();
            collection.PrintAllItemsOnConsole();
        }

        private static void CalculateProceedingTime(int numberOfElementsInCollection, ISorter<int> sorter)
        {
            var numbers = GenerateCollection(numberOfElementsInCollection);
            var collection = new SortableCollection<int>(numbers);
            collection.Shuffle();
            Stopwatch st = new Stopwatch();
            st.Start();
            collection.Sort(sorter);
            st.Stop();

            Console.WriteLine($"Ellapsed time for sorting {numberOfElementsInCollection} integers: {st.Elapsed}");

        }

        internal static int[] GenerateCollection(int maxValue)
        {
            int[] numbers = new int[maxValue + 1];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }

            return numbers;
        }
    }
}
