using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class BindingGetPropertyInterceptionAspectExpression : AbstractPartialAspectPropertyExpression
    {
        internal BindingGetPropertyInterceptionAspectExpression(IAspectExpression aspectExpression, IPropertyAspectDefinition aspectDefinition = null)
            : base(aspectExpression, aspectDefinition) {
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var clonedAspectWeavingSettings = aspectWeavingSettings.CloneWith(settings => {
                settings.LocalBuilderRepository = new LocalBuilderRepository();
            });

            var bindingWeaver = new IsolatedGetPropertyInterceptionBindingWeaver(aspectExpression, aspectDefinition, clonedAspectWeavingSettings);

            return new BindingGetPropertyInterceptionAspectWeaver(aspectDefinition, aspectWeavingSettings, bindingWeaver.WeavedType);
        }
    }
}
