using NCop.Core.Aspects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    public class AdviceCollection : Collection<IAdvice>, IAdviceCollection
    {
        public AdviceCollection() : base() { }
        public AdviceCollection(IEnumerable<IAdvice> source) : base(source) { }
    }
}
