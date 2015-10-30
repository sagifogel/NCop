using System;

namespace NCop.Core
{
    public class TypeMap
    {
        public TypeMap(Type serviceType, Type concreteType, string name = null) {
            Name = name;
            ServiceType = serviceType;
            ConcreteType = concreteType;
        }

        private TypeMap(Type serviceType, Type concreteType, Guid guid)
            : this(serviceType, concreteType, guid.ToString()) {
        }

        public static TypeMap Create(Type serviceType, Type concreteType) {
            return new TypeMap(serviceType, concreteType, Guid.NewGuid());
        }

        public string Name { get; private set; }
        public Type ServiceType { get; private set; }
        public Type ConcreteType { get; private set; }
    }
}
