using System.Reflection;

namespace NCop.Aspects.Advices
{
    public class AdviceDefinition : IAdviceDefinition
    {
        public AdviceDefinition(IAdvice advice, MemberInfo member) {
            Advice = advice;
            Member = member;
        }

        public IAdvice Advice { get; private set; }
        public MemberInfo Member { get; private set; }
    }
}
