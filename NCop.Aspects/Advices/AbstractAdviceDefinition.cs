using NCop.Aspects.Weaving;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

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
        public abstract IAdviceExpression Accept(AdviceVisitor visitor);
        public abstract void Accept(AdviceDiscoveryVisitor visitor);
    }
}
