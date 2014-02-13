using NCop.Aspects.Extensions;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class GetReturnValueWeaver : IMethodScopeWeaver
    {
        private readonly IAspectWeavingSettings aspectWeavingSettings = null;
        private readonly ILocalBuilderRepository localBuilderRepository = null;
        private readonly IArgumentsWeavingSettings argumentsWeavingSetings = null;

        internal GetReturnValueWeaver(IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentsWeavingSetings) {
            this.aspectWeavingSettings = aspectWeavingSettings;
            this.argumentsWeavingSetings = argumentsWeavingSetings;
            localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
        }

        public ILGenerator Weave(ILGenerator ilGenerator) {
            MethodInfo returnValueGetMethod = null;
            LocalBuilder argsImplLocalBuilder = null;
            var weavingSettings = aspectWeavingSettings.WeavingSettings;
            var argumentType = argumentsWeavingSetings.ArgumentType;
            var aspectArgsType = weavingSettings.MethodInfoImpl.ToAspectArgumentContract();

            argsImplLocalBuilder = localBuilderRepository.Get(argumentType);
            ilGenerator.EmitLoadLocal(argsImplLocalBuilder);
            returnValueGetMethod = aspectArgsType.GetProperty("ReturnValue").GetGetMethod();
            ilGenerator.Emit(OpCodes.Callvirt, returnValueGetMethod);

            return ilGenerator;
        }
    }
}
