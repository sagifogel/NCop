using System;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class GetPropertyInterceptionBindingWeaver : AbstractPropertyBindingWeaver
    {
        internal GetPropertyInterceptionBindingWeaver(PropertyInfo propertyInfo, BindingSettings bindingSettings, IAspectWeavingSettings aspectWeavingSettings, IAspectWeaver methodScopeWeaver)
            : base(propertyInfo, bindingSettings, aspectWeavingSettings, methodScopeWeaver) {
        }

        public override bool WeaveGetMethod {
            get {
                return true;
            }
        }
    }
}
