using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;

namespace NCop.Aspects.Engine
{
    public static class AspectValidator
    {
        private static readonly AspectValidatorVisitor visitor = new AspectValidatorVisitor();

        public static void ValidateAspect(IAspect aspect, AspectMap aspectMap) {
            aspectMap.Target.Accept(visitor, aspect, aspectMap);
        }
    }
}
