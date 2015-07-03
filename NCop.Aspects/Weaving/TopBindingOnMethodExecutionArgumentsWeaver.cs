using NCop.Weaving.Extensions;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class TopBindingOnMethodExecutionArgumentsWeaver : AbstractBindingOnMethodExecutionArgumentsWeaver
    {
        internal TopBindingOnMethodExecutionArgumentsWeaver(MethodInfo method, IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings)
            : base(method, argumentWeavingSettings, aspectWeavingSettings) {
        }

        protected override void WeaveAspectArg(ILGenerator ilGenerator) {
            ilGenerator.EmitLoadArg(2);
        }
    }
}