using System;
using System.Reflection;

namespace NCop.Composite.Engine
{
    internal class EventComparer : IEquatable<EventComparer>
    {
        private readonly int hash = 0;

        internal EventComparer(EventInfo @event) {
            Name = @event.Name;
            Type = @event.EventHandlerType;
            hash = Name.GetHashCode() ^ Type.GetHashCode();
        }

        public Type Type { get; private set; }

        public string Name { get; private set; }

        public override bool Equals(object obj) {
            return Equals((EventComparer)obj);
        }

        public override int GetHashCode() {
            return hash;
        }

        public bool Equals(EventComparer other) {
            return Equals(this, other);
        }

        public static bool Equals(EventComparer obj1, EventComparer obj2) {
            if (ReferenceEquals(null, obj1) || ReferenceEquals(null, obj2) || !ReferenceEquals(obj1.GetType(), obj2.GetType())) {
                return false;
            }

            if (ReferenceEquals(obj1, obj2)) {
                return true;
            }

            return ReferenceEquals(obj1.Type, obj2.Type) && obj1.Name == obj2.Name;
        }
    }
}
