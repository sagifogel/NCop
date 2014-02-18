using NCop.IoC.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;
using System.Linq.Expressions;

namespace NCop.IoC.Fluent
{
	public class CastableRegistration<TCastable> : IDescriptable, IRegistration, IFluentRegistration, ICastableRegistration<TCastable>, ICasted, IOwnedBy
	{
		protected readonly Registration Registration = null;

		public CastableRegistration(Type serviceType, Type factoryType) {
			Registration = new Registration {
				ServiceType = serviceType,
				FactoryType = factoryType
			};
		}

		public string Name {
			get {
				return Registration.Name;
			}
		}

		public Type CastTo {
			get {
				return Registration.CastTo;
			}
		}

		public Delegate Func {
			get {
				if (Registration.Func.IsNull()) {
					ToSelf();
				}

				return Registration.Func;
			}
		}

		public Type FactoryType {
			get {
				return Registration.FactoryType;
			}
		}

		public Type ServiceType {
			get {
				return Registration.ServiceType;
			}
		}

		public ReuseScope Scope {
			get {
				return Registration.Scope;
			}
		}

		public Owner Owner {
			get {
				return Registration.Owner;
			}
		}

		public void Named(string name) {
			Registration.Named(name);
		}

		public IReusedWithin AsSingleton() {
			var type = Registration.CastTo.IsNull() ? ServiceType : CastTo;

			CastableRegistration<TCastable>.RequiersNotInterface(type);
			As(type);

			return Registration.AsSingleton();
		}

		public ICasted ToSelf() {
			CastableRegistration<TCastable>.RequiersNotInterface(ServiceType);
			As(Registration.CastTo = ServiceType);

			return this;
		}

		public ICasted As<TService>() where TService : TCastable, new() {
			var castTo = typeof(TService);
			CastableRegistration<TCastable>.RequiersNotInterface(castTo);

			return As(Registration.CastTo = castTo);
		}

		protected virtual ICasted As(Type castTo) {
			var delegateType = Expression.GetFuncType(new[] { typeof(INCopDependencyResolver), ServiceType });
			var ctor = castTo.GetConstructor(Type.EmptyTypes);

			Contract.RequiersConstructorNotNull(ctor, () => {
				var message = Resources.NoParameterlessConstructorFound.Fmt(ctor);

				return new RegistrationException(new MissingMethodException(message));
			});

			var paramater = Expression.Parameter(typeof(INCopDependencyResolver), "container");
			var lambda = Expression.Lambda(
							delegateType,
							Expression.New(ctor),
								paramater);

			Registration.Func = lambda.Compile();

			return this;
		}

		private static void RequiersNotInterface(Type serviceType) {
			Contract.RequiersNotInterface(serviceType, () => new RegistrationException(Resources.TypeIsInterface.Fmt(serviceType)));
		}

		IReuseStrategy IDescriptable.Named(string name) {
			Registration.Named(name);

			return this;
		}

		public void OwnedExternally() {
			Registration.OwnedExternally();
		}

		public void OwnedByContainer() {
			Registration.OwnedByContainer();
		}
	}
}
