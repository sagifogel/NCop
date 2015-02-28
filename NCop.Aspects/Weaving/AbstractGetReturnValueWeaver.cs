using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractGetReturnValueWeaver : IMethodScopeWeaver
    {
        protected readonly IAspectWeavingSettings aspectWeavingSettings = null;
        protected readonly ILocalBuilderRepository localBuilderRepository = null;
        protected readonly IArgumentsWeavingSettings argumentsWeavingSetings = null;

        internal AbstractGetReturnValueWeaver(IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentsWeavingSetings) {
            this.aspectWeavingSettings = aspectWeavingSettings;
            this.argumentsWeavingSetings = argumentsWeavingSetings;
            localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
        }

        public void Weave(ILGenerator ilGenerator) {
            MethodInfo returnValueGetMethod = null;
            LocalBuilder argsImplLocalBuilder = null;
            var weavingSettings = aspectWeavingSettings.WeavingSettings;
            var argumentType = argumentsWeavingSetings.ArgumentType;
            var aspectArgsType = GetAspectType();

            argsImplLocalBuilder = localBuilderRepository.Get(argumentType);
            ilGenerator.EmitLoadLocal(argsImplLocalBuilder);
            returnValueGetMethod = aspectArgsType.GetProperty("ReturnValue").GetGetMethod();
            ilGenerator.Emit(OpCodes.Callvirt, returnValueGetMethod);
        }

        protected abstract Type GetAspectType();
    }
}
