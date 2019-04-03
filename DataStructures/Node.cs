using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Node
    {
        private int data;
        private Node next;

        public Node(int x)
        {
            this.data = x;
            this.next = null;
        }

        public int Data()
        {
            return data;
        }

        public Node Data(int x)
        {
            this.data = x;
            return this;
        }

        public Node Next()
        {
            return next;
        }

        public Node Next(Node x)
        {
            this.next = x;
            return this;
        }

        public Node Insert(int n)
        {
            Node a = this;
            while(a.next != null)
            {
                a = a.next;
            }

            a.next = new Node(n);

            return this;
        }

        public void PrintNode()
        {
            Node runner = this;
            while (runner != null)
            {
                Console.Write($"{runner.Data()} ");

                runner = runner.Next();
            }

            Console.WriteLine();
        }

        public static Node Removenth(Node head, int n)
        {
            Node prev, start, runner;
            start = runner = head;
            prev = null;

            for (int i = 1; i <= n; i++)
            {
                if(runner != null)
                {
                    if (i > 1)
                        runner = runner.Next();
                } else
                {
                    return null;
                }
            }

            while (runner.Next() != null)
            {
                    prev = start;
                    start = start.Next();
                    runner = runner.Next();
                /*Console.WriteLine($"Start is {start.Data()}");
                Console.WriteLine($"Runner is {runner.Data()}");
                Console.WriteLine($"Prev is {prev.Data()}");*/
            }

            if(prev == null)
            {
                head = head.Next();
            } else
            {
                if(runner.Next() == null)
                {
                    prev.Next(start.Next());

                }
            }
            
            return head;
        }
    }
}
