﻿using NCop.Core.Lib;
using System.Collections.Generic;

namespace NCop.Aspects.Aspects
{
    public class AspectDefinitionCollection : Collection<IAspectDefinition>, IAspectDefinitionCollection
    {
        public AspectDefinitionCollection() {
        }

        public AspectDefinitionCollection(IEnumerable<IAspectDefinition> aspectDefinitions)
            : base(aspectDefinitions) {
        }
    }
}
