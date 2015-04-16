using NCop.Aspects.Aspects;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public static class AspectValidator
    {
        public static void ValidateAspect(IAspect aspect, MemberInfo member) {
            if (member.MemberType == MemberTypes.Method) {
                AspectTypeMethodValidator.ValidateMethodAspect(aspect, member as MethodInfo);
            }
        }
    }
}
