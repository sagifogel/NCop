using NCop.Weaving;
using NCop.Weaving.Extensions;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class SetPropertyDecoratorScopeWeaver : AbstractMethodScopeWeaver
    {
        private readonly IArgumentsWeaver argumentsWeaver = null;

        internal SetPropertyDecoratorScopeWeaver(PropertyInfo property, IAspectWeavingSettings aspectWeavingSettings)
            : base(property.GetSetMethod(), aspectWeavingSettings.WeavingSettings) {
            argumentsWeaver = new PropertyDecoratorArgumentsWeaver();
        }

        public override void Weave(ILGenerator ilGenerator) {
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.EmitLoadArg(3);
            ilGenerator.Emit(OpCodes.Callvirt, Method);
        }
    }
}
