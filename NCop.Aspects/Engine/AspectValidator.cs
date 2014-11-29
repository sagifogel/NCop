using System.Reflection;
using NCop.Aspects.Aspects;
using NCop.Aspects.Exceptions;
using NCop.Aspects.Extensions;
using NCop.Aspects.Properties;

namespace NCop.Aspects.Engine
{
    public static class AspectValidator
    {
        public static void ValidateAspect(IAspect aspect, MemberInfo memberInfo) {
            if (aspect.IsMethodLevelAspect()) {
                if (memberInfo.MemberType != MemberTypes.Method) {
                    throw new AspectAnnotationException(Resources.IllegalMethodAspectAnnotation);
                }

                AspectTypeMethodValidator.ValidateMethodAspect(aspect, memberInfo as MethodInfo);
            }
        }
    }
}
