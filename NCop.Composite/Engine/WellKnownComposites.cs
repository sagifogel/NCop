using NCop.Composite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Composite.Engine
{
    public sealed class WellKnownComposites
    {
        private static readonly object _syncLock = new object();
        private ISet<Type> _wellKnownCompositeTypes = new HashSet<Type>();
        private static readonly Lazy<WellKnownComposites> _wellKnownComposites = null;

        static WellKnownComposites() {
            _wellKnownComposites = new Lazy<WellKnownComposites>(() => new WellKnownComposites());
        }

        private WellKnownComposites() {
            _wellKnownCompositeTypes = new HashSet<Type>(new[] { typeof(TransientCompositeAttribute) });
        }

        public static WellKnownComposites Instance {
            get {
                return _wellKnownComposites.Value;
            }
        }

        public void RegisterCompositeType(Type type) {
            lock (_syncLock) {
                _wellKnownCompositeTypes.Add(type);
            }
        }

        public bool Contains(Type type) {
            return _wellKnownCompositeTypes.Contains(type);
        }
    }
}
