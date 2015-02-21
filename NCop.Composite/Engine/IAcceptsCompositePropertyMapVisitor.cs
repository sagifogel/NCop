
using NCop.Core;
using NCop.Weaving;

namespace NCop.Composite.Engine
{
    public interface IAcceptsCompositePropertyMapVisitor : IAcceptsVisitor<ICompositePropertyMapVisitor, IPropertyWeaverBuilder>
    {
    }
}
