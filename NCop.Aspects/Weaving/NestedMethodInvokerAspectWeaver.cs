using NCop.Aspects.Extensions;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class NestedMethodInvokerAspectWeaver : AbstractBranchedMethodScopeWeaver, IAspectWeaver
    {
        private readonly Type topAspectInScopeArgType = null;
        private readonly IArgumentsWeaver argumentsWeaver = null;
        private readonly IAspectWeavingSettings aspectWeavingSettings = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;
        private readonly IByRefArgumentsStoreWeaver byRefArgumentStoreWeaver = null;

        internal NestedMethodInvokerAspectWeaver(Type topAspectInScopeArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentsWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings) {
            this.topAspectInScopeArgType = topAspectInScopeArgType;
            this.aspectWeavingSettings = aspectWeavingSettings;
            this.argumentsWeavingSettings = argumentsWeavingSettings;
            byRefArgumentStoreWeaver = aspectWeavingSettings.ByRefArgumentsStoreWeaver;
            argumentsWeaver = new NestedMethodInvokerArgumentsWeaver(topAspectInScopeArgType, aspectWeavingSettings, argumentsWeavingSettings);
        }

        protected override ILGenerator WeaveAction(ILGenerator ilGenerator) {
            byRefArgumentStoreWeaver.StoreArgsIfNeeded(ilGenerator);
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, MethodInfoImpl);
            byRefArgumentStoreWeaver.RestoreArgsIfNeeded(ilGenerator);

            return ilGenerator;
        }

        protected override ILGenerator WeaveFunction(ILGenerator ilGenerator) {
            var LocalBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            var argsLocalBuilder = LocalBuilderRepository.Get(topAspectInScopeArgType);
            var setReturnValueWeaver = new SetReturnValueWeaver(topAspectInScopeArgType);

            byRefArgumentStoreWeaver.StoreArgsIfNeeded(ilGenerator);
            ilGenerator.EmitLoadLocal(argsLocalBuilder);
            argumentsWeaver.Weave(ilGenerator); 
            ilGenerator.Emit(OpCodes.Callvirt, MethodInfoImpl);
            setReturnValueWeaver.Weave(ilGenerator);
            byRefArgumentStoreWeaver.RestoreArgsIfNeeded(ilGenerator);

            return ilGenerator;
        }
    }
}
