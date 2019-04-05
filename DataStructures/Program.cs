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
            BTNode bt = new BTNode(25);

            bt.insert(20).insert(35).insert(30).insert(45).insert(10).insert(15).insert(11).insert(13).insert(50).insert(37).insert(55).insert(40).insert(27).insert(23);
            //bt.printInOrder();

            Console.WriteLine(BTNode.isBSTWithInorder(bt));
            int[] a = { 1, 2, 3, 4, 5, 6, 7};
            BTNode node = buildBT(a);
            //node.printInOrder();
            Console.WriteLine(BTNode.isBSTWithInorder(node));
            //BTNode.printLevelOrder(node);

            Console.ReadKey();
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

            bt.printInOrder();
            Console.WriteLine("\nIterative Inroder Print");
            bt.printIterativeInOrder();
            Console.WriteLine("Iterative PreOrder Print");
            bt.printIterativePreorder();
            Console.WriteLine("Iterative PostOrder Print - 2 Stack");
            bt.printIterativePostOrder2Stack();
            Console.WriteLine("Iterative PostOrder Print - 1 Stack");
            bt.printIterativePostOrder();
            Console.WriteLine("Iterative PostOrder Simple - 1 Stack");
            bt.printIterativePostOrderSimple();

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
    }
}
