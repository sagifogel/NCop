using System;
using System.Collections.Generic;
using System.Threading;
using NCop.Core.Extensions;

namespace NCop.IoC
{
    public class LifetimeCacheImpl : ILifetimeCache
    {
        private readonly ReaderWriterLockSlim locker = null;
        private readonly IDictionary<object, object> instances = null;

        public LifetimeCacheImpl() {
            instances = new Dictionary<object, object>();
            locker = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        }

        public void Dispose() {
            locker.Write(() => instances.Clear());
        }

        public bool Remove(Type serviceType) {
            return locker.CouldWrite(() => instances.Remove(serviceType));
        }

        public bool Contains(Type serviceType) {
            return locker.Read(() => {
                return instances.ContainsKey(serviceType);
            });
        }

        public TService GetOrAdd<TService>(Func<TService> factory) {
            var result = default(TService);
            var serviceType = typeof(TService);

            locker.UpgradeableRead(() => {
                object service;

                if (instances.TryGetValue(serviceType, out service)) {
                    result = (TService)service;
                    return;
                }

                locker.Write(() => {
                    result = factory();
                    instances.Add(serviceType, result);
                });
            });

            return result;
        }
    }
}
