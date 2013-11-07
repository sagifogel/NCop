using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;
using mscorlib = System.Collections.ObjectModel;

namespace NCop.Core.Lib
{
    public class Collection<T> : mscorlib.Collection<T>
    {
        public Collection() : base() { }

        public Collection(IEnumerable<T> source) {
            source.ForEach(e => {
                Add(e);
            });
        }

        public void AddRange(IEnumerable<T> source) {
            source.ForEach(e => Add(e));
        }
    }
}
