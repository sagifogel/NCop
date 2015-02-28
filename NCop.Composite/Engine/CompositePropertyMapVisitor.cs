using NCop.Composite.Weaving;

namespace NCop.Composite.Engine
{
    internal class CompositePropertyMapVisitor : ICompositePropertyMapVisitor
    {
        public ICompositeMethodWeaverBuilderFactory Visit(GetCompositePropertyMap propertyMap) {
            return new CompositeMethodWeaverBuilderFactoryImpl((typeDefinition, weavingServices) => {
                return new CompositeGetPropertyWeaverBuilder(propertyMap, typeDefinition, weavingServices);
            });
        }

        public ICompositeMethodWeaverBuilderFactory Visit(SetCompositePropertyMap propertyMap) {
            return new CompositeMethodWeaverBuilderFactoryImpl((typeDefinition, weavingServices) => {
                return new CompositeSetPropertyWeaverBuilder(propertyMap, typeDefinition, weavingServices);
            });
        }
    }
}
