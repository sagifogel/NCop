
namespace NCop.Composite.Engine
{
    public interface ICompositeEventMapVisitor
    {
        void Visit(CompositeAddEventMap eventMap);
        void Visit(CompositeRaiseEventMap eventMap);
        void Visit(CompositeRemoveEventMap eventMap);
    }
}
