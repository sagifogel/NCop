using System.Reflection;
using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;

namespace NCop.Aspects.Extensions
{
    public static class MemberInfoExtensions
    {
        public static void Accept(this MemberInfo member, AspectValidatorVisitor visitor, IAspect aspect, AspectMap aspectMap) {
            visitor.Visit((dynamic)member, aspect, aspectMap);
        }
    }
}
