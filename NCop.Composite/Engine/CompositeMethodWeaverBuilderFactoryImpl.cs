
using NCop.Aspects.Weaving;
using NCop.Weaving;
using System;

namespace NCop.Composite.Engine
{
    internal class CompositeMethodWeaverBuilderFactoryImpl : ICompositeMethodWeaverBuilderFactory
    {
        private readonly Func<ITypeDefinition, IAspectWeavingServices, IMethodWeaverBuilder> methodBuilderFactory = null;

        internal CompositeMethodWeaverBuilderFactoryImpl(Func<ITypeDefinition, IAspectWeavingServices, IMethodWeaverBuilder> methodBuilderFactory) {
            this.methodBuilderFactory = methodBuilderFactory;
        }

        public IMethodWeaverBuilder Get(ITypeDefinition typeDefinition, IAspectWeavingServices weavingServices) {
            return methodBuilderFactory(typeDefinition, weavingServices);
        }
    }
}
