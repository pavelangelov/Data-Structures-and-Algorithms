using System;

namespace Framework
{
    public class PriorityQueue<T> where T: IComparable<T>
    {
        private T[] queue;
        private int size = 0;

        public PriorityQueue(int length)
        {
            this.queue = new T[length];
        }

        public int Size { get { return this.size; } }

        public void Insert(T item)
        {
            if (this.size == this.queue.Length)
            {
                this.Resize();
            }

            this.queue[this.size] = item;
            ResortQueue(this.size);
            this.size++;
        }

        public T Peek()
        {
            return this.queue[0];
        }

        public T Pull()
        {
            T item = this.queue[0];
            if (this.size > 1)
            {
                this.size--;
                this.queue[0] = this.queue[this.size];

                RebalanceQueue(0);
            }
            else
            {
                this.queue[0] = default(T);
            }

            return item;
        }

        private void RebalanceQueue(int parentIndex)
        {
            var parentItem = this.queue[parentIndex];
            var leftChildIndex = parentIndex * 2;
            var rightChildIndex = parentIndex * 2 + 1;
            var largestChildIndex = parentIndex;

            if (leftChildIndex < this.size && this.queue[leftChildIndex].CompareTo(this.queue[largestChildIndex]) > 0)
            {
                largestChildIndex = leftChildIndex;
            }

            if (rightChildIndex < this.size && this.queue[rightChildIndex].CompareTo(this.queue[largestChildIndex]) > 0)
            {
                largestChildIndex = rightChildIndex;
            }

            if (largestChildIndex != parentIndex)
            {
                var temp = this.queue[parentIndex];
                this.queue[parentIndex] = this.queue[largestChildIndex];
                this.queue[largestChildIndex] = temp;
                this.RebalanceQueue(largestChildIndex);
            }
        }

        private void ResortQueue(int childIndex)
        {
            if (childIndex > 0)
            {
                var parentIndex = childIndex / 2;
                if (this.queue[parentIndex].CompareTo(this.queue[childIndex]) < 0)
                {
                    var temp = this.queue[parentIndex];
                    this.queue[parentIndex] = this.queue[childIndex];
                    this.queue[childIndex] = temp;
                    this.ResortQueue(parentIndex);
                }
            }
        }

        private void Resize()
        {
            var resizedQueue = new T[this.queue.Length * 2];
            Array.Copy(this.queue, 0, resizedQueue, 0, this.queue.Length);
            this.queue = resizedQueue;
        }
    }
}
