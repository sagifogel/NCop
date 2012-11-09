using NCop.Core.Aspects;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NCop.Aspects.Engine
{
    public class AspectCollection : Collection<IAspect>, IAspectCollection
    {
        public AspectCollection(IEnumerable<IAspect> aspects) : base(aspects) { }
    }
}
