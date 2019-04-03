using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class ListNode
    {
        public int data;
        public ListNode next;

        public ListNode(int a)
        {
            data = a;
            next = null;
        }

        public ListNode Insert(int a)
        {
            ListNode temp = new ListNode(a);
            ListNode temp2 = this;

            while(temp2.next != null)
            {
                temp2 = temp2.next;
            }
            temp2 = temp;
            return this;

        }

        public static void PrintListNode(ListNode head)
        {
            while(head != null)
            {
                Console.Write($"{head.data} ");
                head = head.next;
            }
        }

        public static ListNode Removenth(ListNode head, int n)
        {
            ListNode prev, start, runner;
            start = runner = head;
            prev = null;

            for(int i = 1; i <= n; i++)
            {
                if (i > 1)
                    runner = runner.next;
            }

            while(runner != null)
            {
                prev = start;
                start = start.next;
                runner = runner.next;
            }

            if(start != null)
            {
                prev.next = start.next;
            } else
            {
                head = head.next;
            }

            return head;
        }
    }

}
