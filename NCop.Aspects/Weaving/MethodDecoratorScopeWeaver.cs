using NCop.Aspects.Extensions;
using NCop.Weaving.Extensions;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class MethodDecoratorScopeWeaver : AbstractBranchedMethodScopeWeaver
    {
        private readonly MethodInfo methodInfo = null;
        private readonly IArgumentsWeaver argumentsWeaver = null;
        private readonly IByRefArgumentsStoreWeaver byRefArgumentsStoreWeaver = null;

        internal MethodDecoratorScopeWeaver(MethodInfo methodInfo, IAspectWeavingSettings aspectWeavingSettings)
            : base(methodInfo, aspectWeavingSettings.WeavingSettings) {
            Type aspectArgumentContract = null;
            var localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;

            this.methodInfo = methodInfo;
            aspectArgumentContract = methodInfo.ToAspectArgumentContract();
            byRefArgumentsStoreWeaver = new MethodDecoratorByRefArgumentsStoreWeaver(aspectArgumentContract, methodInfo, localBuilderRepository);
            argumentsWeaver = new MethodDecoratorArgumentsWeaver(methodInfo, byRefArgumentsStoreWeaver);
        }

        protected override void WeaveAction(ILGenerator ilGenerator) {
            byRefArgumentsStoreWeaver.StoreArgsIfNeeded(ilGenerator);
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, methodInfo);
            byRefArgumentsStoreWeaver.RestoreArgsIfNeeded(ilGenerator);
        }

        protected override void WeaveFunction(ILGenerator ilGenerator) {
            var aspectArgumentContract = methodInfo.ToAspectArgumentContract();
            var setReturnValueWeaver = new SetReturnValueWeaver(aspectArgumentContract);
            var returnValueGetMethod = aspectArgumentContract.GetProperty("ReturnValue");

            byRefArgumentsStoreWeaver.StoreArgsIfNeeded(ilGenerator);
            ilGenerator.EmitLoadArg(2);
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, methodInfo);
            setReturnValueWeaver.Weave(ilGenerator);
            byRefArgumentsStoreWeaver.RestoreArgsIfNeeded(ilGenerator);
            ilGenerator.EmitLoadArg(2);
            ilGenerator.Emit(OpCodes.Callvirt, returnValueGetMethod.GetGetMethod());
        }
    }
}
