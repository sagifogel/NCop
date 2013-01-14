using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using NCop.Core.Mixin;
using NCop.Core.Weaving;

namespace NCop.Mixins.Weaving
{
	public class MixinsTypeDefinitionWeaver : ITypeDefinitionWeaver
	{
		private readonly TypeBuilder _typeBuilder = null;
		private readonly IEnumerable<MixinMap> _mixinMap = null;

		public MixinsTypeDefinitionWeaver(TypeBuilder typeBuilder, IEnumerable<MixinMap> mixinMap) {
			_mixinMap = mixinMap;
			_typeBuilder = typeBuilder;
		}

		public Type Type { get; private set; }

		public ITypeDefinition Weave() {
			throw new NotImplementedException();
		}
	}
}
