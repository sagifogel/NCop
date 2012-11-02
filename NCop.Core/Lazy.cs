using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NCop.Core
{
    public class Lazy<T>
    {
        private T _instance = default(T);
        private bool _initialized = false;
        private Func<T> _valueFactory = null;
        private object _syncLock = new object();

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
    }
}
