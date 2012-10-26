using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Engine
{
    internal sealed class AspectDefinitionBuilder
    {
        private static readonly object _syncLock = new object();
        private JoinPointMetadataVisitor _visitor = new JoinPointMetadataVisitor();
        private ConcurrentDictionary<Type, IAspectProvider> _registeredTypes = null;
        private static Lazy<AspectDefinitionBuilder> _aspectsRepository = new Lazy<AspectDefinitionBuilder>(() => new AspectDefinitionBuilder());

        private AspectDefinitionBuilder() {
            _registeredTypes = new ConcurrentDictionary<Type, IAspectProvider>();
        }

        public IAspectDefinition BuildDefinition(Type type, Func<IAspectProvider> valueFactory, JoinPointMetadata joinPointMetadata) {
            IAspectProvider provider = null;

            using (ReadWriteLocker.AcquireReadLock()) {
                if (!_registeredTypes.TryGetValue(type, out provider)) {
                    provider = _registeredTypes.GetOrAdd(type, valueFactory());
                }
            }

            return joinPointMetadata.Accept(_visitor, provider);
        }

        public static AspectDefinitionBuilder Instance {
            get {
                return _aspectsRepository.Instance;
            }
        }
    }
}
