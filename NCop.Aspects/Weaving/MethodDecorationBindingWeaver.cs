using NCop.Weaving;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class MethodDecoratorBindingWeaver : AbstractMethodBindingWeaver
    {
        internal MethodDecoratorBindingWeaver(MethodInfo methodInfo, BindingSettings bindingSettings, IAspectWeavingSettings aspectWeavingSettings, IMethodScopeWeaver methodScopeWeaver)
            : base(methodInfo, bindingSettings, aspectWeavingSettings, methodScopeWeaver) {
        }
    }
}
