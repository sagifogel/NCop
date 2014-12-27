using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractMethodInterceptionBindingWeaver : AbstractBindingMethodAspectWeaver
    {
        protected readonly Core.Lib.Lazy<FieldInfo> lazyWeavedType = null;
        protected readonly IAspectMethodExpression aspectExpression = null;
        protected IAspectMethodWeavingSettings aspectWeavingSettings = null;

        internal AbstractMethodInterceptionBindingWeaver(IAspectMethodExpression aspectExpression, IAspectDefinition aspectDefinition, IAspectMethodWeavingSettings aspectWeavingSettings)
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
            var aspectSetings = GetAspectsWeavingSettings();

            aspectWeaver = aspectExpression.Reduce(aspectSetings);
            bindingSettings.LocalBuilderRepository = aspectSetings.LocalBuilderRepository;
			bindingWeaver = new MethodInterceptionBindingWeaver(bindingSettings, aspectWeavingSettings, aspectWeaver);
            
            return bindingWeaver.Weave();
        }

        protected abstract IAspectMethodWeavingSettings GetAspectsWeavingSettings();
    }
}
