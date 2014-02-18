using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.IoC;
using StructureMap;

namespace NCop.Samples
{
	public class StructureMapAdapter : INCopDependencyContainerAdapter
	{
		private readonly IContainer container = null;

		public StructureMapAdapter() {
			container = ObjectFactory.Container;
		}

		private StructureMapAdapter(IContainer container) {
			this.container = container;
		}

		public void Configure() { }

		public TService Resolve<TService>() {
			return container.GetInstance<TService>();
		}

		public TService TryResolve<TService>() {
			return container.TryGetInstance<TService>();
		}

		public TService ResolveNamed<TService>(string name) {
			return container.GetInstance<TService>(name);
		}

		public TService TryResolveNamed<TService>(string name) {
			return container.TryGetInstance<TService>(name);
		}

		public void Dispose() {
			container.Dispose();
		}

		public INCopDependencyResolver CreateChildContainer() {
			return new StructureMapAdapter(container.GetNestedContainer());
		}

		public void Register(Type concreteType, Type serviceType) {
			container.Configure(x => {
				var ctor = concreteType.GetConstructors()[0];
				var @params = ctor.GetParameters();
				var use = x.For(serviceType)
						   .Use(concreteType);

				foreach (var item in @params) {
					var value = ObjectFactory.GetInstance(item.ParameterType);

					use.WithCtorArg(item.Name).EqualTo(value);
				}
			});
		}
	}
}
