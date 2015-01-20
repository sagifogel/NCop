using NCop.Core.Lib;
using NCop.Core.Extensions;
using System.Collections.Generic;

namespace NCop.Aspects.Aspects
{
    public class AspectDefinitionCollection : Collection<IAspectDefinition>, IAspectDefinitionCollection
    {
        public AspectDefinitionCollection(IEnumerable<IAspectDefinition> aspectDefinitions)
            : base(aspectDefinitions) {
        }
    }
}
