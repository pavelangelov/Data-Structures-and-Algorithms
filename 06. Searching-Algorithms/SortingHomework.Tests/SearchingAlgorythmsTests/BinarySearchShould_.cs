using System.Collections.Generic;

using NUnit.Framework;

namespace SortingHomework.Tests.SearchingAlgorythmsTests
{
    [TestFixture]
    public class BinarySearchShould_
    {
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(10)]
        public void ReturnTrue_IfSearchedNumberExistInCollection(int searchedNumber)
        {
            // Arange
            var sortableCollection = new SortableCollection<int>(new int[] { 1, 2, 3, 4, 10 });

            // Act
            var isFount = sortableCollection.BinarySearch(searchedNumber);

            // Assert
            Assert.IsTrue(isFount);
        }

        [Test]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(0)]
        [TestCase(11)]
        public void ReturnFalse_IfSearchedNumberNotExistInCollection(int searchedNumber)
        {
            // Arange
            var sortableCollection = new SortableCollection<int>(new int[] { 1, 2, 3, 4, 10 });

            // Act
            var isFount = sortableCollection.BinarySearch(searchedNumber);

            // Assert
            Assert.IsFalse(isFount);
        }

        [Test]
        [TestCase("1")]
        [TestCase("2")]
        public void ReturnTrue_IfSearchedStringExistInCollection(string searchedString)
        {
            // Arange
            var sortableCollection = new SortableCollection<string>(new string[] { "1", "2", "3", "4", "10" });

            // Act
            var isFount = sortableCollection.BinarySearch(searchedString);

            // Assert
            Assert.IsTrue(isFount);
        }

        [Test]
        [TestCase("5")]
        [TestCase("6")]
        public void ReturnFalse_IfSearchedStringNotExistInCollection(string searchedString)
        {
            // Arange
            var sortableCollection = new SortableCollection<string>(new string[] { "1", "2", "3", "4", "10" });

            // Act
            var isFount = sortableCollection.BinarySearch(searchedString);

            // Assert
            Assert.IsFalse(isFount);
        }

        [Test]
        public void ReturnFalse_IfPassedCollectionIsEmpty()
        {
            // Arange
            var sortableCollection = new SortableCollection<int>(new int[0]);

            // Act
            var isFount = sortableCollection.BinarySearch(2);

            // Assert
            Assert.IsFalse(isFount);
        }
    }
}
