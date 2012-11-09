using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Extensions;
using NCop.Core.Aspects;

namespace NCop.Aspects.Engine
{
    public class AttributeAspectProvider : IAspectProvider
    {
        private readonly ILifetimeStrategy _lifetimeStrategy = null;

        public AttributeAspectProvider(Type aspectType) {
            Type = aspectType;
            _lifetimeStrategy = aspectType.GetLifetimeStrategy();
        }

        public Type Type { get; private set; }

        public IAspect Aspect {
            get {
                return _lifetimeStrategy.Aspect;
            }
        }
    }
}
