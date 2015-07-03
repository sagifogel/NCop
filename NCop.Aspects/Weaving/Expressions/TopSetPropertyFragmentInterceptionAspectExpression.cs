using NCop.Aspects.Aspects;
using System.Reflection;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class TopSetPropertyFragmentInterceptionAspectExpression : AbstractPartialPropertyFragmentAspectExpression
    {
        internal TopSetPropertyFragmentInterceptionAspectExpression(IAspectExpression aspectExpression, IPropertyAspectDefinition aspectDefinition, IBindingTypeReflectorBuilder propertyBuilder)
            : base(aspectExpression, propertyBuilder, aspectDefinition) {
        }

        protected override IAspectWeaver CreateWeaver(IAspectWeavingSettings aspectWeavingSettings, FieldInfo weavedType) {
            return new TopSetPropertyInterceptionAspectWeaver(aspectDefinition, aspectWeavingSettings, weavedType);
        }
    }
}
