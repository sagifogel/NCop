using NCop.Weaving.Extensions;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class FunctionAspectArgsMappingWeaver : AbstractAspectArgsMappingWeaver
    {
        internal FunctionAspectArgsMappingWeaver(IAspectWeavingSettings aspectWeavingSettings, IArgumentsSettings argumentsSettings)
            : base(aspectWeavingSettings, argumentsSettings) {
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            var returnValueProperty = argumentsSettings.ArgumentType.GetProperty("ReturnValue");

            ilGenerator.Emit(OpCodes.Pop);
            base.Weave(ilGenerator);
            ilGenerator.EmitLoadArg(2);
            ilGenerator.Emit(OpCodes.Callvirt, returnValueProperty.GetGetMethod());

            return ilGenerator;
        }

        protected override void WeaveAspectArg(ILGenerator ilGenerator) {
            ilGenerator.EmitLoadArg(2);
        }
    }
}
