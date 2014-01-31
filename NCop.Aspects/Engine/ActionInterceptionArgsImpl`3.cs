using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class ActionInterceptionArgsImpl<TInstance, TArg1, TArg2, TArg3> : ActionInterceptionArgs<TArg1, TArg2, TArg3>
    {
        private TInstance instance = default(TInstance);
        private readonly IActionBinding<TInstance, TArg1, TArg2, TArg3> actionBinding = null;

        public ActionInterceptionArgsImpl(TInstance instance, IActionBinding<TInstance, TArg1, TArg2, TArg3> actionBinding, TArg1 arg1, TArg2 arg2, TArg3 arg3) {
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
            this.actionBinding = actionBinding;
            Instance = this.instance = instance;
        }

        public override void Proceed() {
            actionBinding.Invoke(ref instance, this);
        }

        public override void Invoke(TArg1 arg1, TArg2 arg2, TArg3 arg3) {
            throw new NotImplementedException();
        }
    }
}
