using System;
using System.Collections.Generic;
using System.Collections;

namespace NCop.Core.Lib
{
    public class Tuples<T1, T2> : IEnumerable<Tuple<T1, T2>>
    {
        protected IEnumerable<Tuple<T1, T2>> Values = null;

        public Tuples(IEnumerable<Tuple<T1, T2>> tuples) {
            Values = tuples;
        }

        public Tuples() { }

        public IEnumerator<Tuple<T1, T2>> GetEnumerator() {
            return Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
