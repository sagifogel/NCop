using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Aspects.Advices;

namespace NCop.Aspects.Weaving.Expressions
{
    internal abstract class AbstractAdviceExpression : IAdviceExpression
    {
        protected readonly IAdviceDefinition adviceDefinition = null;

        internal AbstractAdviceExpression(IAdviceDefinition adviceDefinition) {
            this.adviceDefinition = adviceDefinition;
        }

        protected abstract AdviceType AdviceType { get; }

        public abstract IMethodScopeWeaver Reduce(IAdviceWeavingSettings adviceWeavingSettings);
    }
}
