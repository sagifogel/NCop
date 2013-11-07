using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NCop.Core.Lib
{
    public sealed class Lazy<T>
    {
        private bool initialized = false;
        private Func<T> valueFactory = null;
        private object syncLock = new object();
        private static T instance = default(T);

#if NET_4_5

        public Lazy(Func<T> valueFactory) {
            this.valueFactory = valueFactory;
        }

        public T Value {
            get {
                return LazyInitializer.EnsureInitialized(ref instance,
                                                         ref initialized,
                                                         ref syncLock,
                                                         valueFactory);
            }
        }
  
#elif NET_4_0

        public Lazy(Func<T> valueFactory) {
            this.valueFactory = valueFactory;
        }

        public T Value {
            get {
                return EnsureInitializedCore(ref instance, ref initialized, ref syncLock, valueFactory);
            }
        }

        private static T EnsureInitializedCore(ref T target, ref bool initialized, ref object syncLock, Func<T> valueFactory) {
            lock (syncLock) {
                if (!Volatile.Read(ref initialized)) {
                    target = valueFactory();
                    Volatile.Write(ref initialized, true);
                }
            }

            return target;
        }

#endif

    }
}
