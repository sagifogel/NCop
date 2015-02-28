using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingSetPropertyInterceptionArgumentsWeaver : AbstractTopPropertyAspectArgumentsWeaver
    {
        internal BindingSetPropertyInterceptionArgumentsWeaver(MethodInfo methodInfo, IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings)
            : base(methodInfo, argumentWeavingSettings, aspectWeavingSettings) {
        }

        public override LocalBuilder BuildArguments(ILGenerator ilGenerator) {
            throw new System.NotImplementedException();
        }
    }
}
