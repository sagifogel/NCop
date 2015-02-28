using NCop.Weaving;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingGetPropertyAspectDecoratorWeaver : AbstractMethodScopeWeaver, IAspectWeaver
    {
        private readonly IMethodScopeWeaver weaver = null;

        internal BindingGetPropertyAspectDecoratorWeaver(MethodInfo methodInfo, IAspectWeavingSettings aspectWeavingSettings)
            : base(methodInfo, aspectWeavingSettings.WeavingSettings) {
            weaver = new GetPropertyDecoratorScopeWeaver(methodInfo, aspectWeavingSettings);
        }

        public override void Weave(ILGenerator ilGenerator) {
            weaver.Weave(ilGenerator);
        }
    }
}
