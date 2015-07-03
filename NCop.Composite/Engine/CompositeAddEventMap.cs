using NCop.Aspects.Aspects;
using System;
using System.Reflection;

namespace NCop.Composite.Engine
{
    public class CompositeAddEventMap : AbstractCompositeFragmentEventMap, ICompositeAddEventMap
    {
        public CompositeAddEventMap(Type contractType, Type implementationType, EventInfo contractEvent, EventInfo implementationEvent, IAspectDefinitionCollection aspectDefinitions)
            : base(contractType, implementationType, contractEvent, implementationEvent, aspectDefinitions) {
            FragmentMethod = contractEvent.GetAddMethod();
        }

        public override void Accept(ICompositeEventMapVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
