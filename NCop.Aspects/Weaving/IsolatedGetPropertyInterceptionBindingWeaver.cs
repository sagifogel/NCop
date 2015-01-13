using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class IsolatedGetPropertyInterceptionBindingWeaver : AbstractPropertyInterceptionBindingWeaver
    {
        internal IsolatedGetPropertyInterceptionBindingWeaver(IAspectExpression aspectExpression, IPropertyAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
            : base(aspectExpression, aspectDefinition, aspectWeavingSettings) {
        }

        protected override IAspectWeavingSettings GetAspectsWeavingSettings() {
            return aspectWeavingSettings.CloneWith(settings => {
                settings.LocalBuilderRepository = new LocalBuilderRepository();
            });
        }

        protected override FieldInfo WeaveType() {
            IAspectWeaver aspectWeaver = null;
            IBindingWeaver bindingWeaver = null;
            var aspectSettings = GetAspectsWeavingSettings();

            aspectWeaver = aspectExpression.Reduce(aspectSettings);
            bindingWeaver = new GetPropertyInterceptionBindingWeaver(aspectDefinition.Property, bindingSettings, aspectSettings, aspectWeaver);

            return bindingWeaver.Weave();
        }
    }
}
