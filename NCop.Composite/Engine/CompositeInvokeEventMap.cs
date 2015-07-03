using NCop.Aspects.Aspects;
using NCop.Core.Extensions;
using System;
using System.Reflection;

namespace NCop.Composite.Engine
{
    public class CompositeInvokeEventMap : AbstractCompositeFragmentEventMap, ICompositeInvokeEventMap
    {
        public CompositeInvokeEventMap(Type contractType, Type implementationType, EventInfo contractEvent, EventInfo implementationEvent, IAspectDefinitionCollection aspectDefinitions)
            : base(contractType, implementationType, contractEvent, implementationEvent, aspectDefinitions) {
            FragmentMethod = contractEvent.GetInvokeMethod();
        }

        public override void Accept(ICompositeEventMapVisitor visitor) {
            visitor.Visit(this);
        }
    }
}
