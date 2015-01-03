using NCop.Aspects.Aspects;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class TopExpressionGetPropertyInterceptionAspect : AbstractTopExpressionPropertyInterceptionAspect
    {
        internal TopExpressionGetPropertyInterceptionAspect(IAspectExpression aspectExpression, IPropertyAspectDefinition aspectDefinition = null)
            : base(aspectExpression, aspectDefinition) {
        }

        protected override IAspectWeaver CreateAspect(IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType) {
            return new TopGetPropertyInterceptionAspectWeaver(aspectDefinition, aspectWeavingSettings, weavedType);
        }
    }
}
