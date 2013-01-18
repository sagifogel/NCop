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

		public MixinTypeDefinitionWeaver(MixinMap mixinMap) {
			_mixinMap = mixinMap;
			Type = mixinMap.Contract;
		}

		public Type Type { get; private set; }
		
		public ITypeDefinition Weave() {
			throw new NotImplementedException();
		}
	}
}
