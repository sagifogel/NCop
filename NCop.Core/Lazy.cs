using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NCop.Core
{
    public sealed class Lazy<T>
    {
        private bool _initialized = false;
        private Func<T> _valueFactory = null;
        private object _syncLock = new object();
        private static T _instance = default(T);

#if NET_4_5

        public Lazy(Func<T> valueFactory) {
            _valueFactory = valueFactory;
        }

        public T Value {
            get {
                return LazyInitializer.EnsureInitialized(ref _instance,
                                                          ref _initialized,
                                                          ref _syncLock,
                                                          _valueFactory);
            }
        }
  
#elif NET_4_0

        public Lazy(Func<T> valueFactory) {
            _valueFactory = valueFactory;
        }

        public T Value {
            get {
                return EnsureInitializedCore(ref _instance, ref _initialized, ref _syncLock, _valueFactory);
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
