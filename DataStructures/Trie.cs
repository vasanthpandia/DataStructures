using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Trie
    {
        private readonly TNode root;

        public Trie()
        {
            root = new TNode();
        }

        public void insert(string[] words)
        {
            foreach (string word in words)
                insert(word);
        }

        public void insert(string s)
        {
            insert(s.ToCharArray());
        }

        public void insert(char[] s) // Iterative
        {
            TNode current = root;
            foreach(char c in s)
            {
                TNode node;
                current.children.TryGetValue(c, out node);
                if(node == null)
                {
                    node = new TNode();
                    current.children[c] = node;
                }
                current = node;
            }
            current.endOfWord = true;
        }

        public void insertRecursive(string word)
        {
            insertRecursive(root, word, 0);
        }

        public void insertRecursive(TNode current, string word, int index)
        {
            if(index == word.Length)
            {
                current.endOfWord = true;
                return;
            }

            TNode node;
            current.children.TryGetValue(word[index], out node);
            if (node == null)
            {
                node = new TNode();
                current.children[word[index]] = node;
            }

            insertRecursive(node, word, index + 1);
        }

        public bool searchRecursive(string word)
        {
            return searchRecursive(root, word, 0);
        }

        public bool searchRecursive(TNode current, string word, int index)
        {
            if (index == word.Length)
            {
                return current.endOfWord;
            }

            TNode node;
            current.children.TryGetValue(word[index], out node);

            if (node == null) return false;

            return searchRecursive(node, word, index + 1);
        }

        public bool search(string word)
        {
            TNode current = root;

            foreach(char c in word.ToCharArray())
            {
                TNode node;
                current.children.TryGetValue(c, out node);

                if(node == null)
                {
                    return false;
                }

                current = node;
            }

            return current.endOfWord;
        }
    }
}
