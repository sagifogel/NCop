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
        private readonly Type previousAspectArgType = null;
        private readonly IArgumentsWeaver argumentsWeaver = null;
        private readonly IAspectWeavingSettings aspectWeavingSettings = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;
        private readonly IByRefArgumentsStoreWeaver byRefArgumentStoreWeaver = null;

        internal NestedMethodInvokerAspectWeaver(Type previousAspectArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentsWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings) {
            this.previousAspectArgType = previousAspectArgType;
            this.aspectWeavingSettings = aspectWeavingSettings;
            this.argumentsWeavingSettings = argumentsWeavingSettings;
            byRefArgumentStoreWeaver = aspectWeavingSettings.ByRefArgumentsStoreWeaver;
            argumentsWeaver = new NestedMethodInvokerArgumentsWeaver(previousAspectArgType, aspectWeavingSettings, argumentsWeavingSettings);
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
            var argsLocalBuilder = LocalBuilderRepository.Get(previousAspectArgType);
            var setReturnValueWeaver = new SetReturnValueWeaver(previousAspectArgType);

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
