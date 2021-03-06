public class Solution
    {
        private class ComparerDecorator<T> : IComparer<T>
        {
            private readonly IComparer<T> _comparer;

            public T LowerBound { get; private set; }
            public T UpperBound { get; private set; }

            private bool _resetLower = true;
            private bool _resetUpper = true;

            public void Reset()
            {
                _resetLower = true;
                _resetUpper = true;
            }

            public ComparerDecorator(IComparer<T> comparer)
            {
                _comparer = comparer;
            }

            public int Compare(T x, T y)
            {
                int cmp = _comparer.Compare(x, y);

                if (_resetLower)
                {
                    LowerBound = y;
                }

                if (_resetUpper)
                {
                    UpperBound = y;
                }

                if (cmp >= 0)
                {
                    LowerBound = y;
                    _resetLower = false;
                }

                if (cmp <= 0)
                {
                    UpperBound = y;
                    _resetUpper = false;
                }

                return cmp;
            }
        }

        private class BoundSortedDictionary<TKey, TVal> : SortedDictionary<TKey, TVal>
        {
            private readonly ComparerDecorator<TKey> _comparerDecorator;

            public BoundSortedDictionary()
                : this(Comparer<TKey>.Default)
            {
            }

            public BoundSortedDictionary(IComparer<TKey> comparer)
                : base(new ComparerDecorator<TKey>(comparer))
            {
                _comparerDecorator = (ComparerDecorator<TKey>)this.Comparer;
            }

            public void FindBounds(TKey key, out TKey lower, out TKey upper)
            {
                _comparerDecorator.Reset();
                var contains = this.ContainsKey(key);
                lower = _comparerDecorator.LowerBound;
                upper = _comparerDecorator.UpperBound;
            }
        }

        public int OddEvenJumps(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            if (nums.Length == 1)
            {
                return 1;
            }

            int?[,] evenOddJumps = new int?[nums.Length - 1, 2];

            BoundSortedDictionary<int, int> val2Index = new BoundSortedDictionary<int, int>();
            val2Index.Add(nums[nums.Length - 1], nums.Length - 1);

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                val2Index.FindBounds(nums[i], out int lower, out int upper);

                if (upper >= nums[i])
                {
                    evenOddJumps[i, 1] = val2Index[upper];
                }

                if (lower <= nums[i])
                {
                    evenOddJumps[i, 0] = val2Index[lower];
                }

                val2Index[nums[i]] = i;
            }

            int res = 1;

            bool[,] dp = new bool[nums.Length - 1,2];

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (!evenOddJumps[i, j].HasValue)
                    {
                        continue;
                    }

                    if (evenOddJumps[i, j] == nums.Length - 1)
                    {
                        dp[i, j] = true;
                        continue;
                    }

                    dp[i, j] = dp[evenOddJumps[i, j].Value, (j + 1) % 2];
                }
            }

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (dp[i, 1])
                {
                    res++;
                }
            }

            return res;
        }
    }
