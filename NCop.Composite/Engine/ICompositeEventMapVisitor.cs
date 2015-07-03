
namespace NCop.Composite.Engine
{
    public interface ICompositeEventMapVisitor
    {
        void Visit(CompositeAddEventMap eventMap);
        void Visit(CompositeRemoveEventMap eventMap);
        void Visit(CompositeInvokeEventMap eventMap);
    }
}
