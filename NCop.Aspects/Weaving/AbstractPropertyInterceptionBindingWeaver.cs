using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractPropertyInterceptionBindingWeaver : AbstractBindingPropertyAspectWeaver
    {
        protected readonly Core.Lib.Lazy<FieldInfo> lazyWeavedType = null;
        protected readonly IAspectMethodExpression aspectExpression = null;
        protected IAspectWeavingSettings aspectWeavingSettings = null;

        internal AbstractPropertyInterceptionBindingWeaver(IAspectMethodExpression aspectExpression, IPropertyAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
            : base(aspectDefinition) {
            this.aspectExpression = aspectExpression;
            this.aspectWeavingSettings = aspectWeavingSettings;
            lazyWeavedType = new Core.Lib.Lazy<FieldInfo>(WeaveType);
        }

        public override FieldInfo WeavedType {
            get {
                return lazyWeavedType.Value;
            }
        }

        protected virtual FieldInfo WeaveType() {
            IAspectWeaver aspectWeaver = null;
            IMethodBindingWeaver bindingWeaver = null;
            var aspectSettings = GetAspectsWeavingSettings() as IAspectPropertyMethodWeavingSettings;

            aspectWeaver = aspectExpression.Reduce(aspectSettings);
            bindingSettings.LocalBuilderRepository = aspectSettings.LocalBuilderRepository;
            bindingWeaver = new PropertyInterceptionBindingWeaver(bindingSettings, aspectSettings, aspectWeaver);

            return bindingWeaver.Weave();
        }

        protected abstract IAspectWeavingSettings GetAspectsWeavingSettings();
    }
}
