using System.Reflection;

namespace NCop.Aspects.Aspects
{
    public class AspectMap
    {
        public static AspectMap Empty = new AspectMap();

        private AspectMap() {
        }

        public AspectMap(MethodInfo method, IAspectDefinitionCollection aspects) {
            Method = method;
            Aspects = aspects;
        }

        public MethodInfo Method { get; private set; }
        public IAspectDefinitionCollection Aspects { get; private set; }
    }
}
