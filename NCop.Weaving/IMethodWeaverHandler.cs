using System.Reflection;

namespace NCop.Weaving
{
    public interface IMethodWeaverHandler
    {
        IMethodWeaver Handle(MethodInfo method, ITypeDefinition typeDefinition);
    }
}
