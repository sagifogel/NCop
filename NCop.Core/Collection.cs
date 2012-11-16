using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;
using System.Collections.ObjectModel;

namespace NCop.Core
{
    public class Collection<T> : System.Collections.ObjectModel.Collection<T>
    {
        public Collection() : base() { }

        public Collection(IEnumerable<T> source) {
            source.ForEach(e => {
                if (!ReferenceEquals(e, null)) {
                    this.Add(e);
                }
            });
        }

        public void AddRange(IEnumerable<T> source) {
            source.ForEach(e => Add(e));
        }
    }
}
