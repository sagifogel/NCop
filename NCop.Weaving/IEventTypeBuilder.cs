
namespace NCop.Weaving
{
    public interface IEventTypeBuilder
    {
        void SetAddMethod(IMethodWeaver addMethod);
        void SetRemoveMethod(IMethodWeaver removeMethod);
        void SetInvokeMethod(IMethodWeaver invokeMethod);
    }
}
