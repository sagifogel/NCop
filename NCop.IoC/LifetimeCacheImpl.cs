using NCop.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Threading;

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

        public TService GetOrAdd<TService>(ServiceKey key, Func<TService> factory) {
            var result = default(TService);
            var serviceType = typeof(TService);

            locker.UpgradeableRead(() => {
                object service;

                if (instances.TryGetValue(key, out service)) {
                    result = (TService)service;
                    return;
                }

                locker.Write(() => {
                    result = factory();
                    instances.Add(key, result);
                });
            });

            return result;
        }
    }
}
