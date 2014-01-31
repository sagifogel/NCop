using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class FunctionInterceptionArgsImpl<TInstance, TArg1, TArg2, TResult> : FunctionInterceptionArgs<TArg1, TArg2, TResult>
    {
        private TInstance instance = default(TInstance);
        private readonly IFunctionBinding<TInstance, TArg1, TArg2, TResult> funcBinding = null;

        public FunctionInterceptionArgsImpl(TInstance instance, IFunctionBinding<TInstance, TArg1, TArg2, TResult> funcBinding, TArg1 arg1, TArg2 arg2) {
            Arg1 = arg1;
            Arg2 = arg2;
            this.funcBinding = funcBinding;
            Instance = this.instance = instance;
        }

        public override void Proceed() {
            ReturnValue = funcBinding.Invoke(ref instance, this);
        }

        public override TResult Invoke(TArg1 arg1, TArg2 arg2) {
            throw new NotImplementedException();
        }
    }
}