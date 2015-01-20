using System;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class BothAccessorsPropertyInterceptionBindingWeaver : AbstractPropertyBindingWeaver
    {
        internal BothAccessorsPropertyInterceptionBindingWeaver(PropertyInfo propertyInfo, BindingSettings bindingSettings, IAspectWeavingSettings aspectWeavingSettings, IAspectWeaver getMethodScopeWeaver, IAspectWeaver setMethodScopeWeaver)
            : base(propertyInfo, bindingSettings, aspectWeavingSettings, getMethodScopeWeaver, setMethodScopeWeaver) {
        }

        public override bool WeaveGetMethod {
            get {
                return true;
            }
        }

        public override bool WeaveSetMethod {
            get {
                return true;
            }
        }
    }
}
