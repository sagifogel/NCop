using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Weaving.Expressions
{
    internal abstract class AbstractAdviceExpression : IExpressionReducer
    {
        protected MethodInfo adviceMethod = null;

        public AbstractAdviceExpression(MethodInfo adviceMethod) {
            this.adviceMethod = adviceMethod;
        }

        public abstract IMethodScopeWeaver Reduce();
    }
}
