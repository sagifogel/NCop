using System;
using System.Collections;
using System.Collections.Generic;

namespace NCop.Core.Lib
{
    public class Tuples<T1, T2> : IEnumerable<Tuple<T1, T2>>
    {
        protected IEnumerable<Tuple<T1, T2>> values = null;

        public Tuples(IEnumerable<Tuple<T1, T2>> tuples) {
            values = tuples;
        }

        public Tuples() { }

        public IEnumerator<Tuple<T1, T2>> GetEnumerator() {
            return values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
