using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Weaving.Extensions;

namespace NCop.Aspects.Weaving
{
    internal class TopGetPropertyInterceptionAspectWeaver : AbstractMethodInterceptionAspectWeaver
    {
        protected readonly IArgumentsWeaver argumentsWeaver = null;

        internal TopGetPropertyInterceptionAspectWeaver(IAspectDefinition aspectDefinition, IAspectMethodWeavingSettings aspectWeavingSettings, FieldInfo weavedType)
            : base(aspectDefinition, aspectWeavingSettings, weavedType) {
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            var aspectArgsType = weavingSettings.MethodInfoImpl.ToAspectArgumentContract();

            argumentsWeaver.Weave(ilGenerator);
            weaver.Weave(ilGenerator);
            ilGenerator.EmitLoadArg(2);
            ilGenerator.Emit(OpCodes.Callvirt, aspectArgsType.GetProperty("Value").GetGetMethod());

            return ilGenerator;
        }
    }
}
