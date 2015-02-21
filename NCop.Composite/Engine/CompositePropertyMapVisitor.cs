using NCop.Composite.Weaving;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
