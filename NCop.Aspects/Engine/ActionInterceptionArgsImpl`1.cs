using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class ActionInterceptionArgsImpl<TInstance, TArg1> : ActionInterceptionArgs<TArg1>
    {
        private TInstance instance = default(TInstance);
        private readonly IActionBinding<TInstance, TArg1> actionBinding = null;

        public ActionInterceptionArgsImpl(TInstance instance, IActionBinding<TInstance, TArg1> actionBinding, TArg1 arg1) {
            Arg1 = arg1;
            this.actionBinding = actionBinding;
            Instance = this.Instance = instance;
        }

        public override void Proceed() {
            var instance = Instance;

            actionBinding.Invoke(ref this.instance, Arg1);
        }
    }
}
