
namespace NCop.Aspects.Engine
{
    public interface IFunctionBinding<TInstance, TArg1, TArg2, TResult>
    {
		TResult Invoke(ref TInstance instance, IFunctionArgs<TArg1, TArg2, TResult> args);
		TResult Proceed(ref TInstance instance, IFunctionArgs<TArg1, TArg2, TResult> args);
	}
}
