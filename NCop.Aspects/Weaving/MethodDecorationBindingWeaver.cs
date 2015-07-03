using NCop.Weaving;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class MethodDecoratorBindingWeaver : AbstractMethodBindingWeaver
    {
        internal MethodDecoratorBindingWeaver(MethodInfo method, BindingSettings bindingSettings, IAspectWeavingSettings aspectWeavingSettings, IMethodScopeWeaver methodScopeWeaver)
            : base(method, bindingSettings, aspectWeavingSettings, methodScopeWeaver) {
        }
    }
}
