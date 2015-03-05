
namespace NCop.Aspects.Engine
{
    public interface IActionBinding<TInstance>
    {
        void Invoke(ref TInstance instance, IActionArgs args);
        void Proceed(ref TInstance instance, IActionArgs args);
    }
}
