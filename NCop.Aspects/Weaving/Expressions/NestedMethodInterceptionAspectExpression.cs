using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class NestedMethodInterceptionAspectExpression : AbstractAspectExpression
    {
        private readonly IAspectDefinition previousAspectDefinition = null;

        internal NestedMethodInterceptionAspectExpression(IAspectExpression aspectExpression, IAspectDefinition aspectDefinition, IAspectDefinition previousAspectDefinition)
            : base(aspectExpression, aspectDefinition) {
            this.previousAspectDefinition = previousAspectDefinition;
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var bindingTypeReflector = aspectExpression.Reduce(aspectWeavingSettings) as IBindingTypeReflector;
            var previousAspectArgsType = previousAspectDefinition.ToAspectArgumentImpl();

            return new NestedMethodInterceptionAspectWeaver(previousAspectArgsType, aspectDefinition, aspectWeavingSettings, bindingTypeReflector.WeavedType);
        }
    }
}