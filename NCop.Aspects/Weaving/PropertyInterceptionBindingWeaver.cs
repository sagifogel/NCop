using System;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class PropertyInterceptionBindingWeaver : AbstractPropertyBindingWeaver
    {
        internal PropertyInterceptionBindingWeaver(PropertyInfo propertyInfo, BindingSettings bindingSettings, IAspectWeavingSettings aspectWeavingSettings, IAspectWeaver methodScopeWeaver)
            : base(propertyInfo, bindingSettings, aspectWeavingSettings, methodScopeWeaver) {
        }
    }
}
