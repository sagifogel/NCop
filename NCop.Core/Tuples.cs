using System;
using System.Collections.Generic;
using System.Collections;

namespace NCop.Core
{
    public class Tuples<T1, T2> : IEnumerable<Tuple<T1, T2>>
    {
        protected IEnumerable<Tuple<T1, T2>> Value = null;

        public Tuples(IEnumerable<Tuple<T1, T2>> tuples) {
            Value = tuples;
        }

        public Tuples() { }

        public IEnumerator<Tuple<T1, T2>> GetEnumerator() {
            return Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
