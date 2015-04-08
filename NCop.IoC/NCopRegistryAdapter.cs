using NCop.Core;
using System;

namespace NCop.IoC
{
    public class NCopRegistryAdapter : INCopDependencyAwareRegistry
    {
        private readonly INCopRegistry registry = null;

        public NCopRegistryAdapter(INCopRegistry registry) {
            this.registry = registry;
        }

        public void Register(Type concreteType, Type serviceType, ITypeMap dependencies = null, string name = null, bool isComposite = false) {
            registry.Register(concreteType, serviceType, name);
        }
    }
}
