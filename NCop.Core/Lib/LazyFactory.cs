
using System;
using System.Threading;

namespace NCop.Core.Lib
{
    public class LazyFactory
    {
        private bool initialized = false;
        private static object instance = null;
        private object syncLock = new object();

        public TService Get<TService>(Func<TService> valueFactory) {
            return (TService)EnsureInitializedCore(ref instance, ref initialized, ref syncLock, valueFactory);
        }

        private static object EnsureInitializedCore<TService>(ref object target, ref bool initialized, ref object syncLock, Func<TService> valueFactory) {
            lock (syncLock) {
                if (!Volatile.Read(ref initialized)) {
                    target = valueFactory();
                    Volatile.Write(ref initialized, true);
                }
            }

            return target;
        }
    }
}
