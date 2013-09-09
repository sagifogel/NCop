
using NCop.Aspects.Engine;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects.Builders
{
    public interface IAspectBuilderProvider
    {
		IAspectBuilder GetBuilder(MemberInfo memberInfo);
		bool CanBuild(MemberInfo memberInfo);
        bool CanBuildAspectFromType(Type aspectType);
    }
}
