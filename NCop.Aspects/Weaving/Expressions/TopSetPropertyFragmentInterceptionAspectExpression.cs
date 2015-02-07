using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class TopSetPropertyFragmentInterceptionAspectExpression : AbstractPartialAspectPropertyExpression
    {
        private readonly IBindingTypeReflectorBuilder propertyBuilder = null;

        internal TopSetPropertyFragmentInterceptionAspectExpression(IAspectExpression aspectExpression, IPropertyAspectDefinition aspectDefinition, IBindingTypeReflectorBuilder propertyBuilder)
            : base(aspectExpression, aspectDefinition) {
            this.propertyBuilder = propertyBuilder;
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var bindingWeaver = propertyBuilder.Build(aspectWeavingSettings);

            return new TopSetPropertyInterceptionAspectWeaver(aspectDefinition, aspectWeavingSettings, bindingWeaver.WeavedType);
        }
    }
}
