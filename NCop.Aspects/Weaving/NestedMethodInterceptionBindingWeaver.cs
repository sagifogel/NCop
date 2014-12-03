using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;

namespace NCop.Aspects.Weaving
{
    internal class NestedMethodInterceptionBindingWeaver : AbstractMethodInterceptionBindingWeaver
    {
        internal NestedMethodInterceptionBindingWeaver(IAspectMethodExpression aspectExpression, IAspectDefinition aspectDefinition, IAspectMethodWeavingSettings aspectWeavingSettings)
            : base(aspectExpression, aspectDefinition, aspectWeavingSettings) {
        }

        protected override IAspectMethodWeavingSettings GetAspectsWeavingSettings() {
            return aspectWeavingSettings;
        }
    }
}
