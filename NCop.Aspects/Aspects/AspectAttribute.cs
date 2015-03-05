using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
	public abstract class AspectAttribute : Attribute, IAspect
	{
		protected AspectAttribute(Type aspectType) {
            var lifetimeStrategyAttr = aspectType.GetCustomAttribute<AspectLifetimeStrategyAttribute>();
            var lifetimeStrategy = (lifetimeStrategyAttr ?? new SingletonAspectAttribute()).LifetimeStrategy;
            
            AspectType = aspectType;
            LifetimeStrategy = lifetimeStrategy;
		}

		public int AspectPriority { get; set; }
		public Type AspectType { get; private set; }
        public LifetimeStrategy LifetimeStrategy { get; internal set; }
    }
}
