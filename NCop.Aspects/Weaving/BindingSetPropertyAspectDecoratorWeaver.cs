using NCop.Weaving;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingSetPropertyAspectDecoratorWeaver : AbstractMethodScopeWeaver, IAspectWeaver
    {
        private readonly IMethodScopeWeaver weaver = null;

        internal BindingSetPropertyAspectDecoratorWeaver(MethodInfo methodInfo, IAspectWeavingSettings aspectWeavingSettings)
            : base(methodInfo, aspectWeavingSettings.WeavingSettings) {
            weaver = new SetPropertyDecoratorScopeWeaver(methodInfo, aspectWeavingSettings);
        }

        public override void Weave(ILGenerator ilGenerator) {
            weaver.Weave(ilGenerator);
        }
    }
}
