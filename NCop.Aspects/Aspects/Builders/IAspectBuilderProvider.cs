
using NCop.Aspects.Engine;
using System;
using System.Reflection;

namespace NCop.Aspects.Aspects.Builders
{
    public interface IAspectBuilderProvider
    {
		bool CanBuild(MemberInfo memberInfo);
		bool CanBuildAspectFromType(IAspect aspect);
		IAspectBuilder GetBuilder(MemberInfo memberInfo);
	}
}
