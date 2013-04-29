using NCop.Core.Mixin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Weaving
{
	public class MixinTypeDefinitionWeaver : ITypeDefinitionWeaver
	{
		private readonly MixinMap mixinMap = null;

		public MixinTypeDefinitionWeaver(MixinMap mixinMap) {
			this.mixinMap = mixinMap;
			Type = mixinMap.Contract;
		}

		public Type Type { get; private set; }
		
		public ITypeDefinition Weave() {
			throw new NotImplementedException();
		}
	}
}
