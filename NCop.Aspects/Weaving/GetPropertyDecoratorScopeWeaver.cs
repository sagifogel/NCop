using NCop.Weaving;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class GetPropertyDecoratorScopeWeaver : AbstractMethodScopeWeaver
    {
        private readonly IArgumentsWeaver argumentsWeaver = null;

        internal GetPropertyDecoratorScopeWeaver(MethodInfo method, IAspectWeavingSettings aspectWeavingSettings)
            : base(method, aspectWeavingSettings.WeavingSettings) {
            argumentsWeaver = new PropertyDecoratorArgumentsWeaver();
        }

        public override void Weave(ILGenerator ilGenerator) {
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, Method);
        }
    }
}
