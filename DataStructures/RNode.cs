using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class RNode
    {
        public int val;
        public RNode next;
        public RNode random;

        public RNode(int v, RNode n, RNode r) {
            val = v;
            next = n;
            random = r;
        }

        public RNode()
        {
            val = 0;
            next = null;
            random = null;
        }

        public Dictionary<RNode, RNode> myMap = new Dictionary<RNode, RNode>();

        public RNode CopyRandomList(RNode head)
        {
            if (head == null) return null;

            RNode runner = head;
            RNode newNode = new RNode();
            newNode.val = runner.val;
            this.myMap[runner] = newNode;

            while (runner != null)
            {
                newNode.next = this.getClonedNode(runner.next);
                newNode.random = this.getClonedNode(runner.random);

                runner = runner.next;
                newNode = newNode.next;
            }


            return myMap[head];
        }

        public RNode getClonedNode(RNode node)
        {
            if (node == null) return null;

            if (this.myMap.ContainsKey(node))
            {
                return this.myMap[node];
            }
            else
            {
                this.myMap[node] = new RNode(node.val, null, null);
                return myMap[node];
            }
        }
    }
}
