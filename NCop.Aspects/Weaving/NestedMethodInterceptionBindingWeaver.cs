using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class NestedMethodInterceptionBindingWeaver : MethodInterceptionBindingWeaver
    {
        internal NestedMethodInterceptionBindingWeaver(IAspectMethodExpression aspectExpression, IAspectDefinition aspectDefinition, IAspectMethodWeavingSettings aspectWeavingSettings)
            : base(aspectExpression, aspectDefinition, aspectWeavingSettings) {
        }
    }
}
