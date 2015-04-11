using System;
using System.Runtime.Remoting.Messaging;
using NCop.Core.Extensions;

namespace NCop.IoC
{
    internal class PerThreadLifetimeStrategy : AbstractLifetimeStrategy
    {
        private readonly string slotName = Guid.NewGuid().ToString();

        public override TService Resolve<TService>(ResolveContext<TService> context) {
            TService service;

            if (!TryResolve(context, out service)) {
                service = context.Factory();
                CallContext.LogicalSetData(slotName, service);
            }

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
