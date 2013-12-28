using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using NCop.Weaving.Extensions;

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
    }
}
