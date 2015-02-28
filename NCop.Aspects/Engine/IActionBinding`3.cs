
namespace NCop.Aspects.Engine
{
    public interface IActionBinding<TInstance, TArg1, TArg2, TArg3>
    {
		void Invoke(ref TInstance instance, IActionArgs<TArg1, TArg2, TArg3> args);
		void Proceed(ref TInstance instance, IActionArgs<TArg1, TArg2, TArg3> args);
	}
}
