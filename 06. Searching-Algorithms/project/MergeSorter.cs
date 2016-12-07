namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            MergeSort(collection);
        }

        private void MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return;
            }

            int middleIndex = collection.Count / 2;
            IList<T> left = collection.Take(middleIndex).ToList();
            IList<T> right = collection.Skip(middleIndex).ToList();

            MergeSort(left);
            MergeSort(right);

            Merge(collection, left, right);
        }

        private void Merge(IList<T> collection, IList<T> left, IList<T> right)
        {
            var leftIndex = 0;
            var rightIndex = 0;
            int collectionIndex = 0;
            for (; collectionIndex < collection.Count; collectionIndex++)
            {

                if (leftIndex >= left.Count || rightIndex >= right.Count)
                {
                    break;
                }

                if (left[leftIndex].CompareTo(right[rightIndex]) <= 0)
                {
                    collection[collectionIndex] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    collection[collectionIndex] = right[rightIndex];
                    rightIndex++;
                }
            }

            for (int i = leftIndex; i < left.Count; i++, collectionIndex++)
            {
                collection[collectionIndex] = left[leftIndex];
            }

            for (int i = rightIndex; i < right.Count; i++, collectionIndex++)
            {
                collection[collectionIndex] = right[i];
            }
        }
    }
}
