using NCop.Aspects.Aspects.Builders;
using NCop.Aspects.Engine;
using NCop.Core.Lib;
using System.Collections.Generic;

namespace NCop.Aspects.Aspects
{
    public class AspectBuilderCollection : Collection<IAspectBuilder>, IAspectBuilderCollection
    {
        public AspectBuilderCollection() : base() { }

        public AspectBuilderCollection(IEnumerable<IAspectBuilder> builders) : base(builders) { }
    }
}
