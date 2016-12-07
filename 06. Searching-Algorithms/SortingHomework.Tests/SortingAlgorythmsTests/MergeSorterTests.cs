using System.Collections.Generic;

using NUnit.Framework;

namespace SortingHomework.Tests.SortingAlgorythmsTests
{
    [TestFixture]
    class MergeSorterTests
    {
        [Test]
        public void SortShould_SortThePassedCollectionOfIntegers()
        {
            // Arange
            var sorter = new MergeSorter<int>();
            var collection = new List<int>() { 2, 1, 4, 5, 6, 3 };
            var result = "1, 2, 3, 4, 5, 6";

            // Act
            sorter.Sort(collection);

            // Assert
            Assert.AreEqual(result, string.Join(", ", collection));
        }

        [Test]
        public void SortShould_SortThePassedCollectionOfStrings()
        {
            // Arange
            var sorter = new MergeSorter<string>();
            var collection = new List<string>() { "2", "1", "4", "5", "6", "3" };
            var result = "1, 2, 3, 4, 5, 6";

            // Act
            sorter.Sort(collection);

            // Assert
            Assert.AreEqual(result, string.Join(", ", collection));
        }

        [Test]
        public void SortShould_NotThrowIfTheCollectionIsEmpty_AndReturnEmptyCollection()
        {
            // Arange
            var sorter = new MergeSorter<string>();
            var collection = new List<string>(0);

            // Act
            sorter.Sort(collection);

            // Assert
            Assert.AreEqual("", string.Join(", ", collection));
        }
    }
}
