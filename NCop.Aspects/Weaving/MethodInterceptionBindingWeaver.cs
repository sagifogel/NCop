using System;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class MethodInterceptionBindingWeaver : AbstractMethodBindingWeaver
    {
        internal MethodInterceptionBindingWeaver(MethodInfo methodInfo, BindingSettings bindingSettings, IAspectWeavingSettings aspectWeavingSettings, IAspectWeaver methodScopeWeaver)
            : base(methodInfo, bindingSettings, aspectWeavingSettings, methodScopeWeaver) {
        }
    }
}
