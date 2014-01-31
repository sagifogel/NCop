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
            actionBinding.Invoke(ref instance, this);
        }

        public override void Invoke(TArg1 arg1) {
            throw new NotImplementedException();
        }
    }
}
