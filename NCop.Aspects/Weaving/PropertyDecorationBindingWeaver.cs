using NCop.Weaving;

namespace NCop.Aspects.Weaving
{
    internal class PropertyDecorationBindingWeaver : AbstractPropertyBindingWeaver
    {
        internal PropertyDecorationBindingWeaver(BindingSettings bindingSettings, IAspectMethodWeavingSettings aspectWeavingSettings, IMethodScopeWeaver methodScopeWeaver)
			: base(bindingSettings, aspectWeavingSettings, methodScopeWeaver) {
        }
    }
}
