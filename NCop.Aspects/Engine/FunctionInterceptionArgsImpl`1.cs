using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class FunctionInterceptionArgsImpl<TInstance, TArg1, TResult> : FunctionInterceptionArgs<TArg1, TResult>, IFunctionArgs<TArg1, TResult>
	{
        private TInstance instance = default(TInstance);
        private readonly IFunctionBinding<TInstance, TArg1, TResult> funcBinding = null;

        public FunctionInterceptionArgsImpl(TInstance instance, MethodInfo method, IFunctionBinding<TInstance, TArg1, TResult> funcBinding, TArg1 arg1) {
            Arg1 = arg1;
            Method = method;
            this.funcBinding = funcBinding;
            Instance = this.instance = instance;
        }

        public override void Proceed() {
            ReturnValue = funcBinding.Invoke(ref instance, this);
        }

        public override TResult Invoke() {
            throw new NotImplementedException();
        }
    }
}