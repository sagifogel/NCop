using NCop.Mixins.Engine;
using NCop.Weaving;

namespace NCop.Composite.Mixins.Weaving
{
    public interface ICompositeMixinsTypeWeaverBuilder : ITypeWeaverBuilder, IMethodWeaverBuilderBag, IMixinMapBag
    {
    }
}
