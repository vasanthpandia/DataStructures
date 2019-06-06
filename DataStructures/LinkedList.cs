using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class LinkedList
    {
        private Node head;
        private Node current;

        public Node Head()
        {
            return head;
        }

        public LinkedList()
        {
            head = null;
        }
        
        public LinkedList(int a)
        {
            head = new Node(a);
            current = head;
        }

        public LinkedList Insert(int a)
        {
            Node temp = new Node(a);
            current.Next(temp);
            current = current.Next();
            return this;
        }

        public void DeleteMiddle()
        {
            Node slowptr = head;
            Node fastptr = head;
            Node prev = slowptr;
            while(fastptr!= null && fastptr.Next() != null)
            {
                prev = slowptr;
                slowptr = slowptr.Next();
                fastptr = fastptr.Next().Next();
            }

            prev.Next(slowptr.Next());
        }

        public void printList()
        {
            Node runner = head;
            while(runner != null)
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
                if (i > 1)
                    runner = runner.Next();
            }

            while (runner != null)
            {
                prev = start;
                start = start.Next();
                runner = runner.Next();
            }

            if (start != null)
            {
                prev.Next(start.Next()); //= start.next();
            }
            else
            {
                head = head.Next();
            }

            return head;
        }
    }
}
