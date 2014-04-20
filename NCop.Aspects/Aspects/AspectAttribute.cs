using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;
using NCop.Aspects.Framework;
using System.Reflection;

namespace NCop.Aspects.Aspects
{
	public abstract class AspectAttribute : Attribute, IAspect
	{
		public AspectAttribute(Type aspectType) {
            var lifetimeStrategyAttr = aspectType.GetCustomAttribute<AspectLifetimeStrategyAttribute>();
            var lifetimeStrategy = (lifetimeStrategyAttr ?? new SingletonAspectAttribute()).LifetimeStrategy;
            
            AspectType = aspectType;
            LifetimeStrategy = lifetimeStrategy;
		}

		public int AspectPriority { get; set; }
		public Type AspectType { get; private set; }
        public LifetimeStrategy LifetimeStrategy { get; private set; }
    }
}
