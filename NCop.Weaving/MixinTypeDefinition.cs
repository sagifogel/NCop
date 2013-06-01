using System;
using System.Reflection.Emit;
using NCop.Core.Exceptions;
using NCop.Weaving;
using NCop.Core.Extensions;

namespace NCop.Weaving
{
    public class MixinTypeDefinition : ITypeDefinition
    {
        private readonly FieldBuilder fieldBuilder = null;

        public MixinTypeDefinition(Type mixinType, TypeBuilder typeBuilder) {
            Type = mixinType;
            TypeBuilder = typeBuilder;
            fieldBuilder = new FieldWeaver(mixinType).Weave(typeBuilder);

            if (!mixinType.Equals(fieldBuilder.FieldType)) {
                throw new TypeDefinitionInitializationException("Type of Mixin does not equals to the field type of the FieldBuilder");
            }
        }

        public Type Type { get; private set; }

        public TypeBuilder TypeBuilder { get; private set; }

        public FieldBuilder GetOrAddFieldBuilder(Type type) {
            if (Type.Equals(type)) {
                return fieldBuilder;
            }

            return null;
        }
    }
}
