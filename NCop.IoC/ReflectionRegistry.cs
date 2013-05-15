using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.IoC
{
    public class ReflectionRegistry : IRegistry
    {
        private readonly ContainerRegistry registry = null;

        public ReflectionRegistry(ContainerRegistry registry) {
            this.registry = registry;
        }

        public void Register(Type concreteType, Type serviceType) {
            registry.Register(concreteType, serviceType);    
        }

        public bool Contains(Type serviceType) {
            return registry.Contains(serviceType);
        }
    }
}
