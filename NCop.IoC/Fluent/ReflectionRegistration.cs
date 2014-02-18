using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;

namespace NCop.IoC.Fluent
{
	public class ReflectionRegistration : AutoRegistration<object>
	{
		protected Type concreteType = null;

		public ReflectionRegistration(Type concreteType, Type serviceType)
			: base(serviceType, MakeFactoryType(serviceType)) {
			this.concreteType = concreteType;
			As(Registration.CastTo = concreteType);
		}

		private static Type MakeFactoryType(Type serviceType) {
			return typeof(Func<,>).MakeGenericType(typeof(INCopDependencyResolver), serviceType);
		}
	}
}
