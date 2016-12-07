namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            
                QuickSort(collection, 0, collection.Count - 1);
        }

        public void SortUsingMoreMemmory(IList<T> collection)
        {
            var result = QuickSort(collection);
            for (int i = 0; i < collection.Count; i++)
            {
                collection[i] = result[i];
            }
        }

        private void QuickSort(IList<T> collection, int left, int right)
        {
            if (left < right)
            {
                var pivotIndex = this.Partion(collection, left, right);
                QuickSort(collection, left, pivotIndex);
                QuickSort(collection, pivotIndex + 1, right);
            }
        }

        private int Partion(IList<T> collection, int left, int right)
        {
            T pivot = collection[left];
            int i = left - 1;
            int j = right + 1;
            while (true)
            {
                do
                {
                    i++;
                } while (pivot.CompareTo(collection[i]) > 0);

                do
                {
                    j--;
                } while (pivot.CompareTo(collection[j]) < 0);

                if (i >= j)
                {
                    return j;
                }

                this.Swap(collection, i, j);
            }
        }

        private IList<T> QuickSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }
            var result = new List<T>();

            int middleIndex = collection.Count / 2;
            IList<T> left = new List<T>();
            IList<T> right = new List<T>();

            T firstElement = collection[0];
            T middleElement = collection[middleIndex];
            T lastElement = collection[collection.Count - 1];

            T pivot = GetAverageValue(firstElement, middleElement, lastElement);

            for (int i = 0; i < middleIndex; i++)
            {
                if (pivot.CompareTo(collection[i]) > 0)
                {
                    left.Add(collection[i]);
                }
                else
                {
                    right.Add(collection[i]);
                }
            }

            for (int i = middleIndex + 1; i < collection.Count; i++)
            {
                if (pivot.CompareTo(collection[i]) >= 0)
                {
                    left.Add(collection[i]);
                }
                else
                {
                    right.Add(collection[i]);
                }
            }

            left = QuickSort(left);
            right = QuickSort(right);
            result.AddRange(left);
            result.Add(pivot);
            result.AddRange(right);

            return result;
        }

        private T GetAverageValue(T firstElement, T seccondElement, T thirdElement)
        {
            if (firstElement.CompareTo(seccondElement) > 0)
            {
                if (seccondElement.CompareTo(thirdElement) > 0)
                {
                    return seccondElement;
                }
                else if (firstElement.CompareTo(thirdElement) > 0)
                {
                    return thirdElement;
                }
                else
                {
                    return firstElement;
                }
            }
            else
            {
                if (firstElement.CompareTo(thirdElement) > 0)
                {
                    return firstElement;
                }
                else if (seccondElement.CompareTo(thirdElement) > 0)
                {
                    return thirdElement;
                }
                else
                {
                    return seccondElement;
                }
            }
        }


        private void Swap(IList<T> collection, int firstElementIndex, int secondElementIndex)
        {
            T oldValue = collection[firstElementIndex];
            collection[firstElementIndex] = collection[secondElementIndex];
            collection[secondElementIndex] = oldValue;
        }

    }
}
