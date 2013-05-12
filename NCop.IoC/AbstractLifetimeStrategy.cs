using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
	internal abstract class AbstractLifetimeStrategy : ILifetimeStrategy
	{
		protected object instance = null;
		
		public abstract TService Resolve<TService>(ResolveContext<TService> context);
	}
}
