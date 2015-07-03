using NCop.Aspects.Aspects;
using System;
using System.Reflection;

namespace NCop.Composite.Engine
{
    public abstract class AbstractCompositeFragmentEventMap : AbstractCompositeMap<EventInfo>, ICompositeEventFragmentMap
    {
        internal AbstractCompositeFragmentEventMap(Type contractType, Type implementationType, EventInfo contractEvent, EventInfo implementationEvent, IAspectDefinitionCollection aspectDefinitions)
            : base(contractType, implementationType, contractEvent, implementationEvent, aspectDefinitions) {
        }

        public abstract void Accept(ICompositeEventMapVisitor visitor);
    }
}