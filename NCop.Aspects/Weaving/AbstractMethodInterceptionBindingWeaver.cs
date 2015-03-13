using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractMethodInterceptionBindingWeaver : AbstractBindingMethodAspectWeaver
    {
        protected readonly IAspectExpression aspectExpression = null;
        protected IAspectWeavingSettings aspectWeavingSettings = null;
        protected readonly Core.Lib.Lazy<FieldInfo> lazyWeavedType = null;

        internal AbstractMethodInterceptionBindingWeaver(IAspectExpression aspectExpression, IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
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
            IBindingWeaver bindingWeaver = null;
            var aspectSetings = GetAspectsWeavingSettings();

            aspectWeaver = aspectExpression.Reduce(aspectSetings);
            bindingWeaver = new MethodInterceptionBindingWeaver(aspectDefinition.Method, bindingSettings, aspectWeavingSettings, aspectWeaver);

            return bindingWeaver.Weave();
        }

        protected abstract IAspectWeavingSettings GetAspectsWeavingSettings();
    }
}
