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

            Console.WriteLine("Hello World - Binary Tree!");

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

            Console.WriteLine();

            //LinkedList a = new LinkedList(25);

            //a.Insert(30).Insert(40).Insert(50).Insert(60);

            //a.printList();
            //Console.WriteLine();
            //a.DeleteMiddle();
            //a.printList();

            //int[] b = { 1, 2, 3, 5, 7 };

            //Console.WriteLine($"Search result of 3 in b {ArrayOperations.BinarySearch(b, 3, 0, b.Count() - 1)}");
            //Console.WriteLine($"Search result of 12 in b {ArrayOperations.BinarySearch(b, 12, 0, b.Count() - 1)}");

            // LinkedList

            //Console.WriteLine("Remove nth node from end of list");

            //Node lnode = new Node(1);
            //lnode.Insert(2);

            //lnode.PrintNode();

            //Node n = Node.Removenth(lnode, 1);

            //n.PrintNode();

            //Console.WriteLine($"{LastRemaining(9)}");



            Console.ReadKey();
        }

        //static int LastRemaining(int n)
        //{
        //    List<int> mylist = new List<int>();

        //    for (int i = 0; i <= n; i++)
        //    {
        //        mylist.Add(i);
        //    }

        //    while (mylist.Count() > 1)
        //    {
        //        for (int j = 0; j < mylist.Count(); j += 2)
        //        {
        //            mylist.Remove(j);
        //        }

        //        for (int k = mylist.Count() - 1; k >= 0; k -= 2)
        //        {
        //            mylist.Remove(k);
        //        }
        //    }

        //    return mylist[0];
        //}
    }
}
