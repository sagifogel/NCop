using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NCop.Core.Extensions;

namespace NCop.IoC
{
	internal class HierarchySingletonStrategy : AbstractLifetimeStrategy
	{
		public override TService Resolve<TService>(ResolveContext<TService> context) {
			return (TService)(instance ?? CreateInstance(context.Factory));
		}

		private object CreateInstance<TService>(Func<TService> factory) {
			Interlocked.CompareExchange(ref instance, factory(), null);

			return instance;
		}
	}
}
