using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Core.Extensions;

namespace NCop.Aspects.Engine
{
    public static class AspectValidator
    {
        private static readonly AspectValidatorVisitor visitor = new AspectValidatorVisitor();

        public static void ValidateAspect(IAspect aspect, AspectMap aspectMap) {
            aspectMap.Aspects.ForEach(a => a.Target.Accept(visitor, aspect, aspectMap));
        }
    }
}
