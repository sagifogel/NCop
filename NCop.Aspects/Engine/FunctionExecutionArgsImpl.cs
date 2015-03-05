using NCop.Aspects.Framework;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class FunctionExecutionArgsImpl<TInstance, TResult> : FunctionExecutionArgs<TResult>, IFunctionArgs<TResult>
    {
        public FunctionExecutionArgsImpl(TInstance instance, MethodInfo method) {
            Method = method;
            Instance = instance;
        }
    }
}
