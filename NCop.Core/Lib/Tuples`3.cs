using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Lib
{
    public class Tuples<T1, T2, T3> : IEnumerable<Tuple<T1, T2, T3>>
    {
        protected IEnumerable<Tuple<T1, T2, T3>> Values = null;

        public Tuples(IEnumerable<Tuple<T1, T2, T3>> tuples) {
            Values = tuples;
        }

        public Tuples() { }

        public IEnumerator<Tuple<T1, T2, T3>> GetEnumerator() {
            return Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
