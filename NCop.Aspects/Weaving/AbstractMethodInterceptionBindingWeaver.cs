using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractMethodInterceptionBindingWeaver : AbstractBindingMethodAspectWeaver
    {
        protected readonly IAspectExpression aspectExpression = null;
        protected readonly IAspectWeavingSettings aspectWeavingSettings = null;
        protected readonly Core.Lib.Lazy<FieldInfo> lazyWeavedType = null;

        internal AbstractMethodInterceptionBindingWeaver(IAspectExpression aspectExpression, IMethodAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings)
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
            var aspectSettings = GetAspectsWeavingSettings();

            aspectWeaver = aspectExpression.Reduce(aspectSettings);
            bindingWeaver = new MethodInterceptionBindingWeaver(aspectDefinition.Member, bindingSettings, aspectWeavingSettings, aspectWeaver);

            return bindingWeaver.Weave();
        }
    }
}
