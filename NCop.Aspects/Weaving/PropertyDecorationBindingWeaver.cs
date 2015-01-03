using NCop.Weaving;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class PropertyDecorationBindingWeaver : AbstractPropertyBindingWeaver
    {
        internal PropertyDecorationBindingWeaver(PropertyInfo propertyInfo, BindingSettings bindingSettings, IAspectWeavingSettings aspectWeavingSettings, IMethodScopeWeaver methodScopeWeaver)
            : base(propertyInfo, bindingSettings, aspectWeavingSettings, methodScopeWeaver) {
        }
    }
}
