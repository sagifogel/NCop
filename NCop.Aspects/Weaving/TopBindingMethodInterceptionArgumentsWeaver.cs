using NCop.Weaving.Extensions;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class TopBindingMethodInterceptionArgumentsWeaver : AbstractBindingMethodInterceptionArgumentsWeaver
    {
        internal TopBindingMethodInterceptionArgumentsWeaver(MethodInfo methodInfo, IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings)
            : base(methodInfo, argumentWeavingSettings, aspectWeavingSettings) {
        }

        protected override void WeaveAspectArg(ILGenerator ilGenerator) {
            ilGenerator.EmitLoadArg(2);
        }
    }
}
