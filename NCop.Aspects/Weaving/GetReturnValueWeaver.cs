using NCop.Weaving;
using NCop.Weaving.Extensions;
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
            var argumentType = argumentsWeavingSetings.ArgumentType;

            argsImplLocalBuilder = localBuilderRepository.Get(argumentType);
            ilGenerator.EmitLoadLocal(argsImplLocalBuilder);
            returnValueGetMethod = argumentType.GetProperty("ReturnValue").GetGetMethod();
            ilGenerator.Emit(OpCodes.Callvirt, returnValueGetMethod);

            return ilGenerator;
        }
    }
}
