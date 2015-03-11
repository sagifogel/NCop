using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving.Expressions
{
    internal class TopSetPropertyInterceptionAspectExpression : AbstractPartialAspectPropertyExpression
    {
        internal TopSetPropertyInterceptionAspectExpression(IAspectExpression aspectExpression, IPropertyAspectDefinition aspectDefinition = null)
            : base(aspectExpression, aspectDefinition) {
        }

        public override IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings) {
            var clonedAspectWeavingSettings = aspectWeavingSettings.CloneWith(settings => {
                settings.LocalBuilderRepository = new LocalBuilderRepository();
            });

            var bindingWeaver = new IsolatedSetPropertyInterceptionBindingWeaver(aspectExpression, aspectDefinition, clonedAspectWeavingSettings);

            return new TopSetPropertyInterceptionAspectWeaver(aspectDefinition, clonedAspectWeavingSettings, bindingWeaver.WeavedType);
        }
    }
}
