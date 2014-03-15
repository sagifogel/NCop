using NCop.Core;
using NCop.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Composite.IoC
{
    public class NCopRegistryAdapter : INCopDependencyAwareRegistry
    {
        private readonly INCopRegistry registry = null;

        public NCopRegistryAdapter(INCopRegistry registry) {
            this.registry = registry;
        }

        public void Register(Type concreteType, Type serviceType, ITypeMap dependencies = null, string name = null) {
            registry.Register(concreteType, serviceType, name: name);
        }
    }
}
