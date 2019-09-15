using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add Method call to any algorithm
            Console.WriteLine();
            Console.ReadKey();
        }

        static void compareVersions()
        {
            string v1 = "1";
            string v2 = "1.0.1";

            int x = StringOperations.CompareVersions(v1, v2);

            if (x == 0)
            {
                Console.WriteLine("Both versions are the same");
            } else if(x == -1)
            {
                Console.WriteLine(v1);
            } else
            {
                Console.WriteLine(v2);
            }
        }

        static void printchars()
        {
            char[] s = new char[5];
            foreach(char c in s)
            {
                Console.WriteLine(c);
            }
        }

        static void runLLOperations()
        {
            LinkedList a = new LinkedList(25);

            a.Insert(30).Insert(40).Insert(50).Insert(60);

            a.printList();
            Console.WriteLine();
            a.DeleteMiddle();
            a.printList();


            Console.WriteLine("Remove nth node from end of list");

            Node lnode = new Node(1);
            lnode.Insert(2);

            lnode.PrintNode();

            Node n = Node.Removenth(lnode, 1);

            n.PrintNode();
        }

        static Node buildLoopedList(int length, int loopstart)
        {
            if(length < loopstart)
            {
                return null;
            }

            Node head = new Node(1);
            Node current = head;
            for (int i = 2; i <= length; i++)
            {
                current.Next(new Node(i));
                current = current.Next();
            }

            Node loopedNode = head;

            for(int i = 1; i < loopstart; i++ )
            {
                loopedNode = loopedNode.Next();
            }

            current.Next(loopedNode);


            return head;
        }

        static Node buildList(int length)
        {
            if(length <= 0)
            {
                return null;
            }

            Node head = new Node(1);
            Node current = head;

            for(int i = 2; i <= length; i++)
            {
                current.Next(new Node(i));
                current = current.Next();
            }

            return head;
        }

        static void isLoopPresent()
        {
            Node head = buildLoopedList(25, 7);

            Node fastptr, slowptr;

            slowptr = head;
            fastptr = slowptr.Next().Next();

            while(slowptr != null && fastptr != null && fastptr.Next() != null)
            {
                slowptr = slowptr.Next();
                fastptr = fastptr.Next().Next();

                if(slowptr == fastptr)
                {
                    Console.WriteLine("Loop Exists");
                    break;
                }
            }

            if(slowptr != fastptr)
            {
                Console.WriteLine("No Loop found");
            }
        }

        static void findLoopStart()
        {
            Node head = buildLoopedList(20, 10);

            Node fastptr = head;
            Node slowptr = fastptr;

            while(slowptr != null && fastptr != null && fastptr.Next() != null)
            {
                slowptr = slowptr.Next();
                fastptr = fastptr.Next().Next();

                if(slowptr == fastptr)
                {
                    break;
                }
            }

            if(slowptr != fastptr)
            {
                return;
            }

            slowptr = head;

            while(slowptr != fastptr)
            {
                slowptr = slowptr.Next();
                fastptr = fastptr.Next();
            }

            Console.WriteLine("Loop Starts at : " + slowptr.Data());


        }

        static void runBTOperations()
        {
            BTNode bt = new BTNode(25);

            bt.insert(20).insert(35).insert(30).insert(45).insert(10).insert(15).insert(11).insert(13).insert(50).insert(37).insert(55).insert(40).insert(27).insert(23);

            BTNode btt = BTNode.deleteNode(bt, 15);

            bt.printInOrder();
            //BTNode.printLevelOrder(bt);

            Console.WriteLine("Deleted : " + btt.Data());
            BTNode.printLevelOrder(bt);

            //Console.Write("The LCA of 30 and 50 is : " + BTNode.lcabt(bt, bt1, bt2).Data());

            //BTNode.printLevelOrderZigZag(bt);
            //BTNode.printLevelZigZagQueue(bt);

            //bt.printInOrder();
            //Console.WriteLine("\nIterative Inroder Print");
            //bt.printIterativeInOrder();
            //Console.WriteLine("Iterative PreOrder Print");
            //bt.printIterativePreorder();
            //Console.WriteLine("Iterative PostOrder Print - 2 Stack");
            //bt.printIterativePostOrder2Stack();
            //Console.WriteLine("Iterative PostOrder Print - 1 Stack");
            //bt.printIterativePostOrder();
            //Console.WriteLine("Iterative PostOrder Simple - 1 Stack");
            //bt.printIterativePostOrderSimple();

        }

        static BTNode buildBT(int[] nums)
        {
            if(nums.Length != 7)
            {
                return null;
            }

            BTNode root = new BTNode(nums[0]);
            root.Left(new BTNode(nums[1]));
            root.Right(new BTNode(nums[2]));
            root.Left().Left(new BTNode(nums[3]));
            root.Left().Right(new BTNode(nums[4]));
            root.Right().Left(new BTNode(nums[5]));
            root.Right().Right(new BTNode(nums[6]));

            return root;
        }

        static int LastRemaining(int n)
        {
            List<int> mylist = new List<int>();

            for (int i = 0; i <= n; i++)
            {
                mylist.Add(i);
            }

            while (mylist.Count() > 1)
            {
                for (int j = 0; j < mylist.Count(); j += 2)
                {
                    mylist.Remove(j);
                }

                for (int k = mylist.Count() - 1; k >= 0; k -= 2)
                {
                    mylist.Remove(k);
                }
            }

            return mylist[0];
        }

        static void nthfibonacci(int n)
        {
            int[] fib = new int[n + 1];

            Console.WriteLine("Fibonacci of n = " + n + " is " + nthfib(n, fib));

        }

        static int nthfib(int n, int[] nums)
        {
            if(n == 0 || n == 1)
            {
                return n;
            }

            if(nums[n] == 0)
            {
                nums[n] = nthfib(n-1, nums) + nthfib(n-2, nums);
            }

            return nums[n];
        }

        static void LRUOperations()
        {
            LRUCache lru = new LRUCache(5);
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for(int i = 0; i < 5; i++)
            {
                lru.Put(nums[i], nums[i]);
            }

            lru.printall();

            Console.WriteLine("Access Element 2 : " + lru.Get(3));

            lru.printall();

            Console.WriteLine("Access Element 4 :" + lru.Get(4));

            lru.printall();

            lru.Put(6, 46);
            lru.Put(7, 35);

            lru.printall();


        }

        static void QueueOperations2Stack()
        {
            int[] a = { 10, 15, 20, 25, 30, 35, 40, 45 };

            TwoStackQueue<int> queue = new TwoStackQueue<int>();

            foreach(int number in a)
            {
                queue.Enqueue(number);
            }

            foreach(int number in a)
            {
                Console.Write("" + queue.Dequeue() + " ");
            }
        }

        static void HeapOperations()
        {
            int[] nums = { 22, 1, 45, 8, 7, 16, 19, 25, 17, 91, 0, 208, 10 };

            MinHeap heap = new MinHeap();

            foreach(int num in nums)
            {
                heap.add(num);
            }

            while(heap.Size() > 0)
            {
                Console.Write("" + heap.poll() + " ");
            }
        }
    }
}
