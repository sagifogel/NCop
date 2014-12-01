using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;

namespace NCop.Aspects.Weaving
{
    internal class IsolatedPropertyInterceptionBindingWeaver : AbstractPropertyInterceptionBindingWeaver
    {
        internal IsolatedPropertyInterceptionBindingWeaver(IAspectMethodExpression aspectExpression, IAspectDefinition aspectDefinition, IAspectMethodWeavingSettings aspectWeavingSettings)
            : base(aspectExpression, aspectDefinition, aspectWeavingSettings) {
        }

        protected override IAspectMethodWeavingSettings GetAspectsWeavingSettings() {
            return aspectWeavingSettings.CloneWith(settings => {
                settings.LocalBuilderRepository = new LocalBuilderRepository();
            });
        }
    }
}
