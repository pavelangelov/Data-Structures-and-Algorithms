﻿namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                var current = collection[i];
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (current.CompareTo(collection[j]) > 0)
                    {
                        this.Swap(collection, i, j);
                    }
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
