
namespace NCop.Weaving
{
    public interface IEventWeaver : IWeaver
    {
        IMethodWeaver GetOnAddMethod();
        IMethodWeaver GetOnRemoveMethod();
    }
}
