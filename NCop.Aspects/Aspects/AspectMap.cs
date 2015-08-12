using System.Reflection;

namespace NCop.Aspects.Aspects
{
    public class AspectMap
    {
        public static AspectMap Empty = new AspectMap();

        private AspectMap() { }

        public AspectMap(MemberInfo target, MemberInfo contract, MethodInfo method, IAspectDefinitionCollection aspects) {
            Method = method;
            Target = target;
            Aspects = aspects;
            Contract = contract;
        }

        public MemberInfo Target { get; private set; }
        public MethodInfo Method { get; private set; }
        public MemberInfo Contract { get; private set; }
        public IAspectDefinitionCollection Aspects { get; private set; }
    }
}
