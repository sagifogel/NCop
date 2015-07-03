using NCop.Weaving;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class PropertyDecorationBindingWeaver : AbstractPropertyBindingWeaver
    {
        internal PropertyDecorationBindingWeaver(PropertyInfo property, BindingSettings bindingSettings, IAspectWeavingSettings aspectWeavingSettings, IMethodScopeWeaver methodScopeWeaver)
            : base(property, bindingSettings, aspectWeavingSettings, methodScopeWeaver) {
        }
    }
}
