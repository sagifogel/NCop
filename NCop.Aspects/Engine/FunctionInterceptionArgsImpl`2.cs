using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class FunctionInterceptionArgsImpl<TArg1, TArg2, TResult> : FunctionExecutionArgs<TArg1, TArg2, TResult>, IInterceptable
    {
        private readonly IFunctionBinding<TArg1, TArg2, TResult> funcBinding = null;

        public FunctionInterceptionArgsImpl(object instance, IFunctionBinding<TArg1, TArg2, TResult> funcBinding, TArg1 arg1, TArg2 arg2) {
            Arg1 = arg1;
            Arg2 = arg2;
            Instance = instance;
            this.funcBinding = funcBinding;
        }

        public void Proceed() {
            var instance = Instance;

            funcBinding.Invoke(ref instance, Arg1, Arg2);
        }
    }
}