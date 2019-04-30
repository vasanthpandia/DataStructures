using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class StringOperations
    {
        public static void removeDuplicates(String str)
        {
            byte[] chars = new byte[128];

            for (int i = 0; i < str.Length; i++)
            {
                chars[str[i]] = 1;
            }

            String a = "";

            for (int i = 0; i < 128; i++)
            {
                if (chars[i] == 1)
                {
                    a += (char)i;
                }
            }

            Console.WriteLine(a);
        }

        public static int longestNonRepeatingSubArray(string str)
        {
            int n = str.Length;

            HashSet<char> charset = new HashSet<char>();

            int ans = 0, i = 0, j = 0;

            while(i < n && j < n)
            {
                if(!charset.Contains(str[j]))
                {
                    charset.Add(str[j++]);
                    ans = Math.Max(ans, j - i);
                } else
                {
                    charset.Remove(str[i++]);
                }
            }

            return ans;
        }

        public static int longestNRSubarrayOptimized(string str)
        {
            int n = str.Length;
            byte[] indices = new byte[128];
            int ans = 0;

            for(int i = 0, j = 0; j < n; j++)
            {
                i = Math.Max(indices[str[j]], i);
                ans = Math.Max(ans, j - i + 1);
                indices[str[j]] = (byte) (j + 1);
            }

            return ans;
        }

        public static void generateAllSubstrings(string str)
        {
            int len = 1;

            while(len <= str.Length)
            {
                for(int start = 0; start <= str.Length - len; start++)
                {
                    string s = "";

                    int end = start + (len - 1);

                        for(int k = start; k <= end; k++)
                        {
                            s += str[k];
                        }

                    Console.WriteLine(s);
                }
                len++;
            }
        }

        public static void generateSubStrings(string str)
        {
            List<string> result = new List<string>();

            string temp = "";

            int k = 2;

            backTrackGenSubStr(str, result, temp, 0, k);

            foreach(string s in result)
            {
                Console.WriteLine(s);
            }

        }

        public static void backTrackGenSubStr(string str, List<string> result, string s, int start, int k)
        {
            if(s.Length == k)
            {
                result.Add(new string(s.ToCharArray()));
            }
            for(int i = start; i < str.Length; i++)
            {
                s += str[i];
                backTrackGenSubStr(str, result, s, i+1, k);
                Console.WriteLine("Before Remove : " + s);
                s = s.Substring(0, s.Length - 1);
                
            }
        }
    }
}
