using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class MethodInterceptionBindingWeaver : AbstractMethodBindingWeaver
    {
        internal MethodInterceptionBindingWeaver(MethodInfo method, BindingSettings bindingSettings, IAspectWeavingSettings aspectWeavingSettings, IAspectWeaver methodScopeWeaver)
            : base(method, bindingSettings, aspectWeavingSettings, methodScopeWeaver) {
        }
    }
}
