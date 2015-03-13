using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;

namespace NCop.Aspects.Weaving
{
    internal class NestedMethodInterceptionBindingWeaver : AbstractMethodInterceptionBindingWeaver
    {
        internal NestedMethodInterceptionBindingWeaver(IAspectExpression aspectExpression, IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
            : base(aspectExpression, aspectDefinition, aspectWeavingSettings) {
        }

        protected override IAspectWeavingSettings GetAspectsWeavingSettings() {
            return aspectWeavingSettings;
        }
    }
}
