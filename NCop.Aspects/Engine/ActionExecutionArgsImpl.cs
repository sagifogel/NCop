using NCop.Aspects.Framework;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class ActionExecutionArgsImpl<TInstance> : ActionExecutionArgs, IActionArgs
    {
        public ActionExecutionArgsImpl(TInstance instance, MethodInfo method) {
            Method = method;
            Instance = instance;
        }
    }
}
