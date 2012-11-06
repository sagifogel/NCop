using NCop.Aspects.Engine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Runtime
{
    public class AspectBuilderCollection : Collection<IAspectBuilder>, IAspectBuilderCollection
    {
        public AspectBuilderCollection() : base() { }

        public AspectBuilderCollection(IEnumerable<IAspectBuilder> builders) : base(builders) { }
    }
}
