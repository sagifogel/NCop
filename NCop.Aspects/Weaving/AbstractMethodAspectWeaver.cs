using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using NCop.Core.Extensions;

namespace NCop.Aspects.Weaving
{
    public abstract class AbstractMethodAspectWeaver : IMethodScopeWeaver
    {
        protected IMethodScopeWeaver weaver = null;
        protected readonly IAspectDefinition aspectDefinition = null;
        protected readonly IAdviceDefinitionCollection advices = null;
        protected readonly AdviceVisitor adviceVisitor = new AdviceVisitor();
        protected readonly AdviceDiscoveryVisitor adviceDiscoveryVistor = new AdviceDiscoveryVisitor();

        public AbstractMethodAspectWeaver(IAspectExpression expression, IAspectDefinition aspectDefinition){
            advices = aspectDefinition.Advices;
            aspectDefinition.Advices.ForEach(advice => advice.Accept(adviceDiscoveryVistor));
            this.aspectDefinition = aspectDefinition;
        }

        private IAdviceExpression ResolveOnMethodEntryAdvice() {
            IAdviceDefinition selectedAdviceDefinition = null;
            Func<IAdviceDefinition, IAdviceExpression> adviceExpressionFactory = null;
            var onMethodInvokeAdvice = adviceDiscoveryVistor.OnMethodInvokeAdvice;

            adviceExpressionFactory = adviceVisitor.Visit(adviceDiscoveryVistor.OnMethodInvokeAdvice);
            selectedAdviceDefinition = advices.First(advice => advice.Advice.Equals(onMethodInvokeAdvice));

            return adviceExpressionFactory(selectedAdviceDefinition);
        }

        public abstract ILGenerator Weave(ILGenerator iLGenerator, ITypeDefinition typeDefinition);
    }
}
