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
        private readonly Type _contract = null;
        private readonly IMixinsMap _mixinsMap = null;

        public MixinsTypeDefinitionWeaver(Type contract, IMixinsMap mixinMap) {
            _contract = contract;
            _mixinsMap = mixinMap;
		}

		public Type Type { get; private set; }

        public ITypeDefinition Weave() {
           var interfaces = _mixinsMap.Select(mixin => mixin.Contract);
            var typeBuilder = _contract.DefineType(_contract.Attributes, interfaces);

            return null;
		}
	}
}
