using NCop.Aspects.Framework;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class ActionExecutionArgsImpl<TInstance, TArg1, TArg2> : ActionExecutionArgs<TArg1, TArg2>, IActionArgs<TArg1, TArg2>
    {
        public ActionExecutionArgsImpl(TInstance instance, MethodInfo method, TArg1 arg1, TArg2 arg2) {
            Arg1 = arg1;
            Arg2 = arg2;
            Method = method;
            Instance = instance;
        }
    }
}
