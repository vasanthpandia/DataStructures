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
