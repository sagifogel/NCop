using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    public class Identifier : IEquatable<Identifier>
    {
        private int hash = 0;

        public Identifier(Type serviceType, Type factoryType, string name = null) {
            FactoryType = factoryType;
            ServiceType = serviceType;
            hash = FactoryType.GetHashCode() ^ ServiceType.GetHashCode();

            if (Name != null) {
                hash ^= Name.GetHashCode();
            };
        }

        public string Name { get; private set; }

        public Type FactoryType { get; set; }

        public Type ServiceType { get; private set; }

        public override bool Equals(object obj) {
            return Equals((Identifier)obj);
        }

        public override int GetHashCode() {
            return hash;
        }

        public bool Equals(Identifier other) {
            return Equals(this, other);
        }

        public static bool Equals(Identifier obj1, Identifier obj2) {
            if (ReferenceEquals(null, obj1) || ReferenceEquals(null, obj2) || !obj1.GetType().Equals(obj2.GetType())) {
                return false;
            }

            if (ReferenceEquals(obj1, obj2)) {
                return true;
            }

            return obj1.ServiceType.Equals(obj2.ServiceType) && obj1.FactoryType.Equals(obj2.FactoryType) && obj1.Name == obj2.Name;
        }
    }
}
