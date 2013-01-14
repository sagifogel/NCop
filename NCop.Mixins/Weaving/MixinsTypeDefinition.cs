using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Weaving;
using System.Reflection.Emit;

namespace NCop.Mixins.Weaving
{
	public class MixinsTypeDefinition : ITypeDefinition
	{
		private readonly Dictionary<Type, MixinTypeDefinition> _mixinTypeDefinition = null;

		public MixinsTypeDefinition(Type mixinsType, TypeBuilder typeBuilder, IEnumerable<MixinTypeDefinition> mixinTypeDefinition) {
			Type = mixinsType;
			TypeBuilder = typeBuilder;
			_mixinTypeDefinition = mixinTypeDefinition.ToDictionary(mixin => mixin.Type);
		}

		public Type Type { get; private set; }

		public TypeBuilder TypeBuilder { get; private set; }

		public FieldBuilder GetOrAddFieldBuilder(Type type) {
			MixinTypeDefinition mixinTypeDefinition = null;

			if (_mixinTypeDefinition.TryGetValue(type, out mixinTypeDefinition)) {
				return mixinTypeDefinition.GetOrAddFieldBuilder(type);
			}

			return null;
		}
	}
}
