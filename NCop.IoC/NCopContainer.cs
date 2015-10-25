using NCop.Core;
using NCop.Core.Extensions;
using NCop.IoC.Fluent;
using System;
using System.Collections.Generic;
using System.Threading;

namespace NCop.IoC
{
    public class NCopContainer : AbstractNCopContainer, INCopDependencyAwareRegistry, INCopDependencyContainer, IRegisterEntry, INCopDependencyArgumentsResolver, IContainerConfigurator<IArgumentsFluentRegistry>
    {
        private int locked = 0;
        private readonly NCopContainer parentContainer = null;
        private readonly Stack<NCopContainer> childContainers = new Stack<NCopContainer>();

        public NCopContainer(Action<IArgumentsFluentRegistry> registrationAction = null)
            : this(registrationAction, null) {
        }

        internal NCopContainer(Action<IArgumentsFluentRegistry> registrationAction, NCopContainer parentContainer) {
            this.parentContainer = parentContainer;

            if (registrationAction.IsNotNull()) {
                Configure(registrationAction);
            }
        }

        public void Configure(Action<IArgumentsFluentRegistry> registrationAction = null) {
            if (Interlocked.CompareExchange(ref locked, 1, 0) == 0) {
                if (registrationAction.IsNotNull()) {
                    registrationAction(registry);
                }

                base.Configure();
            }
        }

        protected override ServiceEntry GetEntry(ServiceKey key) {
            var entry = base.GetEntry(key);

            if (entry.IsNull() && parentContainer.IsNotNull()) {
                parentContainer.TryGetEntry(key, out entry);
            }

            return entry;
        }

        public INCopDependencyContainer CreateChildContainer() {
            return CreateChildContainer(null);
        }

        public INCopDependencyContainer CreateChildContainer(Action<IArgumentsFluentRegistry> registrationAction) {
            NCopContainer container = null;

            lock (childContainers) {
                childContainers.Push(container = new NCopContainer(registrationAction, this));
            }

            return container;
        }

        public sealed override void Dispose() {
            base.Dispose();

            lock (childContainers) {
                while (childContainers.Count > 0) {
                    childContainers.Pop().Dispose();
                }
            }
        }

        public TService Resolve<TArg1, TService>(TArg1 arg1, string name = null) {
            return ResolveImpl<TService, Func<INCopDependencyResolver, TArg1, TService>>(factory => {
                return factory(this, arg1);
            }, name);
        }

        public TService Resolve<TArg1, TArg2, TService>(TArg1 arg1, TArg2 arg2, string name = null) {
            return ResolveImpl<TService, Func<INCopDependencyResolver, TArg1, TArg2, TService>>(factory => {
                return factory(this, arg1, arg2);
            }, name);
        }

        public TService Resolve<TArg1, TArg2, TArg3, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, string name = null) {
            return ResolveImpl<TService, Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TService>>(factory => {
                return factory(this, arg1, arg2, arg3);
            }, name);
        }

        public TService Resolve<TArg1, TArg2, TArg3, TArg4, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, string name = null) {
            return ResolveImpl<TService, Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TService>>(factory => {
                return factory(this, arg1, arg2, arg3, arg4);
            }, name);
        }

        public TService Resolve<TArg1, TArg2, TArg3, TArg4, TArg5, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, string name = null) {
            return ResolveImpl<TService, Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TArg5, TService>>(factory => {
                return factory(this, arg1, arg2, arg3, arg4, arg5);
            }, name);
        }

        public TService Resolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, string name = null) {
            return ResolveImpl<TService, Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService>>(factory => {
                return factory(this, arg1, arg2, arg3, arg4, arg5, arg6);
            }, name);
        }

        public TService Resolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, string name = null) {
            return ResolveImpl<TService, Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TService>>(factory => {
                return factory(this, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }, name);
        }

        public TService Resolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, string name = null) {
            return ResolveImpl<TService, Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TService>>(factory => {
                return factory(this, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }, name);
        }

        public TService TryResolve<TArg1, TService>(TArg1 arg1, string name = null) {
            return ResolveImpl<TService, Func<INCopDependencyResolver, TArg1, TService>>(factory => {
                return factory(this, arg1);
            }, name, false);
        }

        public TService TryResolve<TArg1, TArg2, TService>(TArg1 arg1, TArg2 arg2, string name = null) {
            return ResolveImpl<TService, Func<INCopDependencyResolver, TArg1, TArg2, TService>>(factory => {
                return factory(this, arg1, arg2);
            }, name, false);
        }

        public TService TryResolve<TArg1, TArg2, TArg3, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, string name = null) {
            return ResolveImpl<TService, Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TService>>(factory => {
                return factory(this, arg1, arg2, arg3);
            }, name, false);
        }

        public TService TryResolve<TArg1, TArg2, TArg3, TArg4, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, string name = null) {
            return ResolveImpl<TService, Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TService>>(factory => {
                return factory(this, arg1, arg2, arg3, arg4);
            }, name, false);
        }

        public TService TryResolve<TArg1, TArg2, TArg3, TArg4, TArg5, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, string name = null) {
            return ResolveImpl<TService, Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TArg5, TService>>(factory => {
                return factory(this, arg1, arg2, arg3, arg4, arg5);
            }, name, false);
        }

        public TService TryResolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, string name = null) {
            return ResolveImpl<TService, Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService>>(factory => {
                return factory(this, arg1, arg2, arg3, arg4, arg5, arg6);
            }, name, false);
        }

        public TService TryResolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, string name = null) {
            return ResolveImpl<TService, Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TService>>(factory => {
                return factory(this, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            }, name, false);
        }

        public TService TryResolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, string name = null) {
            return ResolveImpl<TService, Func<INCopDependencyResolver, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TService>>(factory => {
                return factory(this, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }, name, false);
        }

        public void Register(TypeMap typeMap, ITypeMapCollection dependencies = null, bool isComposite = false) {
            registry.Register(typeMap, dependencies, isComposite);
        }

        public void Register(IRegistration registration) {
            registry.Register(registration);
        }
    }
}