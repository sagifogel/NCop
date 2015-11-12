using NCop.Composite.Extensions;
using NCop.Core;
using NCop.Core.Extensions;
using NCop.IoC;

namespace NCop.Composite.Engine
{
    internal class CompositeRegistryDecorator : INCopDependencyAwareRegistry
    {
        private readonly INCopDependencyAwareRegistry regisrty = null;

        public CompositeRegistryDecorator(INCopDependencyAwareRegistry regisrty) {
            this.regisrty = regisrty;
        }

        public void Register(TypeMap typeMap, ITypeMapCollection dependencies, bool isComposite = false) {
            var name = typeMap.Name ?? typeMap.ServiceType.GetNameFromAttribute() ?? typeMap.ConcreteType.GetNameFromAttribute();

            if (name.IsNotNullOrEmpty()) {
                typeMap = new TypeMap(typeMap.ServiceType, typeMap.ConcreteType, name);
            }

            regisrty.Register(typeMap, dependencies, isComposite);
        }
    }
}
