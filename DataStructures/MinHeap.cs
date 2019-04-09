using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class MinHeap
    {
        private int capacity, size;
        private int[] items;

        public MinHeap()
        {
            capacity = 10;
            size = 0;
            items = new int[capacity];
        }

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
            return getLeftChildIndex(index) < size;
        }

        private Boolean hasRightChild(int index)
        {
            return getRightChildIndex(index) < size;
        }

        private Boolean hasParent(int index)
        {
            return getParentIndex(index) >= 0;
        }

        private int leftChild(int index)
        {
            return items[getLeftChildIndex(index)];
        }

        private int rightChild(int index)
        {
            return items[getRightChildIndex(index)];
        }

        private int getParent(int index)
        {
            return items[getParentIndex(index)];
        }

        private void swap(int fromIndex, int toIndex)
        {
            int temp = items[toIndex];
            items[toIndex] = items[fromIndex];
            items[fromIndex] = temp;
        }

        private void ensureCapacity()
        {
            if (size == capacity)
            {
                int[] temp = new int[capacity * 2];
                Array.Copy(items, temp, items.Length);
                items = temp;
                capacity *= 2;
            }
        }

        // API Methods

        public int peek()
        {
            if (size == 0) throw new Exception("Heap Empty");

            return items[0];
        }

        public int poll()
        {
            if (size == 0) throw new Exception("Heap Empty");

            int item = items[0];
            items[0] = items[size - 1];
            size--;

            heapifyDown();

            return item;
        }

        public void add(int x)
        {
            ensureCapacity();

            items[size] = x;
            size++;
            heapifyUp();
        }

        public void heapifyUp()
        {
            int index = size - 1;

            while(hasParent(index) && getParent(index) > items[index])
            {
                swap(index, getParentIndex(index));
                index = getParentIndex(index);
            }
        }

        public void heapifyDown()
        {
            int index = 0;

            while(hasLeftChild(index))
            {
                int smallerChildIndex = getLeftChildIndex(index);
                if(hasRightChild(index) && rightChild(index) < leftChild(index))
                {
                    smallerChildIndex = getRightChildIndex(index);
                }

                if(items[smallerChildIndex] < items[index])
                {
                    swap(smallerChildIndex, index);
                } else
                {
                    break;
                }

                index = smallerChildIndex;
            }
        }

        public int Size()
        {
            return size;
        }
    }
}
