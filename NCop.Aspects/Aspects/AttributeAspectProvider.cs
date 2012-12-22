using NCop.Aspects.Extensions;
using NCop.Aspects.LifetimeStrategies;
using System;

namespace NCop.Aspects.Aspects
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
