using NCop.Core;

namespace NCop.IoC
{
    public class NCopRegistryAdapter : INCopDependencyAwareRegistry
    {
        private readonly INCopRegistry registry = null;

        public NCopRegistryAdapter(INCopRegistry registry) {
            this.registry = registry;
        }

        public void Register(TypeMap typeMap, ITypeMapCollection dependencies = null, bool isComposite = false) {
            registry.Register(typeMap, dependencies);
        }
    }
}
