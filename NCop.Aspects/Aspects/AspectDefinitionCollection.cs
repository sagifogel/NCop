using NCop.Core.Lib;
using System.Collections.Generic;

namespace NCop.Aspects.Aspects
{
    public class AspectDefinitionCollection : Collection<IAspectDefinition>, IAspectDefinitionCollection
    {
        public AspectDefinitionCollection()
            : base() {
        }

        public AspectDefinitionCollection(IEnumerable<IAspectDefinition> aspects)
            : base(aspects) {
        }
    }
}
