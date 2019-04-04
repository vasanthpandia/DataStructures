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
    }
}
