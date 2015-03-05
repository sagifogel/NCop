using NCop.Aspects.Aspects;
using NCop.Core;
using NCop.Core.Extensions;
using System;
using System.Reflection;

namespace NCop.Composite.Engine
{
    public class CompositeMethodMap : AbstractMemberMap<MethodInfo>, ICompositeMethodMap
    {
        public CompositeMethodMap(Type contractType, Type implementationType, MethodInfo contractMethod, MethodInfo implementationMethod, IAspectDefinitionCollection aspectDefinitions)
            : base(contractType, implementationType, contractMethod, implementationMethod) {
            AspectDefinitions = aspectDefinitions;
            HasAspectDefinitions = aspectDefinitions.IsNotNullOrEmpty();
        }

        public bool HasAspectDefinitions { get; private set; }
        
        public IAspectDefinitionCollection AspectDefinitions { get; private set; }
    }
}
