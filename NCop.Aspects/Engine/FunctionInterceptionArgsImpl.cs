using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class FunctionInterceptionArgsImpl<TResult> : FunctionExecutionArgs<TResult>, IInterceptable
	{
        private readonly IFuncBinding<TResult> funcBinding = null;

        public FunctionInterceptionArgsImpl(object instance, IFuncBinding<TResult> funcBinding) {
            Instance = instance;
            this.funcBinding = funcBinding;
        }

        public void Proceed() {
            var instance = Instance;

            ReturnValue = funcBinding.Invoke(ref instance);
        }
    }
}