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
        private readonly Type topAspectInScopeArgType = null;
        private readonly IArgumentsWeaver argumentsWeaver = null;
        private readonly ILocalBuilderRepository localBuilderRepository = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;
        private readonly IByRefArgumentsStoreWeaver byRefArgumentStoreWeaver = null;

        internal MethodInvokerAspectWeaver(Type topAspectInScopeArgType, IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentsWeavingSettings)
            : base(aspectDefinition.Member, aspectWeavingSettings.WeavingSettings) {
            this.topAspectInScopeArgType = topAspectInScopeArgType;
            this.argumentsWeavingSettings = argumentsWeavingSettings;
            localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            byRefArgumentStoreWeaver = aspectWeavingSettings.ByRefArgumentsStoreWeaver;
            argumentsWeaver = new MethodInvokerArgumentsWeaver(aspectDefinition.Member, topAspectInScopeArgType, aspectWeavingSettings, argumentsWeavingSettings, byRefArgumentStoreWeaver);
        }

        protected override void WeaveAction(ILGenerator ilGenerator) {
            byRefArgumentStoreWeaver.StoreArgsIfNeeded(ilGenerator);
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, MethodInfo);
            byRefArgumentStoreWeaver.RestoreArgsIfNeeded(ilGenerator);
        }

        protected override void WeaveFunction(ILGenerator ilGenerator) {
            var setReturnValueWeaver = new SetReturnValueWeaver(topAspectInScopeArgType);
            var argsImplLocalBuilder = localBuilderRepository.Get(topAspectInScopeArgType);

            byRefArgumentStoreWeaver.StoreArgsIfNeeded(ilGenerator);
            ilGenerator.EmitLoadLocal(argsImplLocalBuilder);
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, MethodInfo);
            setReturnValueWeaver.Weave(ilGenerator);
            byRefArgumentStoreWeaver.RestoreArgsIfNeeded(ilGenerator);
        }
    }
}
