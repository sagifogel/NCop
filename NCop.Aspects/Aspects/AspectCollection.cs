using NCop.Aspects.Aspects;
using NCop.Core.Lib;
using System.Collections.Generic;

namespace NCop.Aspects.Aspects
{
    public class AspectCollection : Collection<IAspect>, IAspectCollection
    {
        public AspectCollection(IEnumerable<IAspect> aspects) : base(aspects) { }
    }
}
