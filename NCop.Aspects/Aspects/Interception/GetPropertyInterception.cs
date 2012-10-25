using NCop.Aspects.Engine;
using System.Reflection;

namespace NCop.Aspects.Aspects.Interception
{
    public class GetPropertyInterception : IJointPoint, IPropertyGetExecuter, IPreventable
    {
        public object ProceedGetValue() {
            return null;
        }

        public object Instance { get; private set; }

        public bool IsPrevented { get; private set; }

        public MethodInfo Method { get; private set; }
    }
}
