using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class FunctionInterceptionArgsImpl<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> : FunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>, IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>
    {
        private TInstance instance = default(TInstance);
        private readonly IFunctionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> funcBinding = null;

        public FunctionInterceptionArgsImpl(TInstance instance, MethodInfo method, IFunctionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> funcBinding, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8) {
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
            Arg4 = arg4;
            Arg5 = arg5;
            Arg6 = arg6;
            Arg7 = arg7;
            Arg8 = arg8;
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
