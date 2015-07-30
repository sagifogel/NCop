using NCop.Mixins.Engine;
using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    public interface ICompositeMixinsTypeWeaverBuilder : ITypeWeaverBuilder, IMethodWeaverBuilderBag, IPropertyWeaverBuilderBag, IEventWeaverBuilderBag, IMixinMapBag
    {
    }
}
