using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    public class Identifier : IEquatable<Identifier>
    {
        private int hash = 0;

        public Identifier(Type factoryType, string name) {
            Name = name;
            FactoryType = factoryType;
            hash = factoryType.GetHashCode();

            if (name != null) {
                hash ^= name.GetHashCode();
            }
        }

        public Type FactoryType { get; private set; }

        public string Name { get; private set; }

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
            if (ReferenceEquals(null, obj1) || ReferenceEquals(null, obj2)) {
                return false;
            }

            return obj1.FactoryType.Equals(obj2.FactoryType) && obj1.Name == obj2.Name;
        }
    }
}
