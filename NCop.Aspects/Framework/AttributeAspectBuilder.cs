using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Framework
{
    public class AttributeAspectBuilder : IAspectBuilder
    {
        private Type _type = null;
        private IAspectProvider _provider = null;

        public AttributeAspectBuilder(Type type, IAspectProvider provider) {
            _type = type;
            _provider = provider;
        }

        public IAspect Build() {
            return AspectsRepository.Instance.GetOrAdd(_type, _provider);
        }
    }
}
