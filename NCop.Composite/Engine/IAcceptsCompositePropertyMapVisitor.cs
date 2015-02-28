
using NCop.Core;

namespace NCop.Composite.Engine
{
    public interface IAcceptsCompositePropertyMapVisitor : IAcceptsVisitor<ICompositePropertyMapVisitor, ICompositeMethodWeaverBuilderFactory>
    {
    }
}
