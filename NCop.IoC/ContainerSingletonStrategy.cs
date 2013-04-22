using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NCop.IoC
{
	internal class ContainerSingletonStrategy : AbstractLifetimeStrategy
	{
		public ContainerSingletonStrategy(INCopContainer container, object instance = null)
			: base(container) {
		}

		public override TService Resolve<TService>(ResolveContext<TService> context) {
			if (context.Container.Equals(this.container)) {
				return (TService)(instance ?? ExchangeInstanceConditionally(ref instance, context.Factory));
			}

			return CloneAndResolve<TService>(context);
		}

		private TService CloneAndResolve<TService>(ResolveContext<TService> context) {
			return CloneAndResolve<TService>(context.Key, context.Entry, context.Container, context.Factory);
		}

		private TService CloneAndResolve<TService>(ServiceKey key, ServiceEntry entry, NCopContainer container, Func<TService> factory) {
			ServiceEntry clonedEntry = entry.CloneFor(container);
			
			container.LateRegister(key, clonedEntry);

			var context = new ResolveContext<TService> {
				Key = key,
				Factory = factory,
				Entry = clonedEntry,
				Container = container
			};
			
			return (TService)clonedEntry.LifetimeStrategy.Resolve<TService>(context);
		}

		private object ExchangeInstanceConditionally<TService>(ref object instance, Func<TService> factory) {
			Interlocked.CompareExchange(ref instance, factory(), null);

			return instance;
		}
	}
}