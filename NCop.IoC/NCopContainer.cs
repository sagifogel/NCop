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
    public class NCopContainer : INCopContainer
    {
        private Guid Guid = Guid.NewGuid();
        private readonly NCopContainer parentContainer = null;
        private readonly Dictionary<ServiceKey, ServiceEntry> services = null;

        public NCopContainer(Action<IRegistry> registrationAction)
            : this(registrationAction, null) {
        }

        internal NCopContainer(Action<IRegistry> registrationAction, NCopContainer parentContainer) {
            var registry = new ContainerRegistry();

            this.parentContainer = parentContainer;
            registrationAction(registry);
            Interlocked.CompareExchange(ref services, ResolveServices(registry), null);
        }

        private Dictionary<ServiceKey, ServiceEntry> ResolveServices(IEnumerable<IRegistration> registrations) {
            return registrations.ToDictionary(r => new ServiceKey(r.ServiceType, r.FactoryType, r.Name),
                                             (kv) => {
                                                 return new ServiceEntry {
                                                     Container = this,
                                                     Scope = kv.Scope,
                                                     Factory = kv.Func,
                                                     LifetimeStrategy = kv.Scope.ToStrategy(this)
                                                 };
                                             });
        }

        internal void LateRegister(ServiceKey key, ServiceEntry entry) {
            services[key] = entry;
        }

        public TService Resolve<TService>(string name = null) {
            return ResolveImpl<TService, Func<INCopContainer, TService>>(factory => {
                return factory(this);
            }, name);
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

        public TService ResolveImpl<TService, TFunc>(Func<TFunc, TService> factoryInvoker, string name = null, bool throwIfMissing = true) {
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
                Factory = Functional.Curry(factoryInvoker, (TFunc)entry.Factory)
            };

            return entry.LifetimeStrategy.Resolve(context);
        }

        internal bool TryGetEntry(ServiceKey key, out ServiceEntry entry) {
            return (entry = GetEntry(key)) != null;
        }

        private ServiceEntry GetEntry(ServiceKey key) {
            ServiceEntry entry;

            if (services.TryGetValue(key, out entry) || parentContainer.TryGetEntryWhenNotNull(key, out entry)) {
                return entry;
            }

            return entry;
        }

        public INCopContainer CreateChildContainer(Action<IRegistry> registrationAction) {
            return new NCopContainer(registrationAction, this);
        }
    }
}