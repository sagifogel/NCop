using System;
using System.Reflection.Emit;
using NCop.Core.Exceptions;
using NCop.Core.Extensions;
using NCop.Mixins.Exceptions;
using NCop.Weaving.Properties;

namespace NCop.Weaving
{
    public abstract class AbstractTypeDefinition : ITypeDefinition
    {
        private readonly FieldBuilder fieldBuilder = null;

        protected AbstractTypeDefinition(Type mixinType, TypeBuilder typeBuilder) {
            Type = mixinType;
            TypeBuilder = typeBuilder;
            fieldBuilder = new FieldWeaver(typeBuilder, mixinType).Weave();

            if (!ReferenceEquals(mixinType, fieldBuilder.FieldType)) {
                var message = Resources.MixinTypeDiffersFromFieldBuilderType.Fmt(mixinType.FullName, fieldBuilder.FieldType);

                throw new TypeDefinitionInitializationException(message);
            }
        }

        public Type Type { get; private set; }

        public TypeBuilder TypeBuilder { get; private set; }

        public FieldBuilder GetFieldBuilder(Type mixinType) {
            if (!ReferenceEquals(Type, mixinType)) {
                var message = Resources.CouldNotFindFieldBuilderByType.Fmt(mixinType.FullName);

                throw new MissingFieldBuilderException(message);
            }

            return fieldBuilder;
        }
    }
}
