using NCop.Aspects.Aspects;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingGetPropertyFragmentInterceptionAspectExpression : AbstractPartialPropertyFragmentAspectExpression
    {
        internal BindingGetPropertyFragmentInterceptionAspectExpression(IAspectExpression aspectExpression, IPropertyAspectDefinition aspectDefinition, IBindingTypeReflectorBuilder propertyBuilder)
            : base(aspectExpression, propertyBuilder, aspectDefinition) {
        }

        protected override IAspectWeaver CreateWeaver(IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType) {
            return new BindingGetPropertyInterceptionAspectWeaver(aspectDefinition, aspectWeavingSettings, weavedType);
        }
    }
}
