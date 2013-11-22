using System.Reflection;
using NCop.Aspects.Weaving.Expressions;

namespace NCop.Aspects.Advices
{
	internal abstract class AbstractAdviceDefinition : IAdviceDefinition
    {
        internal AbstractAdviceDefinition(IAdvice advice, MethodInfo adviceMethod) {
            Advice = advice;
            AdviceMethod = adviceMethod;
        }

        public IAdvice Advice { get; private set; }
        public MethodInfo AdviceMethod { get; private set; }
        public abstract IAspectExpression Accept(AdviceVisitor visitor);
	}
}
