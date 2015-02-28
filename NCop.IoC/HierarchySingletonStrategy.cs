using System;
using System.Threading;

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
