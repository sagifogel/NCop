
using NCop.Aspects.Engine;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects.Builders
{
    public interface IAspectBuilderProvider
    {
        IAspectBuilder Builder { get; }
        bool CanBuild(MethodInfo methodInfo);
        bool CanBuildAspectFromType(Type aspectType);
    }
}
