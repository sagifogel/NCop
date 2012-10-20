using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NCop.Core;

namespace NCop.Aspects.Engine
{
    public sealed class AspectsRepository
    {
        private static bool _initialized = false;
        private static object _syncLock = new object();
        private static AspectsRepository _repository = null;
        private ConcurrentDictionary<Type, IAspectProvider> _aspects = new ConcurrentDictionary<Type, IAspectProvider>();

        private AspectsRepository() { }

        public static AspectsRepository Instance {
            get {
                return LazyInitializer.EnsureInitialized(ref _repository, 
                                                         ref _initialized, 
                                                         ref _syncLock, 
                                                         () => new AspectsRepository());
            }
        }

        public IAspect GetOrAdd(Type type, IAspectProvider provider) {
            IAspectProvider aspectProvider = null;

            using (ReadWriteLocker.AcquireReadLock()) {
                if (!_aspects.TryGetValue(type, out aspectProvider)) {
                    _aspects.GetOrAdd(type, provider);
                }

                return provider.GetAspect();
            }
        }
    }
}
