using NCop.Aspects.Aspects;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class TopExpressionSetPropertyInterceptionAspect : AbstractTopExpressionPropertyInterceptionAspect
    {
        internal TopExpressionSetPropertyInterceptionAspect(IAspectMethodExpression aspectExpression, IPropertyAspectDefinition aspectDefinition = null)
            : base(aspectExpression, aspectDefinition) {
        }

        protected override IAspectWeaver CreateAspect(IAspectDefinition aspectDefinition, IAspectPropertyMethodWeavingSettings aspectWeavingSettings, FieldInfo weavedType) {
            return new TopSetPropertyInterceptionAspectWeaver(aspectDefinition, aspectWeavingSettings, weavedType);
        }
    }
}
