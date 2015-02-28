using NCop.Aspects.Framework;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class ActionInterceptionArgsImpl<TInstance, TArg1, TArg2> : ActionInterceptionArgs<TArg1, TArg2>, IActionArgs<TArg1, TArg2>
    {
        private TInstance instance = default(TInstance);
        private readonly IActionBinding<TInstance, TArg1, TArg2> actionBinding = null;

        public ActionInterceptionArgsImpl(TInstance instance, MethodInfo method, IActionBinding<TInstance, TArg1, TArg2> actionBinding, TArg1 arg1, TArg2 arg2) {
            Arg1 = arg1;
            Arg2 = arg2;
            Method = method;
            this.actionBinding = actionBinding;
            Instance = this.instance = instance;
        }

        public override void Proceed() {
			actionBinding.Proceed(ref instance, this);
        }

        public override void Invoke() {
			actionBinding.Invoke(ref instance, this);
        }
    }
}
