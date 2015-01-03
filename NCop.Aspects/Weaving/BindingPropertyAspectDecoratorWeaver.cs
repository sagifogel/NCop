using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Weaving;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingPropertyAspectDecoratorWeaver : AbstractMethodScopeWeaver, IAspectWeaver
    {
        private readonly IMethodScopeWeaver weaver = null;

        internal BindingPropertyAspectDecoratorWeaver(MethodInfo methodInfo, IAspectPropertyMethodWeavingSettings aspectWeavingSettings)
            : base(methodInfo, aspectWeavingSettings.WeavingSettings) {
            weaver = new GetPropertyDecoratorScopeWeaver(methodInfo, aspectWeavingSettings);
        }

        public override void Weave(ILGenerator ilGenerator) {
            weaver.Weave(ilGenerator);
        }
    }
}
