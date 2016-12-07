namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (this.items[i].CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            var length = this.items.Count;
            var middle = length / 2;
            while (true)
            {
                if(this.items[middle].CompareTo(item) == 0)
                {
                    return true;
                }

                length /= 2;
                if (this.items[middle - 1].CompareTo(item) > 0)
                {
                    middle = middle - (length / 2);
                }
                else
                {
                    middle = middle + (length / 2);
                }

                if(length == 0)
                {
                    return false;
                }
            }
        }

        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < this.items.Count; i++)
            {
                var randomIndex = rand.Next(i, items.Count);

                T oldValue = this.items[i];
                this.items[i] = this.items[randomIndex];
                this.items[randomIndex] = oldValue;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
