
using NCop.Aspects.Weaving;
using NCop.Weaving;
using System;

namespace NCop.Composite.Engine
{
    internal class CompositeMethodWeaverBuilderFactoryImpl : ICompositeMethodWeaverBuilderFactory
    {
        private readonly Action<IPropertyTypeBuilder, ITypeDefinition, IAspectWeavingServices> methodBuilderFactory = null;

        internal CompositeMethodWeaverBuilderFactoryImpl(Action<IPropertyTypeBuilder, ITypeDefinition, IAspectWeavingServices> methodBuilderFactory) {
            this.methodBuilderFactory = methodBuilderFactory;
        }

        public void Get(IPropertyTypeBuilder propertyTypeBuilder, ITypeDefinition typeDefinition, IAspectWeavingServices weavingServices) {
            methodBuilderFactory(propertyTypeBuilder, typeDefinition, weavingServices);
        }
    }
}
