using System;
using System.Reflection.Emit;
using NCop.Core.Exceptions;
using NCop.Core.Weaving;

namespace NCop.Core.Weaving
{
	public class MixinTypeDefinition : ITypeDefinition
	{
		private readonly FieldBuilder _fieldBuilder = null;

		public MixinTypeDefinition(Type mixinType, TypeBuilder typeBuilder, FieldBuilder fieldBuilder) {
			Type = mixinType;
			TypeBuilder = typeBuilder;
			_fieldBuilder = fieldBuilder;

			if (!mixinType.Equals(typeBuilder.DeclaringType)) {
				throw new TypeDefinitionInitializationException("Type of Mixin does not equals to the declaring type of the TypeBuilder");
			}

			if (!mixinType.Equals(fieldBuilder.FieldType)) {
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
