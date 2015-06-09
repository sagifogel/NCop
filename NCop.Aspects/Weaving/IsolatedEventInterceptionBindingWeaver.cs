using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Weaving
{
    internal class IsolatedEventInterceptionBindingWeaver : AbstractBindingTypeReflector<IEventAspectDefinition>
    {
        protected readonly Core.Lib.Lazy<FieldInfo> lazyWeavedType = null;
        protected readonly IAspectExpression invokeAspectExpression = null;
        protected readonly IAspectWeavingSettings aspectWeavingSettings = null;

        internal IsolatedEventInterceptionBindingWeaver(IAspectExpression invokeAspectExpression, IEventAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
            : base(aspectDefinition) {
            this.invokeAspectExpression = invokeAspectExpression;
            this.aspectWeavingSettings = aspectWeavingSettings;
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
            IAspectWeaver aspectWeaver = null;
            IBindingWeaver bindingWeaver = null;
            var aspectSettings = GetAspectsWeavingSettings();

            aspectWeaver = invokeAspectExpression.Reduce(aspectSettings);
            bindingWeaver = new EventInterceptionBindingWeaver(aspectDefinition.Member, bindingSettings, aspectWeavingSettings, aspectWeaver);

            return bindingWeaver.Weave();
        }
    }
}
