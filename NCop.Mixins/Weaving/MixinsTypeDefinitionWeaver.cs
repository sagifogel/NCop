using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using NCop.Core.Mixin;
using NCop.Core.Weaving;
using NCop.Mixins.Engine;

namespace NCop.Mixins.Weaving
{
	public class MixinsTypeDefinitionWeaver : ITypeDefinitionWeaver
	{
        private readonly IMixinsMap _mixinsMap = null;

        public MixinsTypeDefinitionWeaver(IMixinsMap mixinMap) {
			_mixinsMap = mixinMap;
		}

		public Type Type { get; private set; }

        public ITypeDefinition Weave() {
			throw new NotImplementedException();
		}
	}
}
