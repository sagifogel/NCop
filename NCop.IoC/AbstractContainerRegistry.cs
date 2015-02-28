using NCop.IoC.Fluent;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NCop.IoC
{
    public abstract class AbstractContainerRegistry : IContainerRegistry
    {   
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
            Register(registration);

            return registration;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public abstract IEnumerator<IRegistration> GetEnumerator();

        public abstract void Register(IRegistration registration);

        public abstract void Register(Type concreteType, Type serviceType, Core.ITypeMap dependencies = null, string name = null);
    }
}
