using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class TNode
    {
        public Dictionary<char, TNode> children;
        public char item;
        public bool endOfWord;

        public TNode()
        {
            children = new Dictionary<char, TNode>();
            this.endOfWord = false;
        }
    }
}
