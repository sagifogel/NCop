using NCop.Aspects.Extensions;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class SetPropertyDecoratorScopeWeaver : AbstractMethodScopeWeaver
    {
        private readonly MethodInfo methodInfoImpl = null;
        private readonly IArgumentsWeaver argumentsWeaver = null;

        internal SetPropertyDecoratorScopeWeaver(IAspectMethodWeavingSettings aspectWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings) {
            argumentsWeaver = new PropertyDecoratorArgumentsWeaver();
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.EmitLoadArg(3);
            ilGenerator.Emit(OpCodes.Callvirt, methodInfoImpl);

            return ilGenerator;
        }
    }
}
