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
    internal class NestedByRefParamsMethodDecoratorWeaver : AbstractArgumentsWeaver
    {
        private readonly Type aspectArgsType = null;
        private readonly LocalBuilder argsLocalBuilder;
        private readonly ParameterInfo[] parameters = null;
        private IDictionary<int, LocalBuilder> localBuilderMap = null;
        
        internal NestedByRefParamsMethodDecoratorWeaver(Type previousAspectArgType, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentWeavingSettings)
            : base(argumentWeavingSettings, aspectWeavingSettings) {
            localBuilderMap = new Dictionary<int, LocalBuilder>();
            aspectArgsType = Parameters.ToAspectArgument(IsFunction);
            parameters = WeavingSettings.MethodInfoImpl.GetParameters();
            argsLocalBuilder = LocalBuilderRepository.Get(previousAspectArgType);
        }

        internal void StoreLocals(ILGenerator ilGenerator) {
            var @params = parameters.Where(param => param.ParameterType.IsByRef);

            @params.ForEach(param => {
                var property = aspectArgsType.GetProperty("Arg{0}".Fmt(param.Position));
                var localBuilder = ilGenerator.DeclareLocal(param.ParameterType);

                ilGenerator.EmitLoadLocal(argsLocalBuilder);
                ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
                localBuilderMap.Add(param.Position, localBuilder);
                ilGenerator.EmitStoreLocal(localBuilder);
            });
        }

        public override void Weave(ILGenerator ilGenerator) {
            var contractFieldBuilder = WeavingSettings.TypeDefinition.GetFieldBuilder(WeavingSettings.ContractType);

            StoreLocals(ilGenerator);
            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);

            parameters.ForEach(param => {
                LocalBuilder localBuilder;

                if (localBuilderMap.TryGetValue(param.Position, out localBuilder)) {
                    ilGenerator.EmitLoadLocal(localBuilder);
                }
                else {
                    var property = aspectArgsType.GetProperty("Arg{0}".Fmt(param.Position));
                    
                    ilGenerator.EmitLoadLocal(argsLocalBuilder);
                    ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
                }
            });

            RestoreLocals(ilGenerator);
        }

        internal void RestoreLocals(ILGenerator ilGenerator) {
            localBuilderMap.ForEach(paramKeyValue => {
                var property = aspectArgsType.GetProperty("Arg{0}".Fmt(paramKeyValue.Key));
 
                ilGenerator.EmitLoadLocal(argsLocalBuilder);
                ilGenerator.EmitLoadLocal(paramKeyValue.Value);
                ilGenerator.Emit(OpCodes.Callvirt, property.GetSetMethod());
            });  
        }
    }
}
