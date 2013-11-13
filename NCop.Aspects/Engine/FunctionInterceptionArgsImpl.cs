using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class FunctionInterceptionArgsImpl<TResult> : FunctionInterceptionArgs<TResult>, IInterceptable
	{
        private readonly IFunctionBinding<TResult> funcBinding = null;

        public FunctionInterceptionArgsImpl(object instance, IFunctionBinding<TResult> funcBinding) {
            Instance = instance;
            this.funcBinding = funcBinding;
        }

        public override void Proceed() {
            var instance = Instance;

            ReturnValue = funcBinding.Invoke(ref instance);
        }
    }
}