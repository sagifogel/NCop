using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class ActionInterceptionArgsImpl<TInstance, TArg1, TArg2> : ActionInterceptionArgs<TArg1, TArg2>, IActionArgs<TArg1, TArg2> 
    {
        private TInstance instance = default(TInstance);
        private readonly IActionBinding<TInstance, TArg1, TArg2> actionBinding = null;

        public ActionInterceptionArgsImpl(TInstance instance, IActionBinding<TInstance, TArg1, TArg2> actionBinding, TArg1 arg1, TArg2 arg2) {
            Arg1 = arg1;
            Arg2 = arg2;
            this.actionBinding = actionBinding;
            Instance = this.instance = instance;
        }

        public override void Proceed() {
            actionBinding.Invoke(ref instance, this);
        }
    }
}
