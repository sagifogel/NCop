using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class FunctionInterceptionArgsImpl<TInstance, TArg1, TArg2, TArg3, TResult> : FunctionInterceptionArgs<TArg1, TArg2, TArg3, TResult>, IInterceptable
	{
        private TInstance instance = default(TInstance);
        private readonly IFunctionBinding<TInstance, TArg1, TArg2, TArg3, TResult> funcBinding = null;

        public FunctionInterceptionArgsImpl(TInstance instance, IFunctionBinding<TInstance, TArg1, TArg2, TArg3, TResult> funcBinding, TArg1 arg1, TArg2 arg2, TArg3 arg3) {
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
            Instance = instance;
            this.funcBinding = funcBinding;
        }

        public override void Proceed() {
            var instance = Instance;

            ReturnValue = funcBinding.Invoke(ref this.instance, Arg1, Arg2, Arg3);
        }
    }
}
