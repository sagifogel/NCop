using NCop.IoC.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NCop.Core.Extensions;
using System.Threading;
using NCop.IoC.Fluent;

namespace NCop.IoC
{
    public class NCopContainer : INCopContainer
    {
        private Dictionary<Identifier, object> services = null;

        public INCopContainer ParentContainer {
            get {
                return null;
            }
        }

        public NCopContainer(Action<IRegistry> registrationAction) {
            var registry = new ContainerRegistry(this);

            registrationAction(registry);
            Interlocked.CompareExchange(ref services, ResolveServices(registry), null);
        }

        private Dictionary<Identifier, object> ResolveServices(IEnumerable<IRegistration> registrations) {
            return registrations.ToDictionary(r => new Identifier(r.ServiceType, r.FactoryType, r.Name),
                                             (keyValue) => (object)keyValue.Func);
        }

        public TService Resolve<TService>(string name = null) {
            return ResolveImpl<TService, Func<INCopContainer, TService>>(factory => {
                return factory(this);
            }, name);
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

        public TService ResolveImpl<TService, TFunc>(Func<TFunc, TService> factoryInvoker, string name = null) {
            var identifier = new Identifier(typeof(TService), typeof(TFunc), name);
            var factory = (TFunc)services[identifier];

            return factoryInvoker(factory);
        }
    }
}