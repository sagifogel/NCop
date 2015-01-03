using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractPropertyInterceptionBindingWeaver : AbstractBindingPropertyAspectWeaver
    {
        protected readonly Core.Lib.Lazy<FieldInfo> lazyWeavedType = null;
        protected readonly IAspectExpression aspectExpression = null;
        protected IAspectWeavingSettings aspectWeavingSettings = null;

        internal AbstractPropertyInterceptionBindingWeaver(IAspectExpression aspectExpression, IPropertyAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
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
            var aspectSettings = GetAspectsWeavingSettings();

            aspectWeaver = aspectExpression.Reduce(aspectSettings);
            bindingWeaver = new PropertyInterceptionBindingWeaver(aspectDefinition.PropertyInfo, bindingSettings, aspectSettings, aspectWeaver);

            return bindingWeaver.Weave();
        }

        protected abstract IAspectWeavingSettings GetAspectsWeavingSettings();
    }
}
