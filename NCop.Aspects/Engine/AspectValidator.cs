using NCop.Aspects.Aspects;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public static class AspectValidator
    {
        public static void ValidateAspect(IAspect aspect, MethodInfo method) {
            AspectTypeMethodValidator.ValidateMethodAspect(aspect, method);
        }
    }
}
