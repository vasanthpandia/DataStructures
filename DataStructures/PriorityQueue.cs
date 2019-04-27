using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class PriorityQueue<T> where T : IComparable 
    {
        private List<T> data;

        // Private Utility Methods

        private int getLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        private int getRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        private int getParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private Boolean hasLeftChild(int index)
        {
            return getLeftChildIndex(index) < data.Count;
        }

        private Boolean hasRightChild(int index)
        {
            return getRightChildIndex(index) < data.Count;
        }

        private Boolean hasParent(int index)
        {
            return getParentIndex(index) >= 0;
        }

        private T leftChild(int index)
        {
            return data[getLeftChildIndex(index)];
        }

        private T rightChild(int index)
        {
            return data[getRightChildIndex(index)];
        }

        private T getParent(int index)
        {
            return data[getParentIndex(index)];
        }

        private int Compare(T item1, T item2)
        {
            return 0;
        }

        // Swap elements
        private void swap(int fromIndex, int toIndex)
        {
            T temp = data[toIndex];
            data[toIndex] = data[fromIndex];
            data[fromIndex] = temp;
        }

        private void heapifyDown()
        {
            int index = 0;

            while (hasLeftChild(index))
            {
                int smallerChildIndex = getLeftChildIndex(index);
                if (hasRightChild(index) && rightChild(index).CompareTo(leftChild(index)) < 0)
                {
                    smallerChildIndex = getRightChildIndex(index);
                }

                if (data[smallerChildIndex].CompareTo(data[index]) < 0)
                {
                    swap(smallerChildIndex, index);
                }
                else
                {
                    break;
                }

                index = smallerChildIndex;
            }
        }

        public void heapifyUp()
        {
            int index = Count() - 1;

            while (hasParent(index) && getParent(index).CompareTo(data[index]) > 0)
            {
                swap(index, getParentIndex(index));
                index = getParentIndex(index);
            }
        }

        // Public API Methods

        // Constructor
        public PriorityQueue()
        {
            this.data = new List<T>();
        }

        public int Count()
        {
            return data.Count;
        }

        public T Peek()
        {
            T frontItem = data[0];

            return frontItem;
        }

        public T poll()
        {
            if (data.Count == 0) throw new Exception("Heap Empty");

            T frontItem = data[0];
            int last = Count() - 1;
            data[0] = data[last];

            data.RemoveAt(last);

            --last;
            heapifyDown();

            return frontItem;
        }

        public void Add(T item)
        {
            data.Add(item);

            heapifyUp();
        }


    }
}
