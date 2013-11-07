using NCop.Core.Lib;
using System.Collections.Generic;

namespace NCop.Aspects.Advices
{
    public class AdviceCollection : Collection<IAdvice>, IAdviceCollection
    {
        public AdviceCollection() : base() { }
        public AdviceCollection(IEnumerable<IAdvice> source) : base(source) { }
    }
}
