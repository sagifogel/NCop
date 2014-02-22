using NCop.IoC.Fluent;
using NCop.IoC.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;
using System.Collections.Concurrent;
using System.Collections;

namespace NCop.IoC
{
    public class ContainerRegistry : IContainerRegistry
    {
        protected readonly List<IFluentRegistration> registrations = null;

        public ContainerRegistry() {
            registrations = new List<IFluentRegistration>();
        }

        private IEnumerable<IRegistration> Registrations {
            get { 
                return registrations.Cast<IRegistration>(); 
            }
        }

        public ICastableRegistration<TCastable> Register<TCastable>() {
            Type serviceType = typeof(TCastable);
            var factoryType = typeof(Func<INCopDependencyResolver, TCastable>);

            return RegisterImpl<ICastableRegistration<TCastable>>(
                     new CastableRegistration<TCastable>(serviceType, factoryType));
        }

        public ICastableRegistration<TCastable> RegisterAuto<TCastable>() {
            Type serviceType = typeof(TCastable);
            var factoryType = typeof(Func<INCopDependencyResolver, TCastable>);

            return RegisterImpl<AutoRegistration<TCastable>>(
                     new AutoRegistration<TCastable>(serviceType, factoryType));
        }

        public IReuseStrategyRegistration Register<TService>(Func<INCopDependencyResolver, TService> factory) {
            return RegisterImpl<IReuseStrategyRegistration>(typeof(TService), typeof(Func<INCopDependencyResolver, TService>), factory);
        }

        public IFactoryRegistration Register<TService, TArg1>(Func<INCopDependencyResolver, TArg1, TService> factory) {
            return RegisterImpl<IFactoryRegistration>(typeof(TService), typeof(Func<INCopDependencyResolver, TArg1, TService>), factory);
        }

        public IFactoryRegistration Register<TService, TArg1, TArg2>(Func<INCopDependencyResolver, TArg1, TArg2, TService> factory) {
            return RegisterImpl<IFactoryRegistration>(typeof(TService), typeof(Func<INCopDependencyResolver, TArg1, TArg2, TService>), factory);
        }

        public IFactoryRegistration Register<TService, TArg1, TArg2, TArg3>(Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TService> factory) {
            return RegisterImpl<IFactoryRegistration>(typeof(TService), typeof(Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TService>), factory);
        }

        public IFactoryRegistration Register<TService, TArg1, TArg2, TArg3, TArg4>(Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TService> factory) {
            return RegisterImpl<IFactoryRegistration>(typeof(TService), typeof(Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TService>), factory);
        }

        public IFactoryRegistration Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5>(Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TArg5, TService> factory) {
            return RegisterImpl<IFactoryRegistration>(typeof(TService), typeof(Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TArg5, TService>), factory);
        }

        public IFactoryRegistration Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService> factory) {
            return RegisterImpl<IFactoryRegistration>(typeof(TService), typeof(Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService>), factory);
        }

        public IFactoryRegistration Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TService> factory) {
            return RegisterImpl<IFactoryRegistration>(typeof(TService), typeof(Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TService>), factory);
        }

        public IFactoryRegistration Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TService> factory) {
            return RegisterImpl<IFactoryRegistration>(typeof(TService), typeof(Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TService>), factory);
        }

        public TRegistration RegisterImpl<TRegistration>(Type serviceType, Type factoryType, Delegate factory) where TRegistration : class, IFluentRegistration {
            return RegisterImpl(new Registration {
                Func = factory,
                FactoryType = factoryType,
                ServiceType = serviceType,
            }) as TRegistration;
        }

        public TRegistration RegisterImpl<TRegistration>(TRegistration registration) where TRegistration : class, IFluentRegistration {
            registrations.Add(registration);

            return registration;
        }

        public virtual void Register(Type concreteType, Type serviceType, string name = null) {
            RegisterImpl(new ReflectionRegistration(concreteType, serviceType));
        }

        public IEnumerator<IRegistration> GetEnumerator() {
            return Registrations.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public bool Contains(Type serviceType) {
            var factoryType = typeof(Func<,>).MakeGenericType(typeof(INCopDependencyResolver), serviceType);

            return Registrations.Any(registration => {
                return registration.FactoryType.Equals(factoryType);
            });
        }
    }
}
