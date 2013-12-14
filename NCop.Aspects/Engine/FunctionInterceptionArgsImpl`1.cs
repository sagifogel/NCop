using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class FunctionInterceptionArgsImpl<TInstance, TArg1, TResult> : FunctionInterceptionArgs<TArg1, TResult>, IInterceptable
	{
        private TInstance instance = default(TInstance);
        private readonly IFunctionBinding<TInstance, TArg1, TResult> funcBinding = null;

        public FunctionInterceptionArgsImpl(TInstance instance, IFunctionBinding<TInstance, TArg1, TResult> funcBinding, TArg1 arg1) {
            Arg1 = arg1;
            this.funcBinding = funcBinding;
            Instance = this.instance = instance;
        }

        public override void Proceed() {
            var instance = this.instance;

            ReturnValue = funcBinding.Invoke(ref instance, Arg1);
        }
    }
}