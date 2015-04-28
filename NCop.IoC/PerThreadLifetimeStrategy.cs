using NCop.Core.Extensions;
using System;
using System.Runtime.Remoting.Messaging;

namespace NCop.IoC
{
    internal class PerThreadLifetimeStrategy : AbstractLifetimeStrategy
    {
        private static readonly string slotName = Guid.NewGuid().ToString();

        private PerThreadLifetimeStrategy() { }

        static PerThreadLifetimeStrategy() {
            Instance = new PerThreadLifetimeStrategy();
        }

        public static PerThreadLifetimeStrategy Instance { get; private set; }

        public override TService Resolve<TService>(ResolveContext<TService> context) {
            TService service;

            if (TryResolve(context, out service)) {
                return service;
            }

            service = context.Factory();
            CallContext.LogicalSetData(slotName, service);

            return service;
        }

        private bool TryResolve<TService>(ResolveContext<TService> context, out TService service) {
            var value = CallContext.LogicalGetData(slotName);

            if (value.IsNotNullOrDefault()) {
                service = (TService)value;
                return true;
            }

            service = default(TService);
            return false;
        }
    }
}
