using NCop.IoC.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;
using System.Linq.Expressions;

namespace NCop.IoC.Fluent
{
    public class ExpressionRegistration<TCastable> : IDescriptable, IRegistration, ICastableRegistration<TCastable>, ICasted
    {
        private readonly Registration registration = null;

        public ExpressionRegistration(INCopContainer container, Type serviceType, Type factoryType) {
            registration = new Registration {
                Container = container,
                ServiceType = serviceType,
                FactoryType = factoryType
            };
        }

        public string Name {
            get { return registration.Name; }
        }

        public Type CastTo {
            get {
                return registration.CastTo;
            }
        }

        public Delegate Func {
            get {
                return registration.Func;
            }
        }

        public Type FactoryType {
            get {
                return registration.FactoryType;
            }
        }

        public Type ServiceType {
            get {
                return registration.ServiceType;
            }
        }

        public void Named(string name) {
            registration.Named(name);
        }

        public void AsSingleton() {
            var type = registration.CastTo.IsNull() ? ServiceType : CastTo;

            ExpressionRegistration<TCastable>.RequiersNotInterface(type);
            As(type);
            registration.AsSingleton();
        }

        public ICasted ToSelf() {
            ExpressionRegistration<TCastable>.RequiersNotInterface(ServiceType);
            As(registration.CastTo = ServiceType);

            return this;
        }

        public ICasted As<TService>() where TService : TCastable, new() {
            var castTo = typeof(TService);
            ExpressionRegistration<TCastable>.RequiersNotInterface(castTo);

            return As(castTo);
        }

        private ICasted As(Type castTo) {
            var delegateType = Expression.GetFuncType(new[] { typeof(INCopContainer), ServiceType });
            var ctor = castTo.GetConstructor(Type.EmptyTypes);

            Contract.RequiersConstructorNotNull(ctor, () => {
                var message = Resources.NoParameterlessConstructorFound.Format(ctor);
                return new RegistraionException(new MissingMethodException(message));
            });

            var paramater = Expression.Parameter(typeof(INCopContainer), "container");
            var lambda = Expression.Lambda(
                            delegateType,
                            Expression.New(ctor),
                                paramater);

            registration.Func = lambda.Compile();

            return this;
        }

        private static void RequiersNotInterface(Type serviceType) {
            Contract.RequiersNotInterface(serviceType, () => new RegistraionException(Resources.TypeIsInterface.Format(serviceType)));
        }

        ILifetimeStrategy IDescriptable.Named(string name) {
            registration.Named(name);

            return this;
        }
    }
}
