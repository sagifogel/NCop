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

        public string Name { get; private set; }
        public Type ServiceType { get; private set; }
        public Type ConcreteType { get; private set; }
    }
}
