using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;

namespace NCop.Aspects.Weaving
{
    internal class IsolatedPropertyInterceptionBindingWeaver : AbstractPropertyInterceptionBindingWeaver
    {
        internal IsolatedPropertyInterceptionBindingWeaver(IAspectMethodExpression aspectExpression, IPropertyAspectDefinition aspectDefinition, IAspectMethodWeavingSettings aspectWeavingSettings)
            : base(aspectExpression, aspectDefinition, aspectWeavingSettings) {
        }

        protected override IAspectMethodWeavingSettings GetAspectsWeavingSettings() {
            return aspectWeavingSettings.CloneToWith<AspectPropertyMethodWeavingSettingsImpl>(settings => {
                settings.LocalBuilderRepository = new LocalBuilderRepository();
                settings.PropertyInfoContract = aspectDefinition.PropertyInfoContract;
            });
        }
    }
}
