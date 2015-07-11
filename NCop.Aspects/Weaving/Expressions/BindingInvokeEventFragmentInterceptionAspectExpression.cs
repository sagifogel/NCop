using System.Reflection;
using NCop.Aspects.Aspects;
using System;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingInvokeEventFragmentInterceptionAspectExpression : AbstractEventFragmentAspectExpression
    {
        public BindingInvokeEventFragmentInterceptionAspectExpression(IAspectExpression aspectExpression, IEventAspectDefinition aspectDefinition, IBindingTypeReflectorBuilder eventBuilder)
            : base(aspectExpression, eventBuilder, aspectDefinition) {
        }

        protected override IAspectWeaver CreateWeaver(IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType) {
            return new BindingInvokeEventInterceptionAspectWeaver(aspectDefinition, aspectWeavingSettings, weavedType);
        }
    }
}
