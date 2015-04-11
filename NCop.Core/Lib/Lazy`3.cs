using System;
using System.Threading;

namespace NCop.Core.Lib
{
    public sealed class Lazy<TParam1, TParam2, TParam3, TValue>
    {
        private bool initialized = false;
        private object syncLock = new object();
        private static TValue instance = default(TValue);
        private readonly Func<TParam1, TParam2, TParam3, TValue> valueFactory = null;

        public Lazy(Func<TParam1, TParam2, TParam3, TValue> valueFactory) {
            this.valueFactory = valueFactory;
        }

        public TValue Get(TParam1 param1, TParam2 param2, TParam3 param3) {
            return EnsureInitializedCore(ref instance, ref initialized, ref syncLock, valueFactory, param1, param2, param3);
        }

        private static TValue EnsureInitializedCore(ref TValue target, ref bool initialized, ref object syncLock, Func<TParam1, TParam2, TParam3, TValue> valueFactory, TParam1 param1, TParam2 param2, TParam3 param3) {
            lock (syncLock) {
                if (!Volatile.Read(ref initialized)) {
                    target = valueFactory(param1, param2, param3);
                    Volatile.Write(ref initialized, true);
                }
            }

            return target;
        }
    }
}
