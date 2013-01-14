using System;
using System.Collections.Generic;
using System.Collections;

namespace NCop.Core
{
	public class Tuples<T1, T2> : IEnumerable<Tuple<T1, T2>>
	{
		private readonly IEnumerable<Tuple<T1, T2>> _tuples = null;

		public Tuples(IEnumerable<Tuple<T1, T2>> tuples) {
			_tuples = tuples;
		}

		public IEnumerator<Tuple<T1, T2>> GetEnumerator() {
			return _tuples.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}
}
