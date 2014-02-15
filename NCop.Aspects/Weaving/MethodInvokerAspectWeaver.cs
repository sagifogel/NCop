using NCop.Aspects.Aspects;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class MethodInvokerAspectWeaver : AbstractBranchedMethodScopeWeaver, IAspectWeaver
    {
        private readonly Type previousAspectArgsType = null;
        private readonly IArgumentsWeaver argumentsWeaver = null;
        private readonly ILocalBuilderRepository localBuilderRepository = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;
        private readonly ICanEmitLocalBuilderByRefArgumentsWeaver byRefArgumentStoreWeaver = null;

        internal MethodInvokerAspectWeaver(Type previousAspectArgsType, IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentsWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings) {
            var methodInfoImpl = aspectWeavingSettings.WeavingSettings.MethodInfoImpl;

            this.previousAspectArgsType = previousAspectArgsType;
            this.argumentsWeavingSettings = argumentsWeavingSettings;
            localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            byRefArgumentStoreWeaver = new MethodInvokerByRefArgumentsWeaver(previousAspectArgsType, methodInfoImpl, localBuilderRepository);
            argumentsWeaver = new MethodInvokerArgumentsWeaver(previousAspectArgsType, aspectWeavingSettings, argumentsWeavingSettings, byRefArgumentStoreWeaver);
        }

        protected override ILGenerator WeaveAction(ILGenerator ilGenerator) {
            byRefArgumentStoreWeaver.StoreArgsIfNeeded(ilGenerator);
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, MethodInfoImpl);
            byRefArgumentStoreWeaver.RestoreArgsIfNeeded(ilGenerator);

            return ilGenerator;
        }

        protected override ILGenerator WeaveFunction(ILGenerator ilGenerator) {
            var setReturnValueWeaver = new SetReturnValueWeaver(previousAspectArgsType);
            var argsImplLocalBuilder = localBuilderRepository.Get(previousAspectArgsType);

            byRefArgumentStoreWeaver.StoreArgsIfNeeded(ilGenerator);
            ilGenerator.EmitLoadLocal(argsImplLocalBuilder);
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, MethodInfoImpl);
            setReturnValueWeaver.Weave(ilGenerator);
            byRefArgumentStoreWeaver.RestoreArgsIfNeeded(ilGenerator);

            return ilGenerator;
        }
    }
}
