using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class FunctionInterceptionArgsImpl<TArg1, TArg2, TArg3, TArg4, TResult> : FunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TResult>
	{
        private readonly IFunctionBinding<TArg1, TArg2, TArg3, TArg4, TResult> funcBinding = null;

        public FunctionInterceptionArgsImpl(object instance, IFunctionBinding<TArg1, TArg2, TArg3, TArg4, TResult> funcBinding, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4) {
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
            Arg4 = arg4;
            Instance = instance;
            this.funcBinding = funcBinding;
        }

        public override void Proceed() {
            var instance = Instance;

            funcBinding.Invoke(ref instance, Arg1, Arg2, Arg3, Arg4);
        }
    }
}

