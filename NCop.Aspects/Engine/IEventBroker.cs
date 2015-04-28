
namespace NCop.Aspects.Engine
{
    public interface IEventBroker<in TDelegate>
    {
        void AddHandler(TDelegate handler);
        void RemoveHandler(TDelegate handler);
    }
}
