using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class IsolatedEventInterceptionBindingWeaver : AbstractBindingTypeReflector<IEventAspectDefinition>
    {
        protected readonly Core.Lib.Lazy<FieldInfo> lazyWeavedType = null;
        protected readonly IAspectExpression addAspectExpression = null;
        protected readonly IAspectExpression removeAspectExpression = null;
        protected readonly IAspectExpression invokeAspectExpression = null;
        protected readonly IAspectWeavingSettings aspectWeavingSettings = null;

        internal IsolatedEventInterceptionBindingWeaver(IAspectExpression addAspectExpression, IAspectExpression removeAspectExpression, IAspectExpression invokeAspectExpression, IEventAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
            : base(aspectDefinition) {
            this.addAspectExpression = addAspectExpression;
            this.aspectWeavingSettings = aspectWeavingSettings;
            this.removeAspectExpression = removeAspectExpression;
            this.invokeAspectExpression = invokeAspectExpression;
            lazyWeavedType = new Core.Lib.Lazy<FieldInfo>(WeaveType);
        }

        protected override IAspectWeavingSettings GetAspectsWeavingSettings() {
            return aspectWeavingSettings.CloneWith(settings => {
                settings.LocalBuilderRepository = new LocalBuilderRepository();
            });
        }

        public override FieldInfo WeavedType {
            get {
                return lazyWeavedType.Value;
            }
        }

        protected virtual FieldInfo WeaveType() {
            var aspectSettings = GetAspectsWeavingSettings();
            var addMethodAspectWeaver = addAspectExpression.Reduce(aspectSettings);
            var removeMethodAspectWeaver = removeAspectExpression.Reduce(aspectSettings);
            var invokeMethodAspectWeaver = invokeAspectExpression.Reduce(aspectSettings);
            var bindingWeaver = new EventInterceptionBindingWeaver(aspectDefinition.Member, bindingSettings, aspectWeavingSettings, addMethodAspectWeaver, removeMethodAspectWeaver, invokeMethodAspectWeaver);

            return bindingWeaver.Weave();
        }
    }
}
