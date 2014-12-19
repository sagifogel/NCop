using System;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    public interface IAspectArgsMapper
    {
        MethodInfo GetActionMappingArgs(int argumentCount);
        MethodInfo GetFunctionMappingArgs(int argumentCount);
        MethodInfo GetPropertyMappingArgs(Type fromType, Type toType);
    }
}
