using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class FunctionInterceptionArgsImpl<TInstance, TArg1, TArg2, TArg3, TResult> : FunctionInterceptionArgs<TArg1, TArg2, TArg3, TResult>, IFunctionArgs<TArg1, TArg2, TArg3, TResult>
    {
        private TInstance instance = default(TInstance);
        private readonly IFunctionBinding<TInstance, TArg1, TArg2, TArg3, TResult> funcBinding = null;

        public FunctionInterceptionArgsImpl(TInstance instance, MethodInfo method, IFunctionBinding<TInstance, TArg1, TArg2, TArg3, TResult> funcBinding, TArg1 arg1, TArg2 arg2, TArg3 arg3) {
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
            Method = method;
            this.funcBinding = funcBinding;
            Instance = this.instance = instance;
        }

        public override void Proceed() {
            ReturnValue = funcBinding.Proceed(ref instance, this);
        }

        public override void Invoke() {
			 ReturnValue = funcBinding.Invoke(ref instance, this);
        }
    }
}
