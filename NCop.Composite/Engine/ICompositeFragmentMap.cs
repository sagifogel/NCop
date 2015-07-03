using System.Reflection;

namespace NCop.Composite.Engine
{
    public interface ICompositeFragmentMap
    {
        MethodInfo FragmentMethod { get; }
    }
}
