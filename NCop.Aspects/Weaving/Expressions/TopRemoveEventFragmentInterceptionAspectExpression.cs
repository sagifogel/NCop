using NCop.Aspects.Aspects;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class TopRemoveEventFragmentInterceptionAspectExpression : AbstractEventFragmentAspectExpression
    {
        public TopRemoveEventFragmentInterceptionAspectExpression(IAspectExpression aspectExpression, IEventAspectDefinition aspectDefinition, IBindingTypeReflectorBuilder eventBuilder)
            : base(aspectExpression, eventBuilder, aspectDefinition) {
        }

        protected override IAspectWeaver CreateWeaver(IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType) {
            return new TopRemoveEventInterceptionAspectWeaver(aspectDefinition, aspectWeavingSettings, weavedType);
        }
    }
}
