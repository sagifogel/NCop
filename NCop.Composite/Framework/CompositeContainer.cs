using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.IoC;
using NCop.IoC.Fluent;
using NCop.Core;

namespace NCop.Composite.Framework
{
    public class CompositeContainer : INCopContainer
    {
        private NCopContainer container = null;

        public CompositeContainer(RuntimeSettings settings = null) {
            var runtime = new CompositeRuntime {
                Settings = settings
            };
        }

        public void Configure(Action<IRegistry> registrationAction) {
            container = new NCopContainer(registrationAction);
        }

        public TService Resolve<TService>() {
            return container.Resolve<TService>();
        }

        public TService TryResolve<TService>() {
            return container.TryResolve<TService>();
        }

        public TService Resolve<TService>(string name = null) {
            return container.Resolve<TService>(name);
        }

        public TService TryResolve<TService>(string name = null) {
            return container.TryResolve<TService>(name);
        }

        public TService Resolve<TArg1, TService>(TArg1 arg1, string name = null) {
            return container.Resolve<TArg1, TService>(arg1, name);
        }

        public TService TryResolve<TArg1, TService>(TArg1 arg1, string name = null) {
            return container.TryResolve<TArg1, TService>(arg1, name);
        }

        public TService Resolve<TArg1, TArg2, TService>(TArg1 arg1, TArg2 arg2, string name = null) {
            return container.Resolve<TArg1, TArg2, TService>(arg1, arg2, name);
        }

        public TService TryResolve<TArg1, TArg2, TService>(TArg1 arg1, TArg2 arg2, string name = null) {
            return container.TryResolve<TArg1, TArg2, TService>(arg1, arg2, name);
        }

        public TService Resolve<TArg1, TArg2, TArg3, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, string name = null) {
            return container.Resolve<TArg1, TArg2, TArg3, TService>(arg1, arg2, arg3, name);
        }

        public TService TryResolve<TArg1, TArg2, TArg3, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, string name = null) {
            return container.TryResolve<TArg1, TArg2, TArg3, TService>(arg1, arg2, arg3, name);
        }

        public TService Resolve<TArg1, TArg2, TArg3, TArg4, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, string name = null) {
            return container.Resolve<TArg1, TArg2, TArg3, TArg4, TService>(arg1, arg2, arg3, arg4, name);
        }

        public TService TryResolve<TArg1, TArg2, TArg3, TArg4, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, string name = null) {
            return container.TryResolve<TArg1, TArg2, TArg3, TArg4, TService>(arg1, arg2, arg3, arg4, name);
        }

        public TService Resolve<TArg1, TArg2, TArg3, TArg4, TArg5, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, string name = null) {
            return container.Resolve<TArg1, TArg2, TArg3, TArg4, TArg5, TService>(arg1, arg2, arg3, arg4, arg5, name);
        }

        public TService TryResolve<TArg1, TArg2, TArg3, TArg4, TArg5, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, string name = null) {
            return container.TryResolve<TArg1, TArg2, TArg3, TArg4, TArg5, TService>(arg1, arg2, arg3, arg4, arg5, name);
        }

        public TService Resolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, string name = null) {
            return container.Resolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService>(arg1, arg2, arg3, arg4, arg5, arg6, name);
        }

        public TService TryResolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, string name = null) {
            return container.TryResolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService>(arg1, arg2, arg3, arg4, arg5, arg6, name);
        }

        public TService Resolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, string name = null) {
            return container.Resolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TService>(arg1, arg2, arg3, arg4, arg5, arg6, arg7, name);
        }

        public TService TryResolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, string name = null) {
            return container.TryResolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TService>(arg1, arg2, arg3, arg4, arg5, arg6, arg7, name);
        }

        public TService Resolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, string name = null) {
            return container.Resolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TService>(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, name);
        }

        public TService TryResolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TService>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8, string name = null) {
            return container.TryResolve<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TService>(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, name);
        }

        public void Dispose() {
            container.Dispose();
        }
    }
}
