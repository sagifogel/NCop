using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class NestedMethodInterceptionBindingWeaver : MethodInterceptionBindingWeaver
    {
        internal NestedMethodInterceptionBindingWeaver(IAspectExpression aspectExpression, IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
            : base(aspectExpression, aspectDefinition, aspectWeavingSettings) {
        }
    }
}
