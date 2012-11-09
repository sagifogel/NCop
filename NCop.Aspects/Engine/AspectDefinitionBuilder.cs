using NCop.Aspects.Aspects;
using NCop.Core;
using NCop.Core.Aspects;
using System;
using System.Collections.Concurrent;

namespace NCop.Aspects.Engine
{
    internal sealed class AspectDefinitionBuilder
    {   
        private static object _syncLock = new object();
        private JoinPointMetadataVisitor _visitor = new JoinPointMetadataVisitor();
        private ConcurrentDictionary<Type, IAspectProvider> _registeredTypes = null;
        private static NCop.Core.Lazy<AspectDefinitionBuilder> _aspectsRepository = null;

        static AspectDefinitionBuilder() {
            _aspectsRepository = new NCop.Core.Lazy<AspectDefinitionBuilder>(() => new AspectDefinitionBuilder());
        }

        private AspectDefinitionBuilder() {
            _registeredTypes = new ConcurrentDictionary<Type, IAspectProvider>();
        }

        public IAspectDefinition BuildDefinition(Type type, Func<IAspectProvider> valueFactory, JoinPointMetadata joinPointMetadata) {
            IAspectProvider provider = null;

            lock (_syncLock) {
                if (!_registeredTypes.TryGetValue(type, out provider)) {
                    provider = _registeredTypes.GetOrAdd(type, valueFactory());
                }
            }

            return joinPointMetadata.Accept(_visitor, provider);
        }

        public static AspectDefinitionBuilder Instance {
            get {
                return _aspectsRepository.Value;
            }
        }
    }
}
