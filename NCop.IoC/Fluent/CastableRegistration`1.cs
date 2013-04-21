using NCop.IoC.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;
using System.Linq.Expressions;

namespace NCop.IoC.Fluent
{
    public class CastableRegistration<TCastable> : IDescriptable, IRegistration, ICastableRegistration<TCastable>, ICasted
    {
        private readonly Registration registration = null;

        public CastableRegistration(Type serviceType, Type factoryType) {
            registration = new Registration {
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
                if (registration.Func.IsNull()) {
                    ToSelf();
                }

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

        public ReuseScope Scope {
            get {
                return registration.Scope;
            }
        }

        public void Named(string name) {
            registration.Named(name);
        }

        public IReuseContext AsSingleton() {
            var type = registration.CastTo.IsNull() ? ServiceType : CastTo;

            CastableRegistration<TCastable>.RequiersNotInterface(type);
            As(type);
            return registration.AsSingleton();
        }

        public ICasted ToSelf() {
            CastableRegistration<TCastable>.RequiersNotInterface(ServiceType);
            As(registration.CastTo = ServiceType);

            return this;
        }

        public ICasted As<TService>() where TService : TCastable, new() {
            var castTo = typeof(TService);
            CastableRegistration<TCastable>.RequiersNotInterface(castTo);

            return As(registration.CastTo = castTo);
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

        IReuseStrategy IDescriptable.Named(string name) {
            registration.Named(name);

            return this;
        }
    }
}
