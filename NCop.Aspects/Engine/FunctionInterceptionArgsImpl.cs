using NCop.Aspects.Framework;
using System.Reflection;

namespace NCop.Aspects.Engine
{
	public class FunctionInterceptionArgsImpl<TInstance, TResult> : FunctionInterceptionArgs<TResult>, IFunctionArgs<TResult>
	{
		private TInstance instance = default(TInstance);
		private readonly IFunctionBinding<TInstance, TResult> funcBinding = null;

		public FunctionInterceptionArgsImpl(TInstance instance, MethodInfo method, IFunctionBinding<TInstance, TResult> funcBinding) {
			Method = method;
			this.funcBinding = funcBinding;
			Instance = this.instance = instance;
		}

		public override void Proceed() {
			ReturnValue = funcBinding.Proceed(ref instance, this);
		}

		public override void Invoke() {
			ReturnValue = funcBinding.Invoke(ref instance, this);
		}
	}
}