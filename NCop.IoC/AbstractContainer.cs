using NCop.IoC.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NCop.Core.Extensions;
using System.Threading;
using NCop.IoC.Fluent;
using NCop.Core;

namespace NCop.IoC
{
    public abstract class AbstractContainer : INCopContainer
    {
        protected IDictionary<ServiceKey, ServiceEntry> services = null;
        protected readonly ContainerRegistry registry = new ContainerRegistry();
        protected readonly Stack<WeakReference> disposables = new Stack<WeakReference>();

        protected IDictionary<ServiceKey, ServiceEntry> ResolveServices(IEnumerable<IRegistration> registrations) {
            return registrations.ToDictionary(r => CreateServiceKey(r), r => CreateServiceEntry(r));
        }

        protected virtual void ConfigureInternal(Action<IFluentRegistry> registrationAction = null) {
            if (registrationAction.IsNotNull()) {
                registrationAction(registry);
            }

            ConfigureInternal();
        }

        protected internal void ConfigureInternal() {
            Interlocked.CompareExchange(ref services, ResolveServices(registry), null);
        }

        protected ServiceKey CreateServiceKey(IRegistration registration) {
            return new ServiceKey(registration.ServiceType, registration.FactoryType, registration.Name);
        }

        protected ServiceEntry CreateServiceEntry(IRegistration registration) {
            return new ServiceEntry {
                Owner = registration.Owner,
                Container = this,
                Scope = registration.Scope,
                Factory = registration.Func,
                LifetimeStrategy = registration.Scope.ToStrategy(this)
            };
        }

        private void LateRegister(ServiceKey key, ServiceEntry entry) {
            lock (services) {
                services[key] = entry;
            }
        }

        public TService Resolve<TService>() {
            return Resolve<TService>(null);
        }

        public TService Resolve<TService>(string name = null) {
            return ResolveImpl<TService, Func<INCopContainer, TService>>(factory => {
                return factory(this);
            }, name);
        }

        public TService TryResolve<TService>() {
            return TryResolve<TService>(null);
        }

        public TService TryResolve<TService>(string name = null) {
            return ResolveImpl<TService, Func<INCopContainer, TService>>(factory => {
                return factory(this);
            }, name, false);
        }

        public TService Resolve<TArg1, TService>(TArg1 arg1, string name = null) {
            return ResolveImpl<TService, Func<INCopContainer, TArg1, TService>>(factory => {
                return factory(this, arg1);
            }, name);
        }

        public TService Resolve<TArg1, TArg2, TService>(TArg1 arg1, TArg2 arg2, string name = null) {
            return ResolveImpl<TService, Func<INCopContainer, TArg1, TArg2, TService>>(factory => {
                return factory(this, arg1, arg2);
            }, name);
        }

        public TService Resolve<TArg1, TArg2, TArg3, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, string name = null) {
            return ResolveImpl<TService, Func<INCopContainer, TArg1, TArg2, TArg3, TService>>(factory => {
                return factory(this, arg1, arg2, arg3);
            }, name);
        }

        public TService Resolve<TArg1, TArg2, TArg3, TArg4, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, string name = null) {
            return ResolveImpl<TService, Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TService>>(factory => {
                return factory(this, arg1, arg2, arg3, arg4);
            }, name);
        }

        public TService Resolve<TArg1, TArg2, TArg3, TArg4, TArg5, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, string name = null) {
            return ResolveImpl<TService, Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TService>>(factory => {
                return factory(this, arg1, arg2, arg3, arg4, arg5);
            }, name);
        }

        public TService Resolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, string name = null) {
            return ResolveImpl<TService, Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService>>(factory => {
                return factory(this, arg1, arg2, arg3, arg4, arg5, arg6);
            }, name);
        }

        public TService Resolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, string name = null) {
            return ResolveImpl<TService, Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TService>>(factory => {
                return factory(this, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }, name);
        }

        public TService Resolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, string name = null) {
            return ResolveImpl<TService, Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TService>>(factory => {
                return factory(this, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }, name);
        }

        public TService TryResolve<TArg1, TService>(TArg1 arg1, string name = null) {
            return ResolveImpl<TService, Func<INCopContainer, TArg1, TService>>(factory => {
                return factory(this, arg1);
            }, name, false);
        }

        public TService TryResolve<TArg1, TArg2, TService>(TArg1 arg1, TArg2 arg2, string name = null) {
            return ResolveImpl<TService, Func<INCopContainer, TArg1, TArg2, TService>>(factory => {
                return factory(this, arg1, arg2);
            }, name, false);
        }

        public TService TryResolve<TArg1, TArg2, TArg3, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, string name = null) {
            return ResolveImpl<TService, Func<INCopContainer, TArg1, TArg2, TArg3, TService>>(factory => {
                return factory(this, arg1, arg2, arg3);
            }, name, false);
        }

        public TService TryResolve<TArg1, TArg2, TArg3, TArg4, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, string name = null) {
            return ResolveImpl<TService, Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TService>>(factory => {
                return factory(this, arg1, arg2, arg3, arg4);
            }, name, false);
        }

        public TService TryResolve<TArg1, TArg2, TArg3, TArg4, TArg5, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, string name = null) {
            return ResolveImpl<TService, Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TService>>(factory => {
                return factory(this, arg1, arg2, arg3, arg4, arg5);
            }, name, false);
        }

        public TService TryResolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, string name = null) {
            return ResolveImpl<TService, Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService>>(factory => {
                return factory(this, arg1, arg2, arg3, arg4, arg5, arg6);
            }, name, false);
        }

        public TService TryResolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, string name = null) {
            return ResolveImpl<TService, Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TService>>(factory => {
                return factory(this, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }, name, false);
        }

        public TService TryResolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, string name = null) {
            return ResolveImpl<TService, Func<INCopContainer, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TService>>(factory => {
                return factory(this, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }, name, false);
        }

        protected TService ResolveImpl<TService, TFunc>(Func<TFunc, TService> factoryInvoker, string name = null, bool throwIfMissing = true) {
            ResolveContext<TService> context = null;
            var identifier = new ServiceKey(typeof(TService), typeof(TFunc), name);
            ServiceEntry entry = GetEntry(identifier);

            if (entry.IsNull()) {
                if (throwIfMissing) {
                    throw new ResolutionException(Resources.CouldNotResolveType.Format(identifier.ServiceType));
                }

                return default(TService);
            }

            context = new ResolveContext<TService> {
                Entry = entry,
                Key = identifier,
                Container = this,
                Registry = LateRegister,
                Factory = Functional.Curry(CreateInstance, entry, (TFunc)entry.Factory, factoryInvoker)
            };

            return entry.LifetimeStrategy.Resolve(context);
        }

        protected TService CreateInstance<TService, TFunc>(ServiceEntry entry, TFunc factory, Func<TFunc, TService> factoryInvoker) {
            var instance = factoryInvoker(factory);

            if (entry.Owner == Owner.Container && instance is IDisposable) {
                lock (disposables) {
                    disposables.Push(new WeakReference(instance));
                }
            }

            return instance;
        }

        internal bool TryGetEntry(ServiceKey key, out ServiceEntry entry) {
            return (entry = GetEntry(key)) != null;
        }

        protected virtual ServiceEntry GetEntry(ServiceKey key) {
            ServiceEntry entry;

            if (services.TryGetValue(key, out entry)) {
                return entry;
            }

            return entry;
        }

        public virtual void Dispose() {
            lock (disposables) {
                while (disposables.Count > 0) {
                    var disposable = disposables.Pop();

                    if (disposable.IsAlive) {
                        ((IDisposable)disposable.Target).Dispose();
                    }
                }
            }
        }
    }
}
