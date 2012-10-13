using NCop.Aspects.Engine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Pointcuts
{
    public class PointcutMatchCollection : IEnumerable<IPointcut>
    {
        private IEnumerable<IPointcut> _matches = null;

        public PointcutMatchCollection(IEnumerable<IPointcut> matches) {
            _matches = matches;
        }

        public IEnumerator<IPointcut> GetEnumerator() {
            return _matches.Where(p => !ReferenceEquals(p, null))
                           .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
