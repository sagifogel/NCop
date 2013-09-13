using System;
using System.Linq;
using NCop.Aspects.Engine;
using System.Reflection;
using NCop.Core.Extensions;
using System.Collections.Generic;
using NCop.Core.Visitors;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Aspects.Builders
{
    public class MemberLevelAspectBuilderProvider : IAspectBuilderProvider
    {
		public bool CanBuild(MemberInfo memberInfo) {
			return memberInfo.IsDefined<AspectAttribute>();
        }

		public IAspectBuilder GetBuilder(MemberInfo memberInfo) {
			return new MemberLevelAspectBuilder(memberInfo);
        }

        public bool CanBuildAspectFromType(IAspect aspect) {
			return true;
        }
    }
}
