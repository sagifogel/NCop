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
    public class MixinsTypeDefinition : ITypeDefinition, ITypeDefinitionIntilaizer
    {
        protected readonly ITypeMap mixinsMap = null;
        protected readonly IDictionary<Type, IFieldBuilderDefinition> typeDefinitions = new Dictionary<Type, IFieldBuilderDefinition>();
        private static readonly MethodAttributes attrs = MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName;

        public MixinsTypeDefinition(Type mixinsType, ITypeMap mixinsMap) {
            Type = mixinsType;
            this.mixinsMap = mixinsMap;
        }

        public virtual ITypeDefinition Initialize() {
            CreateTypeBuilder();
            CreateTypeDefinitions();
            CreateDefaultConstructor();

            return this;
        }

        public Type Type { get; protected set; }

        public TypeBuilder TypeBuilder { get; protected set; }

        public FieldBuilder GetFieldBuilder(Type type) {
            IFieldBuilderDefinition mixinTypeDefinition;

            if (!typeDefinitions.TryGetValue(type, out mixinTypeDefinition)) {
                throw new MissingFieldBuilderException(Resources.CouldNotFindFieldBuilderByType.Fmt(type.FullName));
            }

            return mixinTypeDefinition.FieldBuilder;
        }

        protected virtual void CreateTypeBuilder() {
            TypeBuilder = typeof(object).DefineType(Type.ToUniqueName(), new[] { Type });
        }

        protected virtual void CreateTypeDefinitions() {
            mixinsMap.ForEach(mixin => {
                var mixinTypeDefinition = new MixinFieldBuilderDefinition(mixin.ContractType, TypeBuilder);

                typeDefinitions.Add(mixin.ContractType, mixinTypeDefinition);
            });
        }

        protected virtual void CreateDefaultConstructor() {
            var ctorBuilder = DefineConstructor();
            var ilGenerator = ctorBuilder.GetILGenerator();

            EmitConstructorBody(ilGenerator);
            ilGenerator.Emit(OpCodes.Ret);
        }

        protected virtual ConstructorBuilder DefineConstructor() {
            var @params = mixinsMap.ToArray(map => map.ContractType);
            var ctorBuilder = TypeBuilder.DefineConstructor(attrs, CallingConventions.HasThis, @params);

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
                var mixinTypeDefinition = typeDefinitions[contractType];

                ilGenerator.Emit(OpCodes.Ldarg_0);
                ilGenerator.EmitLoadArg(i);
                ilGenerator.Emit(OpCodes.Stfld, mixinTypeDefinition.FieldBuilder);
            });
        }
    }
}
