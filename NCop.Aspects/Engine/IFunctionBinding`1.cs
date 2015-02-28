
namespace NCop.Aspects.Engine
{
    public interface IFunctionBinding<TInstance, TArg1, TResult>
    {
        TResult Invoke(ref TInstance instance, IFunctionArgs<TArg1, TResult> args);
		TResult Proceed(ref TInstance instance, IFunctionArgs<TArg1, TResult> args);
	}
}
