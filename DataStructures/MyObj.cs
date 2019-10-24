using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class MyObj
    {
        public int a { get; set; }
        public string b { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            return a.Equals((obj as MyObj).a) && b.Equals((obj as MyObj).b);
        }

    }
}
