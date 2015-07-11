using NCop.Aspects.Aspects;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingRemoveEventFragmentInterceptionAspectExpression : AbstractEventFragmentAspectExpression
    {
        public BindingRemoveEventFragmentInterceptionAspectExpression(IAspectExpression aspectExpression, IEventAspectDefinition aspectDefinition, IBindingTypeReflectorBuilder eventBuilder)
            : base(aspectExpression, eventBuilder, aspectDefinition) {
        }

        protected override IAspectWeaver CreateWeaver(IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType) {
            return new BindingRemoveEventInterceptionAspectWeaver(aspectDefinition, aspectWeavingSettings, weavedType);
        }
    }
}
