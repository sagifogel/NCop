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
    internal class OptionalByRefParamsMethodDecoratorWeaver : IAspectWeaver, IByRefArgumentsStoreWeaver
    {
        protected LocalBuilder argsLocalBuilder;
        protected readonly Type[] parameters = null;
        protected readonly Type aspectArgsType = null;
        protected readonly Type previousAspectArgType = null;
        protected readonly IWeavingSettings weavingSettings = null;
        protected readonly ParameterInfo[] methodImplParameters = null;
        protected readonly ILocalBuilderRepository localBuilderRepository = null;
        protected readonly ISet<int> byRefParamslocalBuilderMap = null;

        internal OptionalByRefParamsMethodDecoratorWeaver(Type previousAspectArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentsWeavingSettings) {
            this.previousAspectArgType = previousAspectArgType;
            byRefParamslocalBuilderMap = new HashSet<int>();
            parameters = new Type[argumentsWeavingSettings.Parameters.Length];
            localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            argumentsWeavingSettings.Parameters.CopyTo(parameters, 0);
            weavingSettings = aspectWeavingSettings.WeavingSettings;
            aspectArgsType = argumentsWeavingSettings.Parameters.ToAspectArgument(argumentsWeavingSettings.IsFunction);
            methodImplParameters = weavingSettings.MethodInfoImpl.GetParameters();
        }

        public virtual void StoreLocalsIfNeeded(ILGenerator ilGenerator) {
            var @params = methodImplParameters.Where(param => param.ParameterType.IsByRef);
            
            @params.ForEach(param => {
                int argPosition = param.Position + 1;
                var property = previousAspectArgType.GetProperty("Arg{0}".Fmt(argPosition));

                ilGenerator.EmitLoadArg(argPosition);
                byRefParamslocalBuilderMap.Add(argPosition);
                ilGenerator.EmitLoadLocal(argsLocalBuilder);
                ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
                ilGenerator.Emit(OpCodes.Stind_I4);
            });
        }

        public ILGenerator Weave(ILGenerator ilGenerator) {
            argsLocalBuilder = localBuilderRepository.Get(previousAspectArgType);
            StoreLocalsIfNeeded(ilGenerator);
            LoadArgs(ilGenerator);
            WeaveMethodBody(ilGenerator);
            RestoreLocals(ilGenerator);

            return ilGenerator;
        }

        protected virtual void WeaveMethodBody(ILGenerator ilGenerator) {
            ilGenerator.Emit(OpCodes.Callvirt, weavingSettings.MethodInfoImpl);
        }

        protected virtual void LoadArgs(ILGenerator ilGenerator) {
            var contractFieldBuilder = weavingSettings.TypeDefinition.GetFieldBuilder(weavingSettings.ContractType);

            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);

            methodImplParameters.ForEach(param => {
                int argPosition = param.Position + 1;

                if (byRefParamslocalBuilderMap.Contains(argPosition)) {
                    ilGenerator.EmitLoadArg(argPosition);
                }
                else {
                    var property = previousAspectArgType.GetProperty("Arg{0}".Fmt(param.Position + 1));

                    ilGenerator.EmitLoadLocal(argsLocalBuilder);
                    ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
                }
            });
        }

        public virtual void RestoreLocals(ILGenerator ilGenerator) {
            byRefParamslocalBuilderMap.ForEach(argPosition => {
                var property = previousAspectArgType.GetProperty("Arg{0}".Fmt(argPosition));

                ilGenerator.EmitLoadLocal(argsLocalBuilder);
                ilGenerator.EmitLoadArg(argPosition);
                ilGenerator.Emit(OpCodes.Ldind_I4);
                ilGenerator.Emit(OpCodes.Callvirt, property.GetSetMethod());
            });
        }
    }
}
