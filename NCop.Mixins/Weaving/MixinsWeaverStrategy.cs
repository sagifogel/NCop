using NCop.Core;
using NCop.Core.Extensions;
using NCop.IoC;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using MA = System.Reflection.MethodAttributes;

namespace NCop.Mixins.Weaving
{
    public class MixinsWeaverStrategy : ITypeWeaver
    {
        protected readonly ITypeMap mixinsMap = null;
        protected readonly ITypeDefinition typeDefinition = null;
        protected readonly INCopDependencyAwareRegistry registry = null;
        protected readonly IEnumerable<IMethodWeaver> methodWeavers = null;
        private static readonly MethodAttributes attrs = MA.Public | MA.HideBySig | MA.SpecialName | MA.RTSpecialName;

        public MixinsWeaverStrategy(ITypeDefinition typeDefinition, ITypeMap mixinsMap, IEnumerable<IMethodWeaver> methodWeavers, INCopDependencyAwareRegistry registry) {
            this.registry = registry;
            this.mixinsMap = mixinsMap;
            this.methodWeavers = methodWeavers;
            this.typeDefinition = typeDefinition;
        }

        public void Weave() {
            Type weavedType = null;

            methodWeavers.ForEach(methodWeaver => {
                var methodBuilder = methodWeaver.DefineMethod();
                var ilGenerator = methodBuilder.GetILGenerator();

                methodWeaver.WeaveMethodScope(ilGenerator);
                methodWeaver.WeaveEndMethod(ilGenerator);
                return;
            });

            CreateDefaultConstructor();
            weavedType = typeDefinition.TypeBuilder.CreateType();
            registry.Register(weavedType, typeDefinition.Type, mixinsMap, isComposite: true);
        }

        protected virtual void CreateDefaultConstructor() {
            var ctorBuilder = DefineConstructor();
            var ilGenerator = ctorBuilder.GetILGenerator();

            EmitConstructorBody(ilGenerator);
            ilGenerator.Emit(OpCodes.Ret);
        }

        protected virtual ConstructorBuilder DefineConstructor() {
            var @params = mixinsMap.ToArray(map => map.ContractType);
            var ctorBuilder = typeDefinition.TypeBuilder.DefineConstructor(attrs, CallingConventions.HasThis, @params);

            @params.ForEach(1, (param, i) => {
                ctorBuilder.DefineParameter(i, ParameterAttributes.None, "param{0}".Fmt(i));
            });

            return ctorBuilder;
        }

        protected virtual void EmitConstructorBody(ILGenerator ilGenerator) {
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));

            mixinsMap.ForEach(1, (map, i) => {
                var contractType = map.ContractType;
                var mixinTypeDefinition = typeDefinition.GetFieldBuilder(contractType);

                ilGenerator.Emit(OpCodes.Ldarg_0);
                ilGenerator.EmitLoadArg(i);
                ilGenerator.Emit(OpCodes.Stfld, mixinTypeDefinition);
            });
        }
    }
}
