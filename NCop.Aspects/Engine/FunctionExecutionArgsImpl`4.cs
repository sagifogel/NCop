using NCop.Aspects.Framework;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class FunctionExecutionArgsImpl<TInstance, TArg1, TArg2, TArg3, TArg4, TResult> : FunctionExecutionArgs<TArg1, TArg2, TArg3, TArg4, TResult>, IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TResult>
    {
        public FunctionExecutionArgsImpl(TInstance instance, MethodInfo method, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4) {
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
            Arg4 = arg4;
            Method = method;
            Instance = instance;
        }
    }
}

