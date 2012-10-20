using NCop.Aspects.Engine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;

namespace NCop.Aspects.Pointcuts
{
    public class PointcutCollection : IPointcutCollection
    {
        private List<IPointcut> _matches = null;

        public PointcutCollection(IEnumerable<IPointcut> matches) {
            _matches = matches.ToList(p => !ReferenceEquals(p, null));
        }

        public IEnumerator<IPointcut> GetEnumerator() {
            return _matches.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public int Count {
            get {
                return _matches.Count;
            }
        }
    }
}
