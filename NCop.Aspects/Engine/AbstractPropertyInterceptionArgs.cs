using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractPropertyInterceptionArgs<TInstance, TArg> : PropertyInterceptionArgs<TArg>, IPropertyArg<TArg>
    {
        protected TInstance instance = default(TInstance);
        protected readonly IPropertyBinding<TInstance, TArg> propertyBinding = null;

        protected AbstractPropertyInterceptionArgs(TInstance instance, MethodInfo method, IPropertyBinding<TInstance, TArg> propertyBinding) {
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
