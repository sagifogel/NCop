using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    public class ServiceKey : IEquatable<ServiceKey>
    {
        private int hash = 0;

        public ServiceKey(string name, Type type) {
            Name = name;
            Type = type;
            hash = Type.GetHashCode();

            if (name != null) {
                hash ^= name.GetHashCode();
            }
        }

        public Type Type { get; private set; }

        public string Name { get; private set; }

        public override bool Equals(object obj) {
            return Equals((ServiceKey)obj);
        }

        public override int GetHashCode() {
            return hash;
        }

        public bool Equals(ServiceKey other) {
            return Equals(this, other);
        }

        public static bool Equals(ServiceKey obj1, ServiceKey obj2) {
            if (ReferenceEquals(null, obj1) || ReferenceEquals(null, obj2)) {
                return false;
            }

            return obj1.Type.Equals(obj2.Type) && obj1.Name.Equals(obj2.Name);
        }
    }
}
