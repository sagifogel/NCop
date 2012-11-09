using NCop.Aspects.Aspects;
using NCop.Core;
using NCop.Core.Aspects;
using System;
using System.Collections.Concurrent;

namespace NCop.Aspects.Engine
{
    internal class AspectDefinitionRepository
    {
        private static object _syncLock = new object();
        private ConcurrentDictionary<Type, AspectDefinitionCollection> _aspects = null;

        public AspectDefinitionRepository() {
            _aspects = new ConcurrentDictionary<Type, AspectDefinitionCollection>();
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
