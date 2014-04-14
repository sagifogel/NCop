using NCop.Aspects.Extensions;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class MethodDecoratorScopeWeaver : AbstractBranchedMethodScopeWeaver
    {
        private readonly MethodInfo methodInfoImpl = null;
        private readonly IArgumentsWeaver argumentsWeaver = null;
        private readonly IAspectWeavingSettings aspectWeavingSettings = null;
        private readonly IByRefArgumentsStoreWeaver byRefArgumentsStoreWeaver = null;

        internal MethodDecoratorScopeWeaver(IAspectWeavingSettings aspectWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings) {
            Type aspectArgumentContract = null;
            var localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            var weavingSettings = aspectWeavingSettings.WeavingSettings;

            this.aspectWeavingSettings = aspectWeavingSettings;
            methodInfoImpl = aspectWeavingSettings.WeavingSettings.MethodInfoImpl;
            aspectArgumentContract = methodInfoImpl.ToAspectArgumentContract();
            byRefArgumentsStoreWeaver = new MethodDecoratorByRefArgumentsStoreWeaver(aspectArgumentContract, methodInfoImpl, localBuilderRepository);
            argumentsWeaver = new MethodDecoratorArgumentsWeaver(methodInfoImpl, byRefArgumentsStoreWeaver);
        }

        protected override ILGenerator WeaveAction(ILGenerator ilGenerator) {
            var aspectArgumentContract = methodInfoImpl.ToAspectArgumentContract();

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
