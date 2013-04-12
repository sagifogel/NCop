using System;
using System.Reflection.Emit;
using NCop.Core.Exceptions;
using NCop.Core.Weaving;
using NCop.Core.Extensions;

namespace NCop.Core.Weaving
{
    public class MixinTypeDefinition : ITypeDefinition
    {
        private readonly FieldBuilder _fieldBuilder = null;

        public MixinTypeDefinition(Type mixinType, TypeBuilder typeBuilder) {
            Type = mixinType;
            TypeBuilder = typeBuilder;
            _fieldBuilder = typeBuilder.DefineField(mixinType);

            if (!mixinType.Equals(_fieldBuilder.FieldType)) {
                throw new TypeDefinitionInitializationException("Type of Mixin does not equals to the field type of the FieldBuilder");
            }
        }

        public Type Type { get; private set; }

        public TypeBuilder TypeBuilder { get; private set; }

        public FieldBuilder GetOrAddFieldBuilder(Type type) {
            if (Type.Equals(type)) {
                return _fieldBuilder;
            }

            return null;
        }
    }
}
