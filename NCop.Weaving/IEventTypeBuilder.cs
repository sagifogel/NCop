
namespace NCop.Weaving
{
    public interface IEventTypeBuilder
    {
        void SetAddOnMethod(IMethodWeaver addOnMethod);
        void SetRemoveOnMethod(IMethodWeaver onRemoveMethod);
    }
}
