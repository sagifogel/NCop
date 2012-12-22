
using NCop.Aspects.Engine;
using System;

namespace NCop.Aspects.Aspects.Builders
{
    public interface IAspectBuilderProvider
    {
        bool CanBuild(Type type);
        IAspectBuilder Builder { get; }
    }
}
