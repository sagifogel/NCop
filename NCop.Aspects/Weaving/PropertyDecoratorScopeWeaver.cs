using NCop.Aspects.Extensions;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class PropertyDecoratorScopeWeaver : AbstractBranchedMethodScopeWeaver
    {
        private readonly MethodInfo methodInfoImpl = null;
        private readonly IArgumentsWeaver argumentsWeaver = null;
        private readonly IByRefArgumentsStoreWeaver byRefArgumentsStoreWeaver = null;

        internal PropertyDecoratorScopeWeaver(IAspectMethodWeavingSettings aspectWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings) {
            methodInfoImpl = aspectWeavingSettings.WeavingSettings.MethodInfoImpl;
            argumentsWeaver = new PropertyDecoratorArgumentsWeaver(methodInfoImpl);
        }

        protected override ILGenerator WeaveAction(ILGenerator ilGenerator) {
            byRefArgumentsStoreWeaver.StoreArgsIfNeeded(ilGenerator);
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, methodInfoImpl);
            byRefArgumentsStoreWeaver.RestoreArgsIfNeeded(ilGenerator);

            return ilGenerator;
        }

        protected override ILGenerator WeaveFunction(ILGenerator ilGenerator) {
            var aspectArgumentContract = methodInfoImpl.ToAspectArgumentContract();
            var setReturnValueWeaver = new SetReturnValueWeaver(aspectArgumentContract);
            var returnValueGetMethod = aspectArgumentContract.GetProperty("ReturnValue");

            byRefArgumentsStoreWeaver.StoreArgsIfNeeded(ilGenerator);
            ilGenerator.EmitLoadArg(2);
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, methodInfoImpl);
            setReturnValueWeaver.Weave(ilGenerator);
            byRefArgumentsStoreWeaver.RestoreArgsIfNeeded(ilGenerator);
            ilGenerator.EmitLoadArg(2);
            ilGenerator.Emit(OpCodes.Callvirt, returnValueGetMethod.GetGetMethod());

            return ilGenerator;
        }
    }
}
