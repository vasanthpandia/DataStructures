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
    }
}
