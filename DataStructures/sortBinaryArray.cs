using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class sortBinaryArray
    {
        public static int[] sort(int[] nums)
        {
            int i = 0;
            int j = nums.Length - 1;

            while(i < j)
            {
                if(nums[i] == 1)
                {
                    swap(nums, i, j);
                    j--;
                } else
                {
                    i++;
                }
            }

            return nums;

        }

        public static void swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        } 
    }
}
