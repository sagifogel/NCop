using NCop.Core.Extensions;
using NCop.IoC.Properties;
using System;
using System.Linq.Expressions;

namespace NCop.IoC.Fluent
{
    public class CastableRegistration<TCastable> : ICastableRegistration<TCastable>
    {
        protected readonly Registration registration = null;

        public CastableRegistration(Type serviceType, Type factoryType) {
            registration = new Registration {
                ServiceType = serviceType,
                FactoryType = factoryType
            };
        }

        public string Name {
            get {
                return registration.Name;
            }
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

        public Lifetime Lifetime {
            get {
                return registration.Lifetime;
            }
        }

        public Owner Owner {
            get {
                return registration.Owner;
            }
        }

        public void Named(string name) {
            registration.Named(name);
        }

        public IReusedWithin AsSingleton() {
            var type = registration.CastTo.IsNull() ? ServiceType : CastTo;

            RequiersNotInterface(type);
            As(type);

            return registration.AsSingleton();
        }

        public ICasted ToSelf() {
            RequiersNotInterface(ServiceType);
            As(registration.CastTo = ServiceType);

            return this;
        }

        public ICasted From<TService>() where TService : TCastable, new() {
            var castTo = typeof(TService);
            
            RequiersNotInterface(castTo);

            return As(registration.CastTo = castTo);
        }

        protected virtual ICasted As(Type castTo) {
            var delegateType = Expression.GetFuncType(new[] { typeof(INCopDependencyResolver), ServiceType });
            var ctor = castTo.GetConstructor(Type.EmptyTypes);

            Contract.RequiersConstructorNotNull(ctor, () => {
                var message = Resources.NoParameterlessConstructorFound.Fmt(ctor);

                return new RegistrationException(new MissingMethodException(message));
            });

            var paramater = Expression.Parameter(typeof(INCopDependencyResolver), "container");
            var lambda = Expression.Lambda(delegateType,
                            Expression.New(ctor),
                                paramater);

            registration.Func = lambda.Compile();

            return this;
        }

        private static void RequiersNotInterface(Type serviceType) {
            Contract.RequiersNotInterface(serviceType, () => new RegistrationException(Resources.TypeIsInterface.Fmt(serviceType)));
        }

        IReuseStrategy IDescriptable.Named(string name) {
            registration.Named(name);

            return this;
        }

        public void OwnedExternally() {
            registration.OwnedExternally();
        }

        public void OwnedByContainer() {
            registration.OwnedByContainer();
        }

        public IOwnedBy PerThread() {
            return registration.PerThread();
        }

        public IOwnedBy PerHttpRequest() {
            return registration.PerHttpRequest();
        }
    }
}
