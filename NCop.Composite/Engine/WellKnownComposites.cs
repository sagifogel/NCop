using NCop.Composite.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Composite.Engine
{
    public sealed class WellKnownComposites
    {
        private static readonly object syncLock = new object();
        private ISet<Type> wellKnownCompositeTypes = new HashSet<Type>();
        private static readonly Lazy<WellKnownComposites> wellKnownComposites = null;

        static WellKnownComposites() {
            wellKnownComposites = new Lazy<WellKnownComposites>(() => new WellKnownComposites());
        }

        private WellKnownComposites() {
            wellKnownCompositeTypes = new HashSet<Type>(new[] { typeof(TransientCompositeAttribute) });
        }

        internal static WellKnownComposites Instance {
            get {
                return wellKnownComposites.Value;
            }
        }

        public static void RegisterCompositeType(Type type) {
            lock (syncLock) {
                WellKnownComposites.Instance.wellKnownCompositeTypes.Add(type);
            }
        }

        internal bool Contains(Type type) {
            return wellKnownCompositeTypes.Contains(type);
        }
    }
}
