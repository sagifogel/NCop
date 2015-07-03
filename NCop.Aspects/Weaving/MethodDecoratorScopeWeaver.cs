using NCop.Aspects.Extensions;
using NCop.Weaving.Extensions;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class MethodDecoratorScopeWeaver : AbstractBranchedMethodScopeWeaver
    {
        private readonly MethodInfo method = null;
        private readonly IArgumentsWeaver argumentsWeaver = null;
        private readonly IByRefArgumentsStoreWeaver byRefArgumentsStoreWeaver = null;

        internal MethodDecoratorScopeWeaver(MethodInfo method, IAspectWeavingSettings aspectWeavingSettings)
            : base(method, aspectWeavingSettings.WeavingSettings) {
            Type aspectArgumentContract = null;
            var localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;

            this.method = method;
            aspectArgumentContract = method.ToAspectArgumentContract();
            byRefArgumentsStoreWeaver = new MethodDecoratorByRefArgumentsStoreWeaver(aspectArgumentContract, method, localBuilderRepository);
            argumentsWeaver = new MethodDecoratorArgumentsWeaver(method, byRefArgumentsStoreWeaver);
        }

        protected override void WeaveAction(ILGenerator ilGenerator) {
            byRefArgumentsStoreWeaver.StoreArgsIfNeeded(ilGenerator);
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, method);
            byRefArgumentsStoreWeaver.RestoreArgsIfNeeded(ilGenerator);
        }

        protected override void WeaveFunction(ILGenerator ilGenerator) {
            var aspectArgumentContract = method.ToAspectArgumentContract();
            var setReturnValueWeaver = new SetReturnValueWeaver(aspectArgumentContract);
            var returnValueGetMethod = aspectArgumentContract.GetProperty("ReturnValue");

            byRefArgumentsStoreWeaver.StoreArgsIfNeeded(ilGenerator);
            ilGenerator.EmitLoadArg(2);
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, method);
            setReturnValueWeaver.Weave(ilGenerator);
            byRefArgumentsStoreWeaver.RestoreArgsIfNeeded(ilGenerator);
            ilGenerator.EmitLoadArg(2);
            ilGenerator.Emit(OpCodes.Callvirt, returnValueGetMethod.GetGetMethod());
        }
    }
}
