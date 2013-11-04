using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class ActionInterceptionArgsImpl : ActionExecutionArgs
    {
        private readonly IActionBinding actionBinding = null;

        public ActionInterceptionArgsImpl(object instance, IActionBinding actionBinding) {
            Instance = instance;
            this.actionBinding = actionBinding;
        }

        public override void Proceed() {
            var instance = Instance;

            actionBinding.Invoke(ref instance);
        }
    }
}
