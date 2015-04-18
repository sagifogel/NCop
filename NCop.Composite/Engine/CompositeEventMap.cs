using NCop.Aspects.Aspects;
using NCop.Core;
using NCop.Core.Extensions;
using System;
using System.Reflection;

namespace NCop.Composite.Engine
{
    public class CompositeEventMap : AbstractMemberMap<EventInfo>, ICompositeEventMap
    {
        public CompositeEventMap(Type contractType, Type implementationType, EventInfo contractEvent, EventInfo implementationEvent, IAspectDefinitionCollection aspectDefinitions)
            : base(contractType, implementationType, contractEvent, implementationEvent) {
            AspectDefinitions = aspectDefinitions;
            HasAspectDefinitions = aspectDefinitions.IsNotNullOrEmpty();
        }

        public bool HasAspectDefinitions { get; private set; }

        public IAspectDefinitionCollection AspectDefinitions { get; private set; }
    }
}
