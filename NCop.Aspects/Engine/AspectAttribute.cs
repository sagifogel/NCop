using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Aspects.Framework;
using NCop.Aspects.LifetimeStrategies;

namespace NCop.Aspects.Engine
{
    public abstract class AspectAttribute : Attribute, IAspectBuilderProvider
    {
        private WellKnownLifetimeStrategy _wellKnownLifetimeStrategy;
        private static readonly string _liftimeStrategiesNamespace = "NCop.Aspects.LifetimeStrategies";

        public AspectAttribute(WellKnownLifetimeStrategy lifetimeStrategy = LifetimeStrategies.WellKnownLifetimeStrategy.Singleton) {
            _wellKnownLifetimeStrategy = lifetimeStrategy;
        }

        public virtual IAspectBuilder GetBuilder(Type type, Func<Type, ILifetimeStrategy> lifetimeStrategyFactory = null) {
            ILifetimeStrategy lifetimeStrategy = null;

            lifetimeStrategyFactory = lifetimeStrategyFactory ?? CreateLifetimeStrategy;
            lifetimeStrategy = lifetimeStrategyFactory(type);

            return new AttributeAspectBuilder(type, lifetimeStrategy);
        }

        private ILifetimeStrategy CreateLifetimeStrategy(Type type) {
            var lifetimeStrategyRepresentation = string.Format("{0}.{1}LifetimeStrategy", _liftimeStrategiesNamespace, _wellKnownLifetimeStrategy);
            var lifetimeStrategyType = Type.GetType(lifetimeStrategyRepresentation);

            return (ILifetimeStrategy)Activator.CreateInstance(lifetimeStrategyType, new object[] { new AspectByReflectionFactory(GetType()) });
        }
    }
}
