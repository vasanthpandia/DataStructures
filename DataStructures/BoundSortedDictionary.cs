using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Thanks to maxpushkarev [https://leetcode.com/maxpushkarev/] on leetcode for posting this on leetcode.
// Original Post => https://leetcode.com/problems/odd-even-jump/discuss/543112/Accepted-C-Solution
namespace DataStructures
{

    class ComparerDecorator<T> : IComparer<T>
    {
        private readonly IComparer<T> _comparer;
        public T LowerBound { get; private set; }
        public T UpperBound { get; private set; }

        private bool _resetLower = true;
        private bool _resetUpper = true;

        public ComparerDecorator(IComparer<T> comparer)
        {
            _comparer = comparer;
        }

        public void Reset()
        {
            _resetLower = true;
            _resetUpper = true;
        }


        public int Compare(T x, T y)
        {
            int cmp = _comparer.Compare(x, y);

            if(_resetLower)
            {
                LowerBound = y;
            }

            if(_resetUpper)
            {
                UpperBound = x;
            }

            if(cmp >= 0)
            {
                LowerBound = y;
                _resetLower = false;
            }

            if(cmp <= 0)
            {
                UpperBound = x;
                _resetUpper = false;
            }

            return cmp;
        }
    }


    class BoundSortedDictionary<TKey, TVal> : SortedDictionary<TKey, TVal>
    {
        private readonly ComparerDecorator<TKey> _comparerDecorator;

        public BoundSortedDictionary()
            : this(Comparer<TKey>.Default)
        {}

        public BoundSortedDictionary(IComparer<TKey> comparer) : base(new ComparerDecorator<TKey>(comparer))
        {
            _comparerDecorator = (ComparerDecorator<TKey>)this.Comparer;
        }

        public void findBounds(TKey key, out TKey lower, out TKey upper)
        {
            _comparerDecorator.Reset();
            var contains = this.ContainsKey(key);
            lower = _comparerDecorator.LowerBound;
            upper = _comparerDecorator.UpperBound;
        }
    } 
}