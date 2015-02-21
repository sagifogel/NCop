using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;

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
            var clonedSettings = aspectWeavingSettings.CloneWith(settings => {
                settings.LocalBuilderRepository = new LocalBuilderRepository();
            });

            return new TopSetPropertyInterceptionAspectWeaver(aspectDefinition, clonedSettings, bindingWeaver.WeavedType);
        }
    }
}
