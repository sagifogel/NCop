using System;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    public interface IAspectRepository
    {
        FieldInfo GetAspectFieldByType(Type type);
    }
}
