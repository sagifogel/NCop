using NCop.Core.Mixin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Core.Weaving
{
	public class MixinTypeDefinitionWeaver : ITypeDefinitionWeaver
	{
		private readonly MixinMap _mixinMap = null;
		private readonly TypeBuilder _typeBuilder = null;

		public MixinTypeDefinitionWeaver(TypeBuilder typeBuilder, MixinMap mixinMap) {
			_mixinMap = mixinMap;
			_typeBuilder = typeBuilder;
			Type = mixinMap.Contract;
		}

		public Type Type { get; private set; }
		
		public ITypeDefinition Weave() {
			throw new NotImplementedException();
		}
	}
}
