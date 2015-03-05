using NCop.Core;
using NCop.Core.Extensions;
using NCop.Mixins.Exceptions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using NCop.Weaving.Properties;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Mixins.Weaving
{
    internal class MixinsTypeDefinition : ITypeDefinition
    {
        private readonly ITypeMap mixinsMap = null;
        private readonly Dictionary<Type, MixinTypeDefinition> mixinTypeDefinitions = null;

        internal MixinsTypeDefinition(Type mixinsType, ITypeMap mixinsMap) {
            Type = mixinsType;
            this.mixinsMap = mixinsMap;
            mixinTypeDefinitions = new Dictionary<Type, MixinTypeDefinition>();
            CreateTypeBuilder();
            CreateMixinTypeDefinitions();
            CreateDefaultConstructor();
        }

        public Type Type { get; private set; }

        public TypeBuilder TypeBuilder { get; private set; }

        public FieldBuilder GetFieldBuilder(Type type) {
            MixinTypeDefinition mixinTypeDefinition;

            if (!mixinTypeDefinitions.TryGetValue(type, out mixinTypeDefinition)) {
                throw new MissingFieldBuilderException(Resources.CouldNotFindFieldBuilderByType.Fmt(type.FullName));
            }

            return mixinTypeDefinition.GetFieldBuilder(type);
        }

        private void CreateTypeBuilder() {
            TypeBuilder = typeof(object).DefineType(Type.ToUniqueName(), new[] { Type });
        }

        private void CreateMixinTypeDefinitions() {
            mixinsMap.ForEach(mixin => {
                var mixinTypeDefinition = new MixinTypeDefinition(mixin.ContractType, TypeBuilder);

                mixinTypeDefinitions.Add(mixin.ContractType, mixinTypeDefinition);
            });
        }

        private void CreateDefaultConstructor() {
            ILGenerator ilGenerator = null;
            var attr = MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName;
            var @params = mixinsMap.ToArray(map => map.ContractType);
            var ctorBuilder = TypeBuilder.DefineConstructor(attr, CallingConventions.HasThis, @params);

            @params.ForEach(1, (param, i) => {
                ctorBuilder.DefineParameter(i, ParameterAttributes.None, "param{0}".Fmt(i));
            });

            ilGenerator = ctorBuilder.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));

            mixinsMap.ForEach(1, (map, i) => {
                var contractType = map.ContractType;
                var mixinTypeDefinition = mixinTypeDefinitions[contractType];
                var fieldBuilder = mixinTypeDefinition.GetFieldBuilder(contractType);

                ilGenerator.Emit(OpCodes.Ldarg_0);
                ilGenerator.EmitLoadArg(i);
                ilGenerator.Emit(OpCodes.Stfld, fieldBuilder);
            });

            ilGenerator.Emit(OpCodes.Ret);
        }
    }
}
