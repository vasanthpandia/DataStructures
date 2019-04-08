using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class TwoStackQueue<T>
    {
        Stack<T> stack1, stack2;

        public TwoStackQueue() {
            stack1 = new Stack<T>();
            stack2 = new Stack<T>();
        }

        public TwoStackQueue<T> Enqueue(T element)
        {
            while(stack1.Count != 0)
            {
                stack2.Push(stack1.Pop());
            }

            stack1.Push(element);

            while(stack2.Count != 0)
            {
                stack1.Push(stack2.Pop());
            }
            return this;
        }

        public T Dequeue()
        {
            if(stack1.Count == 0)
            {
                return default(T);
            }
            return stack1.Pop();
        }

    }
}
