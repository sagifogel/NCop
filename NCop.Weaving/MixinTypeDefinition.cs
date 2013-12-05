using System;
using System.Reflection.Emit;
using NCop.Core.Exceptions;
using NCop.Weaving;
using NCop.Core.Extensions;
using NCop.Weaving.Properties;
using NCop.Mixins.Exceptions;

namespace NCop.Weaving
{
	public class MixinTypeDefinition : ITypeDefinition
	{
		private readonly FieldBuilder fieldBuilder = null;

		public MixinTypeDefinition(Type mixinType, TypeBuilder typeBuilder) {
			Type = mixinType;
			TypeBuilder = typeBuilder;
			fieldBuilder = new FieldWeaver(typeBuilder, mixinType).Weave();

			if (!mixinType.Equals(fieldBuilder.FieldType)) {
				var message = Resources.MixinTypeDiffersFromFieldBuilderType.Fmt(mixinType.FullName, fieldBuilder.FieldType);

				throw new TypeDefinitionInitializationException(message);
			}
		}

		public Type Type { get; private set; }

		public TypeBuilder TypeBuilder { get; private set; }

		public FieldBuilder GetFieldBuilder(Type mixinType) {
			if (!Type.Equals(mixinType)) {
				var message = Resources.CouldNotFindFieldBuilderByType.Fmt(mixinType.FullName);

				throw new MissingFieldBuilderException(message);
			}

			return fieldBuilder;
		}
	}
}
