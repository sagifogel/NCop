using NCop.Aspects.Framework;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class FunctionExecutionArgsImpl<TInstance, TArg1, TArg2, TResult> : FunctionExecutionArgs<TArg1, TArg2, TResult>, IFunctionArgs<TArg1, TArg2, TResult>
    {
        public FunctionExecutionArgsImpl(TInstance instance, MethodInfo method, TArg1 arg1, TArg2 arg2) {
            Arg1 = arg1;
            Arg2 = arg2;
            Method = method;
            Instance = instance;
        }
    }
}

