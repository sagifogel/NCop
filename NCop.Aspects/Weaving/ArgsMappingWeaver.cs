using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class AbstractAspectArgsMappingWeaver : IWeaver, IMethodScopeWeaver
    {
        protected readonly Type[] parameters = null;
        protected readonly Type aspectArgumentType = null;
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
            parameters = @params.Skip(1).ToArray();
        }

        public virtual ILGenerator Weave(ILGenerator ilGenerator) {
            MethodInfo mapGenericMethod = null;
            Func<int, MethodInfo> getMappingArgsMethod = null;
            var argsImplLocalBuilder = localBuilderRepository.Get(aspectArgumentType);

            getMappingArgsMethod = argumentsSettings.IsFunction ?
                                        aspectWeavingSettings.AspectArgsMapper.GetMappingArgsFunction :
                                        (Func<int, MethodInfo>)aspectWeavingSettings.AspectArgsMapper.GetMappingArgsAction;

            mapGenericMethod = getMappingArgsMethod(parameters.Length);
            mapGenericMethod = mapGenericMethod.MakeGenericMethod(parameters);

            ilGenerator.EmitLoadLocal(argsImplLocalBuilder);
            ilGenerator.EmitLoadArg(2);
            ilGenerator.Emit(OpCodes.Call, mapGenericMethod);

            return ilGenerator;
        }
    }
}
