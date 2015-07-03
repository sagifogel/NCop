using NCop.Aspects.Aspects;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class TopAddEventFragmentInterceptionAspectExpression : AbstractEventFragmentAspectExpression
    {
        public TopAddEventFragmentInterceptionAspectExpression(IAspectExpression aspectExpression, IEventAspectDefinition aspectDefinition, IBindingTypeReflectorBuilder eventBuilder)
            : base(aspectExpression, eventBuilder, aspectDefinition) {
        }

        protected override IAspectWeaver CreateWeaver(IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType) {
            return new TopAddEventInterceptionAspectWeaver(aspectDefinition, aspectWeavingSettings, weavedType);
        }
    }
}
