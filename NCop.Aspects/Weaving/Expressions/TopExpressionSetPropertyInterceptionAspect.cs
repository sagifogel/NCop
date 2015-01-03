using NCop.Aspects.Aspects;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class TopExpressionSetPropertyInterceptionAspect : AbstractTopExpressionPropertyInterceptionAspect
    {
        internal TopExpressionSetPropertyInterceptionAspect(IAspectExpression aspectExpression, IPropertyAspectDefinition aspectDefinition = null)
            : base(aspectExpression, aspectDefinition) {
        }

        protected override IAspectWeaver CreateAspect(IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType) {
            return new TopSetPropertyInterceptionAspectWeaver(aspectDefinition, aspectWeavingSettings, weavedType);
        }
    }
}
