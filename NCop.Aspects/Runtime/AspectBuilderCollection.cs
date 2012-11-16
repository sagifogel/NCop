using NCop.Aspects.Engine;
using NCop.Core;
using NCop.Core.Engine;
using System.Collections.Generic;

namespace NCop.Aspects.Runtime
{
    public class AspectBuilderCollection : Collection<IAspectBuilder>, IAspectBuilderCollection
    {
        public AspectBuilderCollection() : base() { }

        public AspectBuilderCollection(IEnumerable<IAspectBuilder> builders) : base(builders) { }
    }
}
