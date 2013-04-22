using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
	internal abstract class AbstractLifetimeStrategy : ILifetimeStrategy
	{
		protected object instance = null;
		protected readonly INCopContainer container = null;

		internal AbstractLifetimeStrategy(INCopContainer container) {
			this.container = container;
		}

		public abstract TService Resolve<TService>(ResolveContext<TService> context);
	}
}
