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
            var previousAspectArgsType = previousAspectDefinition.ToAspectArgumentImpl();
            var bindingWeaver = new MethodInterceptionBindingWeaver(aspectExpression, aspectDefinition, aspectWeavingSettings);

            return new NestedMethodInterceptionAspectWeaver(previousAspectArgsType, aspectDefinition, aspectWeavingSettings, bindingWeaver.WeavedType);
        }
    }
}