using NCop.Core.Extensions;
using System.Collections.Generic;
using mscorlib = System.Collections.ObjectModel;

namespace NCop.Core.Lib
{
    public class Collection<T> : mscorlib.Collection<T>
    {
        public Collection() {
        }

        public Collection(IEnumerable<T> source) {
            AddRange(source);
        }

        public void AddRange(IEnumerable<T> source) {
            source.ForEach(Add);
        }
    }
}
