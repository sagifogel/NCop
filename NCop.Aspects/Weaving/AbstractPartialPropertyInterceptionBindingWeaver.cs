using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractPartialPropertyInterceptionBindingWeaver : AbstractPropertyInterceptionBindingWeaver
    {
        protected readonly IAspectExpression aspectExpression = null;
        protected IAspectWeavingSettings aspectWeavingSettings = null;
        protected readonly Core.Lib.Lazy<FieldInfo> lazyWeavedType = null;

        internal AbstractPartialPropertyInterceptionBindingWeaver(IAspectExpression aspectExpression, IPropertyAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
            : base(aspectDefinition, aspectWeavingSettings) {
            this.aspectExpression = aspectExpression;
        }
    }
}
