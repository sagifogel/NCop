using System;
using System.Collections;
using System.Collections.Generic;

namespace NCop.Core.Lib
{
    public class Tuples<T1, T2, T3> : IEnumerable<Tuple<T1, T2, T3>>
    {
        protected IEnumerable<Tuple<T1, T2, T3>> values = null;

        public Tuples(IEnumerable<Tuple<T1, T2, T3>> tuples) {
            values = tuples;
        }

        public Tuples() { }

        public IEnumerator<Tuple<T1, T2, T3>> GetEnumerator() {
            return values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
