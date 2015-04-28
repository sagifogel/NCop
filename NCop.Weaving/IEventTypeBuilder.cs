
namespace NCop.Weaving
{
    public interface IEventTypeBuilder
    {
        void SetAddOnMethod(IMethodWeaver method);
        void SetRemoveOnMethod(IMethodWeaver method);
    }
}
