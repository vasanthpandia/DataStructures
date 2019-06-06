﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    class ArrayOperations
    {
        public static int BinarySearch(int[] nums, int key, int start, int end)
        {
            int mid = (start + end) / 2;
            if (nums[mid] == key)
            {
                return mid;
            }
            else if (start >= end)
            {
                return -1;
            }
            else if (nums[mid] > key)
            {
                return BinarySearch(nums, key, start, mid - 1);
            }
            else
            {
                return BinarySearch(nums, key, mid + 1, end);
            }
        }

        public static int[] mergeSorted(int[] nums1, int[] nums2)
        {
            if (nums1.Length == 0)
            {
                return nums2;
            }

            if (nums2.Length == 0)
            {
                return nums1;
            }

            int[] result = new int[nums1.Length + nums2.Length];

            int i = 0, j = 0, k = 0;

            while (k < result.Length && i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] == nums2[j])
                {
                    result[k] = nums1[i];
                    k++;
                    i++;
                    result[k] = nums2[j];
                    k++;
                    j++;
                }
                else if (nums1[i] < nums2[j])
                {
                    result[k] = nums1[i];
                    i++;
                    k++;
                }
                else
                {
                    result[k] = nums2[j];
                    j++;
                    k++;
                }
            }

            while (i < nums1.Length && k < result.Length)
            {
                result[k++] = nums1[i++];
            }

            while (j < nums2.Length && k < result.Length)
            {
                result[k++] = nums2[j++];
            }

            return result;
        }

        public static List<int[]> mergeSortedInPlace(int[] nums1, int[] nums2)
        {
            List<int[]> result = new List<int[]>();

            for (int i = nums2.Length - 1; i >= 0; i--)
            {
                int j = nums1.Length - 1;
                int last = nums1[j];
                if (last < nums2[i])
                {
                    continue;
                }
                j--;

                while (j >= 0)
                {
                    if (nums2[i] >= nums1[j])
                    {
                        int k = nums1.Length - 1;
                        while (j < k)
                        {
                            nums1[k] = nums1[k - 1];
                            k--;
                        }
                        nums1[j + 1] = nums2[i];
                        break;
                    }
                    j--;
                }

                nums2[i] = last;
            }

            result.Add(nums1);
            result.Add(nums2);

            return result;
        }

        public static void printProductArray(int[] nums)
        {
            int[] products = new int[nums.Length];

            for (int i = 0; i < products.Length; i++)
            {
                products[i] = 1;
            }

            int temp = 1;

            // Find Left Products in Products Arrray
            for (int i = 0; i < nums.Length; i++)
            {
                products[i] = temp;
                temp *= nums[i];
            }

            temp = 1;

            // Update Elements in Products array to final result
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                products[i] *= temp;
                temp *= nums[i];
            }

            for (int i = 0; i < products.Length; i++)
            {
                Console.Write("" + products[i] + " ");
            }
        }

        public static int findRotationPoint(int[] nums)
        {
            int first, last;
            first = 0;
            last = nums.Length - 1;

            while (first < last)
            {
                int mid = (first + last) / 2;

                if (mid > 0 && nums[mid] < nums[mid - 1])
                {
                    return mid;
                }

                if (mid < nums.Length && nums[mid] > nums[mid + 1])
                {
                    return mid + 1;
                }

                if (nums[mid] > nums[nums.Length - 1])
                {
                    first = mid + 1;
                }
                else
                {
                    last = mid - 1;
                }

            }

            return -1;
        }

        public static int findInRotatedArray(int[] nums, int target)
        {
            int pivot = findRotationPoint(nums);
            int first, last;

            first = 0;
            last = nums.Length - 1;

            if (nums[pivot] == target)
            {
                return pivot;
            }
            else if (target < nums[nums.Length - 1])
            {
                return BinarySearch(nums, target, pivot + 1, last);
            }
            else if (target > nums[nums.Length - 1])
            {
                return BinarySearch(nums, target, first, pivot - 1);
            }

            return -1;
        }

        public static int kthlargest(List<int> nums, int k)
        {
            int size = nums.Count;
            int num = size - k;

            return quickSelect(nums, 0, size - 1, k - 1);
        }

        public static int quickSelect(List<int> nums, int left, int right, int k)
        {
            if (left == right)
            {
                return nums[left];
            }

            Random rnd = new Random();

            int pivot_index = left + rnd.Next(right - left);

            pivot_index = partition(nums, left, right, pivot_index);

            if (pivot_index == k)
            {
                return nums[pivot_index];
            }
            else if (pivot_index < k)
            {
                return quickSelect(nums, pivot_index + 1, right, k);
            }
            else
            {
                return quickSelect(nums, left, pivot_index - 1, k);
            }
        }

        public static int partition(List<int> nums, int left, int right, int pivot_index)
        {
            int pivot = nums[pivot_index];
            swap(nums, pivot_index, right);

            int storeindex = left;

            for (int i = left; i < right; i++)
            {
                if (nums[i] < pivot)
                {
                    swap(nums, i, storeindex);
                    storeindex++;
                }
            }

            swap(nums, storeindex, right);

            return storeindex;
        }

        public static void swap(List<int> nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        public static double medianOfSorted(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                return medianOfSorted(nums2, nums1);
            }

            int x = nums1.Length;
            int y = nums2.Length;

            int low = 0;
            int high = x;

            int halflen = (x + y + 1) / 2;

            while (low <= high)
            {
                int partitionX = (low + high) / 2;
                int partitionY = halflen - partitionX;
                Console.WriteLine("PartitionX : " + partitionX + " , PartitionY : " + partitionY);
                int maxLeftX = (partitionX <= 0) ? Int32.MinValue : nums1[partitionX - 1];
                int minRightX = (partitionX == x) ? Int32.MaxValue : nums1[partitionX];

                int maxLeftY = (partitionY <= 0) ? Int32.MinValue : nums2[partitionY - 1];
                int minRightY = (partitionY == y) ? Int32.MaxValue : nums2[partitionY];

                if (maxLeftX <= minRightY && maxLeftY <= minRightX)
                {
                    if ((x + y) % 2 == 0)
                    {
                        return (double)(Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2;
                    }
                    else
                    {
                        return (double)Math.Max(maxLeftX, maxLeftY);
                    }
                }
                else if (maxLeftX > minRightY)
                {
                    high = partitionX - 1;
                }
                else
                {
                    low = partitionX + 1;
                }

            }

            return -1;
        }

        // Return a unique list from a sorted array
        public static int[] uniqueArrayFromSorted(int[] nums)
        {
            List<int> resultList = new List<int>();

            if (nums == null || nums.Length == 0)
            {
                return resultList.ToArray();
            }

            resultList.Add(nums[0]);

            for (int i = 1; i < nums.Count(); i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    resultList.Add(nums[i]);
                }
            }

            return resultList.ToArray();
        }

        // Merge Sort of an array

        public static int[] mergeSort(int[] nums)
        {
            int n = nums.Length;
            if (n < 2)
            {
                return nums;
            }

            int mid = n / 2;

            int[] l = new int[mid];
            int[] r = new int[n - mid];

            for (int i = 0; i < mid; i++)
            {
                l[i] = nums[i];
            }

            for (int i = mid; i < n; i++)
            {
                r[i - mid] = nums[i];
            }

            l = mergeSort(l);
            r = mergeSort(r);

            return mergeSorted(l, r);
        }

        public static List<int> kSmallest(int[] nums, int k)
        {
            List<int> result = new List<int>();
            PriorityQueue<int> a = new PriorityQueue<int>();

            foreach (int i in nums)
            {
                a.Add(i);
            }

            for (int i = 0; i < k; i++)
            {
                result.Add(a.poll());
            }

            return result;
        }

        public static List<List<int>> kSumSubarrays(int[] nums, int k)
        {
            List<List<int>> result = new List<List<int>>();

            Array.Sort(nums);

            List<int> candidate = new List<int>();

            backtrackkSumSubArray(0, nums.Length, nums, result, candidate, k);

            return result;
        }

        public static void backtrackkSumSubArray(int bg, int end, int[] nums, List<List<int>> result, List<int> candidate, int target)
        {
            if (target == 0)
            {
                result.Add(new List<int>(candidate));
                return;
            }

            for (int i = bg; i < end; i++)
            {
                if (nums[i] > target)
                {
                    break;
                }

                candidate.Add(nums[i]);

                backtrackkSumSubArray(i + 1, end, nums, result, candidate, (target - nums[i]));

                candidate.RemoveAt(candidate.Count - 1);
            }
        }

        public static List<int> mergeKSortedArrays(List<List<int>> lists)
        {
            List<int> result = new List<int>();

            PriorityQueue<PQIElement> kListQueue = new PriorityQueue<PQIElement>();

            for (int i = 0; i < lists.Count; i++)
            {
                PQIElement pqe = new PQIElement(lists[i][0], 1, i);
                kListQueue.Add(pqe);
            }

            while(kListQueue.Peek().data != Int32.MaxValue)
            {
                PQIElement top = kListQueue.Peek();
                result.Add(top.data);

                if(top.n_element_id < lists[top.arr_id].Count)
                {
                    top.data = lists[top.arr_id][top.n_element_id];
                    top.n_element_id += 1;
                } else
                {
                    top.data = Int32.MaxValue;
                }

                kListQueue.heapifyDown();
            }

            return result;
        }

        class PQIElement : IComparable
        {
            public int data { get; set; }
            public int n_element_id { get; set; }
            public int arr_id { get; set; }

            public PQIElement(int a, int b, int c)
            {
                data = a;
                n_element_id = b;
                arr_id = c;
            }

            public int CompareTo(object obj)
            {
                int result;

                if(data > ((PQIElement)obj).data)
                {
                    result = 1;
                } else if(data < ((PQIElement)obj).data)
                {
                    result = -1;
                } else
                {
                    result = 0;
                }

                return result;
            }
        }

        public static int[] NextGreatest(int[] nums)
        {
            if (nums == null || nums.Length == 0) return nums;

            int[] result = new int[nums.Length]; 
            Stack<int> st = new Stack<int>();

            for(int i = nums.Length - 1; i >= 0; i--)
            {

                if(st.Count != 0)
                {
                    while(st.Count != 0 && nums[i] >= st.Peek())
                    {
                        st.Pop();
                    }
                }

                result[i] = st.Count != 0 ? st.Peek() : nums[i];

                st.Push(nums[i]);
            }

            return result;
        }
    }
}
