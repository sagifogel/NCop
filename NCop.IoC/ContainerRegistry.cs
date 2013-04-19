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
    public class ContainerRegistry : IRegistry, IEnumerable<IRegistration>
    {
        private readonly List<IFluenatRegistration> registrations = null;

        public ContainerRegistry() {
            registrations = new List<IFluenatRegistration>();
        }

        public ICastableRegistration<TCastable> Register<TCastable>() {
            Type serviceType = typeof(TCastable);
            var factoryType = typeof(Func<INCopContainer, TCastable>);

            return RegisterImpl<ICastableRegistration<TCastable>>(
                    new ExpressionRegistration<TCastable>(serviceType, factoryType));
        }

        public IFluenatRegistration Register<TService>(Func<INCopContainer, TService> factory) {
            return RegisterImpl(typeof(TService), typeof(Func<INCopContainer, TService>), factory);
        }

        public IFluenatRegistration Register<TService, TArg1>(Func<INCopContainer, TArg1, TService> factory) {
            return RegisterImpl(typeof(TService), typeof(Func<INCopContainer, TArg1, TService>), factory);
        }

        public IFluenatRegistration Register<TService, TArg1, TArg2>(Func<INCopContainer, TArg1, TArg2, TService> factory) {
            return RegisterImpl(typeof(TService), typeof(Func<INCopContainer, TArg1, TArg2, TService>), factory);
        }

        public IFluenatRegistration Register<TService, TArg1, TArg2, TArg3>(Func<INCopContainer, TArg1, TArg2, TArg3, TService> factory) {
            return RegisterImpl(typeof(TService), typeof(Func<INCopContainer, TArg1, TArg2, TArg3, TService>), factory);
        }

        public IFluenatRegistration Register<TService, TArg1, TArg2, TArg3, TArg4>(Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TService> factory) {
            return RegisterImpl(typeof(TService), typeof(Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TService>), factory);
        }

        public IFluenatRegistration Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5>(Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TService> factory) {
            return RegisterImpl(typeof(TService), typeof(Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TService>), factory);
        }

        public IFluenatRegistration Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService> factory) {
            return RegisterImpl(typeof(TService), typeof(Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService>), factory);
        }

        public IFluenatRegistration Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TService> factory) {
            return RegisterImpl(typeof(TService), typeof(Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TService>), factory);
        }

        public IFluenatRegistration Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TService> factory) {
            return RegisterImpl(typeof(TService), typeof(Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TService>), factory);
        }

        public IFluenatRegistration RegisterImpl(Type serviceType, Type factoryType, Delegate factory) {
            return RegisterImpl<Registration>(new Registration {
                Func = factory,
                FactoryType = factoryType,
                ServiceType = serviceType,
            });
        }

        public TRegistration RegisterImpl<TRegistration>(TRegistration registration) where TRegistration : IFluenatRegistration {
            registrations.Add(registration);

            return registration;
        }

        public IEnumerator<IRegistration> GetEnumerator() {
            return registrations.Cast<IRegistration>()
                                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
