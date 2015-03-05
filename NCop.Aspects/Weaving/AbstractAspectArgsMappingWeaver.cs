using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractAspectArgsMappingWeaver : IMethodScopeWeaver
    {
        protected readonly Type[] parameters = null;
        protected readonly Type aspectArgumentType = null;
        protected readonly Type[] mappingParameters = null;
        protected readonly IWeavingSettings weavingSettings = null;
        protected readonly IArgumentsSettings argumentsSettings = null;
        protected readonly IAspectWeavingSettings aspectWeavingSettings = null;
        protected readonly ILocalBuilderRepository localBuilderRepository = null;

        internal AbstractAspectArgsMappingWeaver(IAspectWeavingSettings aspectWeavingSettings, IArgumentsSettings argumentsSettings) {
            Type[] @params = null;

            this.argumentsSettings = argumentsSettings;
            this.aspectWeavingSettings = aspectWeavingSettings;
            aspectArgumentType = argumentsSettings.ArgumentType;
            weavingSettings = aspectWeavingSettings.WeavingSettings;
            localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            @params = argumentsSettings.ArgumentType.GetGenericArguments();
            parameters = argumentsSettings.Parameters;
            mappingParameters = @params.Skip(1).ToArray();
        }

        public virtual void Weave(ILGenerator ilGenerator) {
            MethodInfo mapGenericMethod = null;
            Func<int, MethodInfo> getMappingArgsMethod = null;
            var argsImplLocalBuilder = localBuilderRepository.Get(aspectArgumentType);

            if (mappingParameters.Length > 0) {
                getMappingArgsMethod = argumentsSettings.IsFunction ?
                                            aspectWeavingSettings.AspectArgsMapper.GetFunctionMappingArgs :
                                            (Func<int, MethodInfo>)aspectWeavingSettings.AspectArgsMapper.GetActionMappingArgs;

                mapGenericMethod = getMappingArgsMethod(mappingParameters.Length);
                mapGenericMethod = mapGenericMethod.MakeGenericMethod(mappingParameters);

                ilGenerator.EmitLoadLocal(argsImplLocalBuilder);
                WeaveAspectArg(ilGenerator);
                ilGenerator.Emit(OpCodes.Call, mapGenericMethod);
            }
        }

        protected abstract void WeaveAspectArg(ILGenerator ilGenerator);
    }
}
