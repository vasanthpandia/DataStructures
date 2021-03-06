﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    class BTNode : IComparable
    {
        private int data;
        private BTNode left, right;

        public BTNode(int a)
        {
            data = a;
            left = right = null;
        }

        public int Data()
        {
            return data;
        }

        public BTNode Data(int a)
        {
            this.data = a;
            return this;
        }

        public BTNode Left()
        {
            return left;
        }

        public BTNode Left(BTNode a)
        {
            this.left = a;
            return this;
        }

        public BTNode Left(int a)
        {
            this.left = new BTNode(a);
            return this;
        }

        public BTNode Right()
        {
            return right;
        }

        public BTNode Right(BTNode a)
        {
            this.right = a;
            return this;
        }

        public BTNode Right(int a)
        {
            this.right = new BTNode(a);
            return this;
        }

        public BTNode insert(int a)
        {
            if (a < data)
            {
                if (left == null)
                {
                    this.left = new BTNode(a);
                }
                else
                {
                    left.insert(a);
                }
            }
            else if (a > data)
            {
                if (right == null)
                {
                    this.right = new BTNode(a);
                }
                else
                {
                    right.insert(a);
                }
            }

            return this;
        }

        public void printInOrder()
        {
            if (this.left != null)
            {
                this.left.printInOrder();
            }
            Console.Write("" + this.data + " ");
            if (this.right != null)
            {
                this.right.printInOrder();
            }
        }

        public void printIterativePreorder()
        {
            BTNode root = this;

            Stack<BTNode> traversalStack = new Stack<BTNode>();

            while(true)
            {
                while(root != null)
                {
                    Console.WriteLine(root.Data());

                    traversalStack.Push(root);

                    root = root.Left();
                }

                if(traversalStack.Count() == 0)
                {
                    break;
                }

                root = traversalStack.Pop();

                root = root.Right();
            }
        }

        public void printIterativeInOrder()
        {
            BTNode root = this;

            Stack<BTNode> traversalStack = new Stack<BTNode>();

            while(true)
            {
                while(root != null)
                {
                    traversalStack.Push(root);

                    root = root.left;
                }

                if(traversalStack.Count() == 0)
                {
                    break;
                }

                root = traversalStack.Pop();

                Console.WriteLine(root.Data());

                root = root.Right();
            }
        }

        public void printIterativePostOrder2Stack()
        {
            BTNode root = this;
            Stack<BTNode> stack1 = new Stack<BTNode>();
            Stack<BTNode> stack2 = new Stack<BTNode>();

            stack1.Push(root);

            while(stack1.Count() != 0)
            {
                BTNode temp = stack1.Pop();

                if(temp.Left() != null)
                {
                    stack1.Push(temp.Left());
                }

                if(temp.Right() != null)
                {
                    stack1.Push(temp.Right());
                }

                stack2.Push(temp);
            }

            while(stack2.Count() != 0)
            {
                Console.WriteLine(stack2.Pop().Data());
            }
        }

        public void printIterativePostOrder()
        {
            BTNode root = this;
            Stack<BTNode> traversalStack = new Stack<BTNode>();

            traversalStack.Push(root);

            while(traversalStack.Count() != 0)
            {
                while(root != null)
                {
                    if(root.right != null)
                    {
                        traversalStack.Push(root.Right());
                    }

                    traversalStack.Push(root);

                    root = root.Left();
                }

                root = traversalStack.Pop();
                if(root.Right() != null &&  traversalStack.Count() != 0 && root.Right() == traversalStack.Peek())
                {
                    traversalStack.Pop();
                    traversalStack.Push(root);
                    root = root.Right();
                } else
                {
                    Console.WriteLine(root.Data());
                    root = null;
                }
            }
        }

        public void printIterativePostOrderSimple()
        {
            BTNode root = this;
            Stack<BTNode> traversalStack = new Stack<BTNode>();

            do
            {
                while (root != null)
                {
                    traversalStack.Push(root);
                    traversalStack.Push(root);

                    root = root.Left();
                }

                if (traversalStack.Count() == 0) break;

                root = traversalStack.Pop();

                if (traversalStack.Count() != 0 && traversalStack.Peek() == root)
                {
                    root = root.Right();
                }
                else
                {
                    Console.WriteLine(root.Data());
                    root = null;
                }
            } while (traversalStack.Count() != 0);
        }

        public List<int> ListInorder(List<int> inorder)
        {
            if (this.left != null)
            {
                this.left.ListInorder(inorder);
            }
            inorder.Add(this.data);
            if (this.right != null)
            {
                this.right.ListInorder(inorder);
            }

            return inorder;
        }

        public void printPreOrder()
        {
            Console.Write("" + this.data + " ");

            if (this.left != null)
            {
                this.left.printPreOrder();
            }

            if (this.right != null)
            {
                this.right.printPreOrder();
            }
        }

        public void printPostOrder()
        {
            if (this.left != null)
            {
                this.left.printPostOrder();
            }

            if (this.right != null)
            {
                this.right.printPostOrder();
            }

            Console.Write("" + this.data + " ");
        }


        /*Start of Static Methods*/

        public static int height(BTNode node)
        {
            if(node == null)
            {
                return 0;
            }

            int lheight = BTNode.height(node.Left());
            int rheight = BTNode.height(node.Right());

            int result_height = Math.Max(lheight, rheight) + 1;

            return result_height;
        }

        public static void printLevelOrder(BTNode node)
        {
            Queue<BTNode> q = new Queue<BTNode>();
            q.Enqueue(node);

            while(true)
            {
                int nodeCount = q.Count;
                if (nodeCount == 0) break;

                while (nodeCount > 0)
                {

                    BTNode n = q.Dequeue();
                    Console.Write($"{n.Data()} ");
                    if (n.Left() != null)
                    {
                        q.Enqueue(n.Left());
                    }
                    if (n.Right() != null)
                    {
                        q.Enqueue(n.Right());
                    }

                    nodeCount--;

                }
                Console.WriteLine();
            }

        }

        public IList<IList<int>> ZigzagLevelOrder(BTNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (root == null) return res;

            Queue<BTNode> currLevel = new Queue<BTNode>();


            bool reverse = false;
            currLevel.Enqueue(root);

            while (currLevel.Count > 0)
            {
                IList<int> level = new List<int>();

                int qsize = currLevel.Count;

                while (qsize > 0)
                {
                    BTNode n = currLevel.Dequeue();
                    qsize--;

                    if (reverse)
                    {
                        level.Insert(0, n.data);
                    }
                    else
                    {
                        level.Add(n.data);
                    }

                    if (n.left != null)
                    {
                        currLevel.Enqueue(n.left);
                    }

                    if (n.right != null)
                    {
                        currLevel.Enqueue(n.right);
                    }
                }

                if (qsize == 0)
                {
                    reverse = !reverse;
                }

                res.Add(level);
            }

            return res;

        }

        public static void printLevelOrderZigZag(BTNode node) // 2 Stacks
        {
            Stack<BTNode> currentlevel = new Stack<BTNode>();
            Stack<BTNode> nextLevel = new Stack<BTNode>();

            currentlevel.Push(node);
            bool righttoleft = false;

            while(currentlevel.Count > 0)
            {
                BTNode n = currentlevel.Pop();

                Console.Write("" + n.Data() + " ");

                if(righttoleft)
                {
                    if(n.Right() != null)
                    {
                        nextLevel.Push(n.Right());
                    }

                    if(n.Left() != null)
                    {
                        nextLevel.Push(n.Left());
                    }
                } else
                {
                    if (n.Left() != null)
                    {
                        nextLevel.Push(n.Left());
                    }

                    if (n.Right() != null)
                    {
                        nextLevel.Push(n.Right());
                    }
                }

                if(currentlevel.Count == 0)
                {
                    righttoleft = !righttoleft;
                    Stack<BTNode> temp = nextLevel;
                    nextLevel = currentlevel;
                    currentlevel = temp;
                    Console.WriteLine();
                }

            }
        }

        public static void printReverseLevelOrder(BTNode node)
        {
            Queue<BTNode> q = new Queue<BTNode>();
            Stack<BTNode> s = new Stack<BTNode>();

            q.Enqueue(node);

            while(true)
            {
                int nodeCount = q.Count;
                if (nodeCount == 0) break;

                while(nodeCount > 0)
                {
                    BTNode n = q.Dequeue();

                    s.Push(n);

                    if(n.Right() != null)
                    {
                        q.Enqueue(n.Right());
                    }
                    if(n.Left() != null)
                    {
                        q.Enqueue(n.Left());
                    }

                    nodeCount--;
                }
            }

            while(s.Count > 0)
            {
                BTNode n = s.Pop();

                Console.Write($"{n.Data()} ");
            }
        }

        public static void printLeftBoundary(BTNode node)
        {
            if(node != null)
            {
                if(node.Left() != null)
                {
                    printLeftBoundary(node.Left());

                    Console.WriteLine(node.Data());
                } else if(node.Right() != null)
                {
                    printLeftBoundary(node.Right());

                    Console.WriteLine(node.Data());
                }
            }
        }

        public static void printRightBoundary(BTNode node)
        {
            if(node != null)
            {
                if(node.Right() != null)
                {
                    Console.WriteLine(node.Data());

                    printRightBoundary(node.Right());
                } else if(node.Left() != null)
                {
                    Console.WriteLine(node.Data());

                    printRightBoundary(node.Left());
                }
            }
        }

        public static void printLeaves(BTNode node)
        {
            if(node != null)
            {
                printLeaves(node.Left());

                if(node.Left() == null && node.Right() == null)
                {
                    Console.WriteLine(node.Data());
                }

                printLeaves(node.Right());
            }
        }

        public static Queue<BTNode> collectLeavesQueue(BTNode node, Queue<BTNode> btqueue)
        {
            if(node != null)
            {
                btqueue = collectLeavesQueue(node.Left(), btqueue);

                if(node.Left() == null && node.Right() == null)
                {
                    btqueue.Enqueue(node);
                }

                btqueue = collectLeavesQueue(node.Right(), btqueue);
            }

            return btqueue;
        }

        public static void printBoundary(BTNode node)
        {
            if(node != null)
            {
                Console.WriteLine(node.Data());

                printLeftBoundary(node.Left());

                printLeaves(node.Left());

                printLeaves(node.Right());

                printRightBoundary(node.Right());
            }
        }

        public static int lca(BTNode node, int num1, int num2)
        {
            if(node != null)
            {
                if ((num1 < node.Data() && num2 > node.Data()) || ((num1 > node.Data() && num2 < node.Data())))
                {
                    return node.Data();
                }
                else
                {
                    if (num1 < node.Data() && num2 < node.Data())
                    {
                        return lca(node.Left(), num1, num2);
                    }
                    else
                    {
                        return lca(node.Right(), num1, num2);
                    }
                }
            } else
            {
                return -1;
            }
           
        }

        public static BTNode lcabt(BTNode node, BTNode node1, BTNode node2)
        {
            if(node == null)
            {
                return null;
            }

            if(node.Data() == node1.Data() || node.Data() == node2.Data())
            {
                return node;
            }

            BTNode left = lcabt(node.left, node1, node2);
            BTNode right = lcabt(node.Right(), node1, node2);

            if(left != null && right != null)
            {
                return node;
            }

            if(left == null && right == null)
            {
                return null;
            }

            return left != null ? left : right;
        }

        public static int toSumTree(BTNode node)
        {
            if(node == null)
            {
                return 0;
            }

            int old_val = node.Data();

            int new_val = toSumTree(node.Left()) + toSumTree(node.Right());

            node.Data(new_val);

            return (old_val + new_val);
        }

        public static bool isBST(BTNode node, BTNode l, BTNode r)
        {
            if(node == null)
            {
                return true;
            }

            if(l != null && node.Data() < l.Data())
            {
                return false;
            }

            if(r != null && node.Data() > r.Data())
            {
                return false;
            }

            return isBST(node.Left(), l, node) && isBST(node.Right(), node, r);
        }

        public static bool isBSTPrev(BTNode node, List<BTNode> prev)
        {
            if (node != null)
            {
                if(!isBSTPrev(node.Left(), prev))
                    return false;

                if(prev.Count > 0)
                {
                    Console.WriteLine("Value of current node :" + node.Data() + " -- Value of prev node : " + prev[prev.Count - 1].Data());
                }

                if (prev.Count > 0 && node.Data() <= prev[prev.Count - 1].Data())
                {
                    return false;
                }

                prev.Add(node);

                return isBSTPrev(node.Right(), prev);
            }

            return true;
            
        }

        public static bool isBSTUtil(BTNode node)
        {
            List<BTNode> prev = new List<BTNode>();

            return isBSTPrev(node, prev);
        }

        // LeetCode Solution - Gives Wrong Answer
        public static bool isBSTWithInorder(BTNode node)
        {
            if(node == null)
            {
                return true;
            }

            int max = -int.MaxValue;

            Stack<BTNode> inorderStack = new Stack<BTNode>();

            do
            {
                while (node != null)
                {
                    inorderStack.Push(node);

                    node = node.Left();
                }

                node = inorderStack.Pop();

                Console.WriteLine("Node Value : " + node.Data() + " -- Max Value : " + max);

                if(node.Data() <= max)
                {
                    return false;
                }

                max = node.Data();
                node = node.Right();

            } while (inorderStack.Count != 0 || node != null);

            return true;            
        }

        public static BTNode deleteNode(BTNode node, int key)
        {
            if(node == null)
            {
                return node;
            }

            if(key < node.Data())
            {
                return deleteNode(node.Left(), key);
            } else if(node.Data() < key)
            {
                return deleteNode(node.Right(), key);
            } else
            {
                if(node.Left() == null)
                {
                    return node.Right();
                } else if(node.Right() == null)
                {
                    return node.Left();
                }

                int temp = node.Data();

                BTNode min = minNode(node.Right());

                node.Data(min.Data());

                BTNode deleted = deleteNode(node.Right(), min.Data());
                min.Data(temp);
            }

            return node;
        }

        public static BTNode minNode(BTNode node)
        {
            while(node.Left() != null)
            {
                node = node.Left();
            }

            return node;
        }

        public int CompareTo(object obj)
        {
            int result;

            if (data > ((BTNode)obj).data)
            {
                result = 1;
            }
            else if (data < ((BTNode)obj).data)
            {
                result = -1;
            }
            else
            {
                result = 0;
            }

            return result;
        }

        public int KthSmallest(BTNode root, int k)
        {
            Stack<BTNode> st = new Stack<BTNode>();

            BTNode tn = root;
            int res = 0, count;
            count = 0;

            do
            {
                st.Push(tn);
                tn = tn.left;
            } while (tn != null);

            while (st.Count > 0)
            {
                tn = st.Pop();
                count++;
                if (count == k)
                {
                    res = tn.data;
                    break;
                }
                if (tn.right != null)
                {
                    tn = tn.right;
                    while (tn != null)
                    {
                        st.Push(tn);
                        tn = tn.left;
                    }
                }
            }
            return tn.data;
        }

        public int max_sum = int.MinValue;
        public int max_gain(BTNode root)
        {
            if (root == null) return 0;

            int nodesum = root.data;

            int leftsum = Math.Max(max_gain(root.left), 0);
            int rightsum = Math.Max(max_gain(root.right), 0);

            int totalsum = leftsum + nodesum + rightsum;
            max_sum = Math.Max(max_sum, totalsum);

            return root.data + Math.Max(leftsum, rightsum);
        }

        public int MaxPathSum(BTNode root)
        {
            max_gain(root);
            return max_sum;
        }
    }
}
