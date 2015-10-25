using NCop.Core;
using System;

namespace NCop.Weaving
{
	public class MixinTypeDefinitionWeaver : ITypeDefinitionWeaver
	{
		private readonly TypeMap mixinMap = null;

		public MixinTypeDefinitionWeaver(TypeMap mixinMap) {
			this.mixinMap = mixinMap;
			Type = mixinMap.ServiceType;
		}

		public Type Type { get; private set; }
		
		public ITypeDefinition Weave() {
			throw new NotImplementedException();
		}
	}
}
