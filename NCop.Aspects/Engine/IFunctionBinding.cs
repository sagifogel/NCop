
namespace NCop.Aspects.Engine
{
    public interface IFunctionBinding<TInstance, TResult>
    {
        TResult Invoke(ref TInstance instance, IFunctionArgs<TResult> args);
        TResult Proceed(ref TInstance instance, IFunctionArgs<TResult> args);
    }
}
