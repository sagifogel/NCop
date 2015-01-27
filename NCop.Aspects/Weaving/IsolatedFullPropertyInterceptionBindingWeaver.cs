using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class IsolatedFullPropertyInterceptionBindingWeaver : AbstractPropertyInterceptionBindingWeaver
    {
        private readonly IAspectExpression getAspectExpression = null;
        private readonly IAspectExpression setAspectExpression = null;

        internal IsolatedFullPropertyInterceptionBindingWeaver(IAspectExpression getAspectExpression, IAspectExpression setAspectExpression, IPropertyAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
            : base(aspectDefinition, aspectWeavingSettings) {
            this.getAspectExpression = getAspectExpression;
            this.setAspectExpression = setAspectExpression;
        }

        protected override IAspectWeavingSettings GetAspectsWeavingSettings() {
            return aspectWeavingSettings.CloneWith(settings => {
                settings.LocalBuilderRepository = new LocalBuilderRepository();
            });
        }

        protected override FieldInfo WeaveType() {
            IBindingWeaver bindingWeaver = null;
            var aspectSettings = GetAspectsWeavingSettings();
            var getMethodAspectWeaver = getAspectExpression.Reduce(aspectSettings); ;
            var setMethodAspectWeaver = setAspectExpression.Reduce(aspectSettings); ;

            bindingWeaver = new BothAccessorsPropertyInterceptionBindingWeaver(aspectDefinition.Property, bindingSettings, aspectSettings, getMethodAspectWeaver, setMethodAspectWeaver);

            return bindingWeaver.Weave();
        }
    }
}

