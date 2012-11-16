using NCop.Aspects.Engine;
using NCop.Core;
using NCop.Core.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Aspects
{
    public class AspectDefinitionCollection : Collection<IAspectDefinition>, IAspectDefinitionCollection
    {
        public AspectDefinitionCollection()
            : base() { }
        
        public AspectDefinitionCollection(IEnumerable<IAspectDefinition> aspects)
            : base(aspects) { }
    }
}
