using System.Reflection;

namespace NCop.Aspects.Weaving
{
    public interface IAspectArgsMapper
    {
        MethodInfo GetActionToPropertyMappingArgs();
        MethodInfo GetPropertyToActionMappingArgs();
        MethodInfo GetFunctionToPropertyMappingArgs();
        MethodInfo GetPropertyToFunctionMappingArgs();
        MethodInfo GetActionMappingArgs(int argumentCount);
        MethodInfo GetFunctionMappingArgs(int argumentCount);
    }
}
