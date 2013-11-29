using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Engine
{
    public class FunctionInterceptionArgsImpl<TInstance, TResult> : FunctionInterceptionArgs<TResult>, IInterceptable
	{
        private TInstance instance = default(TInstance);
        private readonly IFunctionBinding<TInstance, TResult> funcBinding = null;

        public FunctionInterceptionArgsImpl(TInstance instance, IFunctionBinding<TInstance, TResult> funcBinding) {
            this.funcBinding = funcBinding;
            Instance = this.instance = instance;
        }

        public override void Proceed() {
            ReturnValue = funcBinding.Invoke(ref this.instance);
        }
    }
}