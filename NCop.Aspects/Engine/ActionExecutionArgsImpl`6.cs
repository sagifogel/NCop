using NCop.Aspects.Framework;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class ActionExecutionArgsImpl<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> : ActionExecutionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, IActionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
	{
        public ActionExecutionArgsImpl(TInstance instance, MethodInfo method, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6) {
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
            Arg4 = arg4;
            Arg5 = arg5;
            Arg6 = arg6;
            Method = method;
            Instance = instance;
        }
	}
}
