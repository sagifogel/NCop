using System.Reflection;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Engine
{
    public class PropertyInterceptionArgsImpl<TInstance, TArg> : PropertyInterceptionArgs<TArg>, IPropertyArg<TArg>
    {
        private TInstance instance = default(TInstance);
        private readonly IPropertyBinding<TInstance, TArg> propertyBinding = null;

        public PropertyInterceptionArgsImpl(TInstance instance, MethodInfo method, IPropertyBinding<TInstance, TArg> propertyBinding, TArg value = default(TArg)) {
            Value = value;
            Method = method;
            Instance = this.instance = instance;
            this.propertyBinding = propertyBinding;
        }

        public override void ProceedSetValue() {
            propertyBinding.SetValue(ref instance, this, Value);
        }

        public override void ProceedGetValue() {
            Value = propertyBinding.GetValue(ref instance, this);
        }

        public override TArg GetCurrentValue() {
            return propertyBinding.GetValue(ref instance, this);
        }

        public override void SetNewValue(TArg value) {
            propertyBinding.SetValue(ref instance, this, value);
        }
    }
}
