using System;

namespace NCop.Aspects.Weaving
{
    internal class PropertyInterceptionBindingWeaver : AbstractPropertyBindingWeaver
    {
        internal PropertyInterceptionBindingWeaver(BindingSettings bindingSettings, IAspectPropertyMethodWeavingSettings aspectWeavingSettings, IAspectWeaver methodScopeWeaver)
            : base(bindingSettings, aspectWeavingSettings, methodScopeWeaver) {
        }
    }
}
