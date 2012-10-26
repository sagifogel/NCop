using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NCop.Core;
using NCop.Aspects.Aspects;

namespace NCop.Aspects.Engine
{
    internal sealed class AspectsRepository
    {
        private static object _syncLock = new object();
        private static AspectsDefinitionStore _aspects = new AspectsDefinitionStore();
        private static Lazy<AspectsRepository> _aspectsRepository = new Lazy<AspectsRepository>(() => new AspectsRepository());

        private AspectsRepository() { }

        public static AspectsRepository Instance {
            get {
                return _aspectsRepository.Instance;
            }
        }

        public void AddOrUpdate(Type type, IAspectDefinition aspectDefinition) {
            lock (_syncLock) {
                 var aspectsCollection = Ensure(type);

                 _aspects.AddOrUpdate(type, aspectsCollection, (a, aspects) => {
                    aspects.Add(aspectDefinition);
                    return aspects;
                });
            }
        }

        private AspectDefinitionCollection Ensure(Type type) {
            return _aspects.GetOrAdd(type, new AspectDefinitionCollection());   
        }
    }
}
