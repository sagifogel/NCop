using NCop.Composite.Framework;
using NCop.IoC;
using System;
using System.Reflection;
using NCop.Composite.Extensions;

namespace NCop.Composite.IoC
{
	internal class CompositeContainerAdapter : INCopDependencyContainerAdapter
	{
		private readonly NCopContainer container = null;

		public CompositeContainerAdapter() {
			container = new NCopContainer();
		}

		public void Configure() {
			container.Configure();
		}

		public TService Resolve<TService>() {
			return container.Resolve<TService>();
		}

		public TService TryResolve<TService>() {
			return container.TryResolve<TService>();
		}

		public TService ResolveNamed<TService>(string name) {
			return container.ResolveNamed<TService>(name);
		}

		public TService TryResolveNamed<TService>(string name) {
			return container.TryResolveNamed<TService>(name);
		}

		public void Dispose() {
			container.Dispose();
		}

		public INCopDependencyResolver CreateChildContainer() {
			return container.CreateChildContainer();
		}

		public void Register(Type concreteType, Type serviceType, string name = null) {
            var castAs = serviceType.GetTypeFromAttribute();
            var compositeRegistration = new CompositeFrameworkRegistration(concreteType, serviceType, castAs);

            container.Register(compositeRegistration);
        }
	}
}
