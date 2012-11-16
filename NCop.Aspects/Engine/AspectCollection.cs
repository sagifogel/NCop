using NCop.Core;
using NCop.Core.Aspects;
using System.Collections.Generic;

namespace NCop.Aspects.Engine
{
    public class AspectCollection : Collection<IAspect>, IAspectCollection
    {
        public AspectCollection(IEnumerable<IAspect> aspects) : base(aspects) { }
    }
}
