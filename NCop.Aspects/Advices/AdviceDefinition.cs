using System.Reflection;

namespace NCop.Aspects.Advices
{
    public class AdviceDefinition : IAdviceDefinition
    {
        public AdviceDefinition(IAdvice advice, MethodInfo adviceMethod) {
            Advice = advice;
            AdviceMethod = adviceMethod;
        }

        public IAdvice Advice { get; private set; }
        public MethodInfo AdviceMethod { get; private set; }
    }
}
