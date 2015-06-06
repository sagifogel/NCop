using NCop.Weaving;

namespace NCop.Composite.Weaving
{
    public interface ICompositeEventWeaver : IEventWeaver
    {
        IMethodWeaver GetOnInvokeMethod();
    }
}
