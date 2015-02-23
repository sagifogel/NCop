using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    public class ServiceKey : IEquatable<ServiceKey>
    {
        private readonly int hash = 0;

        public ServiceKey(Type serviceType, Type factoryType, string name = null) {
            FactoryType = factoryType;
            ServiceType = serviceType;
            hash = FactoryType.GetHashCode() ^ ServiceType.GetHashCode();
            Name = name;

            if (Name != null) {
                hash ^= Name.GetHashCode();
            }
        }

        internal string Name { get; private set; }
        
        internal Type FactoryType { get; set; }
        
        internal Type ServiceType { get; private set; }
        
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
            if (ReferenceEquals(null, obj1) || ReferenceEquals(null, obj2) || !ReferenceEquals(obj1.GetType(), obj2.GetType())) {
                return false;
            }

            if (ReferenceEquals(obj1, obj2)) {
                return true;
            }

            return ReferenceEquals(obj1.ServiceType, obj2.ServiceType) && ReferenceEquals(obj1.FactoryType, obj2.FactoryType) && obj1.Name == obj2.Name;
        }
    }
}
