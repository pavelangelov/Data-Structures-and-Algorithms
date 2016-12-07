using System.Collections.Generic;

using NUnit.Framework;

namespace SortingHomework.Tests.SortingAlgorythmsTests
{
    [TestFixture]
    public class SelectionSorter
    {
        [Test]

        public void SortShould_SortThePassedCollectionOfIntegers()
        {
            // Arange
            var sorter = new SelectionSorter<int>();
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
            var sorter = new SelectionSorter<string>();
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
            var sorter = new SelectionSorter<string>();
            var collection = new List<string>(0);

            // Act
            sorter.Sort(collection);

            // Assert
            Assert.AreEqual("", string.Join(", ", collection));
        }
    }
}
