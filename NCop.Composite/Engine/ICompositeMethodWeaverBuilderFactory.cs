using NCop.Aspects.Weaving;
using NCop.Weaving;

namespace NCop.Composite.Engine
{
    public interface ICompositeMethodWeaverBuilderFactory
    {
        IMethodWeaverBuilder Get(ITypeDefinition typeDefinition, IAspectWeavingServices weavingServices);
    }
}
