using NCop.IoC.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;
using System.Linq.Expressions;
using NCop.Core;

namespace NCop.IoC.Fluent
{
    public abstract class AbstractRegistration<TCastable> : IDescriptable, IRegistration, IFluentRegistration, ICastableRegistration<TCastable>, ICasted, IOwnedBy
    {
        protected Registration registration = null;
        protected readonly IEnumerable<TypeMap> dependencies = null;

        public AbstractRegistration(IEnumerable<TypeMap> dependencies = null) {
            this.dependencies = dependencies;
        }

        public virtual string Name {
            get {
                return registration.Name;
            }
        }

        public virtual Type CastTo {
            get {
                return registration.CastTo;
            }
        }

        public virtual Delegate Func {
            get {
                if (registration.Func.IsNull()) {
                    ToSelf();
                }

                return registration.Func;
            }
        }

        public virtual Type FactoryType {
            get {
                return registration.FactoryType;
            }
        }

        public virtual Type ServiceType {
            get {
                return registration.ServiceType;
            }
        }

        public virtual ReuseScope Scope {
            get {
                return registration.Scope;
            }
        }

        public virtual Owner Owner {
            get {
                return registration.Owner;
            }
        }

        public virtual void Named(string name) {
            registration.Named(name);
        }

        public IReusedWithin AsSingleton() {
            var type = registration.CastTo.IsNull() ? ServiceType : CastTo;

            AbstractRegistration<TCastable>.RequiersNotInterface(type);
            As(type);

            return registration.AsSingleton();
        }

        public ICasted ToSelf() {
            AbstractRegistration<TCastable>.RequiersNotInterface(ServiceType);
            As(registration.CastTo = ServiceType);

            return this;
        }

        public ICasted As<TService>() where TService : TCastable, new() {
            var castTo = typeof(TService);
            AbstractRegistration<TCastable>.RequiersNotInterface(castTo);

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
    }
}
