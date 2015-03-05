using NCop.Weaving.Extensions;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class NestedMethodInvokerAspectWeaver : AbstractBranchedMethodScopeWeaver, IAspectWeaver
    {
        private readonly Type topAspectInScopeArgType = null;
        private readonly IArgumentsWeaver argumentsWeaver = null;
        private readonly IAspectWeavingSettings aspectWeavingSettings = null;
        private readonly IByRefArgumentsStoreWeaver byRefArgumentStoreWeaver = null;

        internal NestedMethodInvokerAspectWeaver(MethodInfo methodInfo, Type topAspectInScopeArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentsWeavingSettings)
            : base(methodInfo, aspectWeavingSettings.WeavingSettings) {
            this.topAspectInScopeArgType = topAspectInScopeArgType;
            this.aspectWeavingSettings = aspectWeavingSettings;
            byRefArgumentStoreWeaver = aspectWeavingSettings.ByRefArgumentsStoreWeaver;
            argumentsWeaver = new NestedMethodInvokerArgumentsWeaver(methodInfo, topAspectInScopeArgType, aspectWeavingSettings, argumentsWeavingSettings);
        }

        protected override void WeaveAction(ILGenerator ilGenerator) {
            byRefArgumentStoreWeaver.StoreArgsIfNeeded(ilGenerator);
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, MethodInfo);
            byRefArgumentStoreWeaver.RestoreArgsIfNeeded(ilGenerator);
        }

        protected override void WeaveFunction(ILGenerator ilGenerator) {
            var LocalBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            var argsLocalBuilder = LocalBuilderRepository.Get(topAspectInScopeArgType);
            var setReturnValueWeaver = new SetReturnValueWeaver(topAspectInScopeArgType);

            byRefArgumentStoreWeaver.StoreArgsIfNeeded(ilGenerator);
            ilGenerator.EmitLoadLocal(argsLocalBuilder);
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, MethodInfo);
            setReturnValueWeaver.Weave(ilGenerator);
            byRefArgumentStoreWeaver.RestoreArgsIfNeeded(ilGenerator);
        }
    }
}
