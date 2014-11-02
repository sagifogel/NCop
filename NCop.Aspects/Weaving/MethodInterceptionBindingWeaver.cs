using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class MethodInterceptionBindingWeaver : AbstractMethodInterceptionBindingWeaver
    {
        internal MethodInterceptionBindingWeaver(IAspectMethodExpression aspectExpression, IAspectDefinition aspectDefinition, IAspectMethodWeavingSettings aspectWeavingSettings)
            : base(aspectExpression, aspectDefinition, aspectWeavingSettings) {
        }

        protected override IAspectMethodWeavingSettings GetAspectsWeavingSettings() {
            return aspectWeavingSettings;
        }
    }
}
