using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace DataStructures
{
    class ThreadSafe
    {
        public static Dictionary<int, int> cd = new Dictionary<int, int>();

        public static void concurrentdict()
        {

            Thread t = new Thread(startEnqueue);
            t.Start();
            

            for(int i = 1; i < 100; i += 2)
            {
                Console.WriteLine(cd[i + 1]);
            }
        }

        public static void startEnqueue()
        {
            for(int i = 2; i < 100; i += 2)
            {
                cd[i] = i * i;
            }
        }

        public static void readMap()
        {
            for(int i = -100; i < 100; i++)
            {
                if(i > 0)
                {
                    int a = -10;
                    cd.TryGetValue(i, out a);
                    Console.WriteLine(a);
                }
            }
        }
    }
}
