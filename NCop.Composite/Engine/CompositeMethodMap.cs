using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Core;
using NCop.Core.Extensions;
using NCop.Aspects.Engine;
using NCop.Aspects.Aspects;

namespace NCop.Composite.Engine
{
    public class CompositeMethodMap : AbstractMemberMap<MethodInfo>, IHasAspectDefinitions
    {
        public CompositeMethodMap(Type contractType, Type implementationType, MethodInfo contractMethod, MethodInfo implementationMethod, IEnumerable<IAspectDefinition> aspectDefinitions)
            : base(contractType, implementationType, contractMethod, implementationMethod) {
            AspectDefinitions = aspectDefinitions;
            HasAspectDefinitions = !aspectDefinitions.IsNullOrEmpty();
        }

        public bool HasAspectDefinitions { get; private set; }
        public IEnumerable<IAspectDefinition> AspectDefinitions { get; private set; }
    }
}
