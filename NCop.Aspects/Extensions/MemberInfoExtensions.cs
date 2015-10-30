using NCop.Aspects.Aspects;
using NCop.Aspects.Engine;
using System.Reflection;

namespace NCop.Aspects.Extensions
{
    public static class MemberInfoExtensions
    {
        public static void Accept(this MemberInfo member, AspectValidatorVisitor visitor, IAspect aspect, AspectMap aspectMap) {
            visitor.Visit((dynamic)member, aspect, aspectMap);
        }
    }
}
