using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class ActionInterceptionArgsImpl<TArg1, TArg2> : ActionExecutionArgs<TArg1, TArg2>
    {
        private readonly IActionBinding<TArg1, TArg2> actionBinding = null;

        public ActionInterceptionArgsImpl(object instance, IActionBinding<TArg1, TArg2> actionBinding, TArg1 arg1, TArg2 arg2) {
            Arg1 = arg1;
            Arg2 = arg2;
            Instance = instance;
            this.actionBinding = actionBinding;
        }

        public override void Proceed() {
            var instance = Instance;

            actionBinding.Invoke(ref instance, Arg1, Arg2);
        }
    }
}
