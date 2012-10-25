using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Engine
{
    public class AttributeAspectProvider : IAspectProvider
    {
        private IAspectDefinition _aspectDefinition = null;
        private readonly ILifetimeStrategy _lifetimeStrategy = null;

        public AttributeAspectProvider(Type aspectType) {
            _lifetimeStrategy = aspectType.GetLifetimeStrategy();
        }

        public IAspect Aspect {
            get {
                return _lifetimeStrategy.GetAspect();
            }
        }
    }
}
