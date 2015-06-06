using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    public interface ICompositeEventTypeBuilder : IEventTypeBuilder
    {
        void SetOnInvokeMethod(IMethodWeaver onInvokeMethod);
    }
}
