using System;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    public interface IArgumentsWeavingSettings : IArgumentsSettings
	{
        Type AspectType { get; }
		FieldInfo BindingsDependency { get; }
    }
}
