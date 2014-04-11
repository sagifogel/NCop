using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Engine
{
	public class ActionInterceptionArgsImpl<TInstance> : ActionInterceptionArgs, IActionArgs 
    {
        private TInstance instance = default(TInstance);
        private readonly IActionBinding<TInstance> actionBinding = null;

        public ActionInterceptionArgsImpl(TInstance instance, MethodInfo method, IActionBinding<TInstance> actionBinding) {
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
