
namespace NCop.Aspects.Engine
{
	public interface IActionBinding<TInstance, TArg1>
	{
		void Invoke(ref TInstance instance, IActionArgs<TArg1> args);
		void Proceed(ref TInstance instance, IActionArgs<TArg1> args);
	}
}
