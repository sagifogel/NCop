using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class TopGetPropertyFragmentInterceptionAspectExpression : AbstractPartialAspectPropertyExpression
    {
        private readonly IBindingTypeReflectorBuilder propertyBuilder = null;

        internal TopGetPropertyFragmentInterceptionAspectExpression(IAspectExpression aspectExpression, IPropertyAspectDefinition aspectDefinition, IBindingTypeReflectorBuilder propertyBuilder)
            : base(aspectExpression, aspectDefinition) {
            this.propertyBuilder = propertyBuilder;
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var bindingWeaver = propertyBuilder.Build(aspectWeavingSettings);

            return new TopGetPropertyInterceptionAspectWeaver(aspectDefinition, aspectWeavingSettings, bindingWeaver.WeavedType);
        }
    }
}