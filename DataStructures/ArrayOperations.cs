using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class ArrayOperations
    {
        public static int BinarySearch(int[] nums, int key, int start, int end)
        {
            int mid = (start + end) / 2;
            if(nums[mid] == key)
            {
                return mid;
            }
            else if(start >= end)
            {
                return -1;
            }    
            else if (nums[mid] > key)
            {
               return BinarySearch(nums, key, start, mid - 1);
            } else
            {
               return BinarySearch(nums, key, mid + 1, end);            
            }        
        }

        public static int[] mergeSorted(int[] nums1, int[] nums2)
        {
            if(nums1.Length == 0)
            {
                return nums2;
            }

            if(nums2.Length == 0)
            {
                return nums1;
            }

            int[] result = new int[nums1.Length + nums2.Length];

            int i = 0, j = 0, k = 0;

            while(k < result.Length && i < nums1.Length && j < nums2.Length)
            {
                if(nums1[i] == nums2[j])
                {
                    result[k] = nums1[i];
                    k++;
                    i++;
                    result[k] = nums2[j];
                    k++;
                    j++;
                } else if(nums1[i] < nums2[j])
                {
                    result[k] = nums1[i];
                    i++;
                    k++;
                } else
                {
                    result[k] = nums2[j];
                    j++;
                    k++;
                }
            }

            while(i < nums1.Length && k < result.Length)
            {
                result[k++] = nums1[i++];
            }

            while(j < nums2.Length && k < result.Length)
            {
                result[k++] = nums2[j++];
            }

            return result;
        }

        public static List<int[]> mergeSortedInPlace(int[] nums1, int[] nums2)
        {
            List<int[]> result = new List<int[]>();

            for(int i = nums2.Length - 1; i >= 0; i--)
            {
                int j = nums1.Length - 1;
                int last = nums1[j];
                if(last < nums2[i])
                {
                    continue;
                }
                j--;

                while(j >= 0)
                {
                    if(nums2[i] >= nums1[j])
                    {
                        int k = nums1.Length - 1;
                        while(j < k)
                        {
                            nums1[k] = nums1[k - 1];
                            k--;
                        }
                        nums1[j+1] = nums2[i];
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

            for(int i = 0; i < products.Length; i++)
            {
                products[i] = 1;
            }

            int temp = 1;

            // Find Left Products in Products Arrray
            for(int i = 0; i < nums.Length; i++)
            {
                products[i] = temp;
                temp *= nums[i];
            }

            temp = 1;

            // Update Elements in Products array to final result
            for(int i = nums.Length - 1; i >= 0; i--)
            {
                products[i] *= temp;
                temp *= nums[i];
            }

            for(int i = 0; i < products.Length; i++)
            {
                Console.Write("" + products[i] + " ");
            }
        }

        public static int findRotationPoint(int[] nums)
        {
            int first, last;
            first = 0;
            last = nums.Length - 1;

            while(first < last)
            {
                int mid = (first + last) / 2;

                if(mid > 0 && nums[mid] < nums[mid - 1])
                {
                    return mid;
                }

                if(mid < nums.Length && nums[mid] > nums[mid + 1])
                {
                    return mid + 1;
                }

                if(nums[mid] > nums[nums.Length - 1])
                {
                    first = mid + 1;
                } else {
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

            if(nums[pivot] == target)
            {
                return pivot;
            } else if(target < nums[nums.Length - 1])
            {
                return BinarySearch(nums, target, pivot + 1, last);
            } else if(target > nums[nums.Length - 1])
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

            for(int i = left; i < right; i++)
            {
                if(nums[i] < pivot)
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
    }
}
