using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Weaving;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class MethodInvokerAspectWeaver : AbstractMethodScopeWeaver, IAspectWeaver
    {
        private readonly Type previousAspectArgType = null;
        private readonly IArgumentsWeaver argumentsWeaver = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;
        private readonly ICanEmitLocalBuilderByRefArgumentsStoreWeaver byRefArgumentStoreWeaver = null;

        internal MethodInvokerAspectWeaver(Type previousAspectArgsType, IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentsWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings) {
            var methodInfoImpl = aspectWeavingSettings.WeavingSettings.MethodInfoImpl;
            var localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;

            this.argumentsWeavingSettings = argumentsWeavingSettings;
            byRefArgumentStoreWeaver = new MethodInvokerByRefArgumentsWeaver(previousAspectArgsType, methodInfoImpl, localBuilderRepository);
            argumentsWeaver = new MethodInvokerArgumentsWeaver(previousAspectArgsType, aspectWeavingSettings, argumentsWeavingSettings, byRefArgumentStoreWeaver);
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            byRefArgumentStoreWeaver.StoreArgsIfNeeded(ilGenerator);
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, MethodInfoImpl);
            byRefArgumentStoreWeaver.RestoreArgsIfNeeded(ilGenerator);

            if (argumentsWeavingSettings.IsFunction) {
                var setReturnValueWeaver = new SetReturnValueWeaver(previousAspectArgType);

                setReturnValueWeaver.Weave(ilGenerator);
            }

            return ilGenerator;
        }
    }
}
