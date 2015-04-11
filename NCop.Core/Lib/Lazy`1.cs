using System;
using System.Threading;

namespace NCop.Core.Lib
{
    public sealed class Lazy<TParam, TValue>
    {
        private bool initialized = false;
        private object syncLock = new object();
        private static TValue instance = default(TValue);
        private readonly Func<TParam, TValue> valueFactory = null;

        public Lazy(Func<TParam, TValue> valueFactory) {
            this.valueFactory = valueFactory;
        }

        public TValue Get(TParam param) {
            return EnsureInitializedCore(ref instance, ref initialized, ref syncLock, valueFactory, param);
        }

        private static TValue EnsureInitializedCore(ref TValue target, ref bool initialized, ref object syncLock, Func<TParam, TValue> valueFactory, TParam param) {
            lock (syncLock) {
                if (!Volatile.Read(ref initialized)) {
                    target = valueFactory(param);
                    Volatile.Write(ref initialized, true);
                }
            }

            return target;
        }
    }
}
