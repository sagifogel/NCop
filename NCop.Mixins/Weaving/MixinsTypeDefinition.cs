using NCop.Core;
using NCop.Core.Extensions;
using NCop.Mixins.Exceptions;
using NCop.Weaving;
using NCop.Weaving.Properties;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NCop.Mixins.Weaving
{
    public class MixinsTypeDefinition : ITypeDefinition, ITypeDefinitionIntilaizer
    {
        protected readonly ITypeMap mixinsMap = null;
        protected readonly IDictionary<Type, IFieldBuilderDefinition> typeDefinitions = new Dictionary<Type, IFieldBuilderDefinition>();

        public MixinsTypeDefinition(Type mixinsType, ITypeMap mixinsMap) {
            Type = mixinsType;
            this.mixinsMap = mixinsMap;
        }

        public virtual ITypeDefinition Initialize() {
            CreateTypeBuilder();
            CreateTypeDefinitions();
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
    }
}
