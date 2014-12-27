using System;

namespace NCop.Aspects.Weaving
{
    internal class MethodInterceptionBindingWeaver : AbstractMethodBindingWeaver
    {
        internal MethodInterceptionBindingWeaver(BindingSettings bindingSettings, IAspectMethodWeavingSettings aspectWeavingSettings, IAspectWeaver methodScopeWeaver)
            : base(bindingSettings, aspectWeavingSettings, methodScopeWeaver) {
        }
    }
}
