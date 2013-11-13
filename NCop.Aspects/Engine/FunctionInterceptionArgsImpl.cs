using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class FunctionInterceptionArgsImpl<TInstance, TResult> : FunctionExecutionArgs<TInstance, TResult>, IInterceptable
	{
        private readonly IFunctionBinding<TInstance, TResult> funcBinding = null;

        public FunctionInterceptionArgsImpl(object instance, IFunctionBinding<TInstance, TResult> funcBinding) {
            Instance = instance;
            this.funcBinding = funcBinding;
        }

        public void Proceed() {
            var instance = Instance;

            ReturnValue = funcBinding.Invoke(ref instance);
        }
    }
}