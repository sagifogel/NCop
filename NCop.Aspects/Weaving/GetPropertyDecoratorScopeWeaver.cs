using NCop.Aspects.Extensions;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class GetPropertyDecoratorScopeWeaver : AbstractMethodScopeWeaver
    {
        private readonly MethodInfo methodInfoImpl = null;
        private readonly IArgumentsWeaver argumentsWeaver = null;

        internal GetPropertyDecoratorScopeWeaver(IAspectMethodWeavingSettings aspectWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings) {
            methodInfoImpl = aspectWeavingSettings.WeavingSettings.MethodInfoImpl;
            argumentsWeaver = new PropertyDecoratorArgumentsWeaver(methodInfoImpl);
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, methodInfoImpl);

            return ilGenerator;
        }
    }
}
