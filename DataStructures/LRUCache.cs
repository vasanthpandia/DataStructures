using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class LRUCache
    {
        class DNode
        {
            public int key;
            public int value;
            public DNode next;
            public DNode prev;
        }

        private Dictionary<int, DNode> cache;
        private DNode head, tail;

        private int size;
        private int capacity;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            size = 0;
            cache = new Dictionary<int, DNode>();

            head = new DNode();
            tail = new DNode();
            head.next = tail;
            tail.prev = head;
        }

        private void addtohead(DNode node)
        {
            // Add a node to the right of the head
            node.prev = head;
            node.next = head.next;
            head.next.prev = node;
            head.next = node;
        }

        private void removeNode(DNode node)
        {
            // remove a node - connect its neighbouring nodes
            DNode prev = node.prev;
            DNode next = node.next;

            prev.next = next;
            next.prev = prev;
        }

        private  DNode poptail()
        {
            DNode tailnode = tail.prev;
            removeNode(tailnode);

            return tailnode;
        }

        private void moveToHead(DNode node)
        {
            removeNode(node);
            addtohead(node);
        }

        public void Put(int key, int value)
        {
            DNode node;

            if(cache.TryGetValue(key, out node))
            {
                node.value = value;
            } else
            {
                node = new DNode();
                node.key = key;
                node.value = value;
                cache.Add(key, node);
                addtohead(node);
                size++;

                if(size > capacity)
                {
                    DNode tailnode = poptail();
                    cache.Remove(tailnode.key);
                    size--;
                }
            }
        }

        public int Get(int key)
        {
            DNode node;

            if(cache.TryGetValue(key, out node))
            {
                moveToHead(node);
                return node.value;
            } else
            {
                return -1;
            }
        }

        // For testing only
        public void printall()
        {
            DNode node = head;
            node = head.next;

            while(node != tail)
            {
                Console.Write("" + node.value + " ");
                node = node.next;
            }

            Console.WriteLine();
        }
    }
}
