using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Interval
    {
        public int start { get; set; }
        public int end { get; set; }

        public Interval(int start, int end)
        {
            this.start = start;
            this.end = end;
        }

        public bool Contains(int x)
        {
            return (start <= x) && (end >= x);
        }

        public bool IsValid()
        {
            return (start <= end);
        }

        public override string ToString()
        {
            return "" + start + " : " + end;
        }

        public bool IsInsideRange(Interval r)
        {
            return (start > r.start) && (end < r.end);
        }

        public bool ContainsRange(Interval r)
        {
            return (start < r.start) && (end > r.end);
        }
    }
}
