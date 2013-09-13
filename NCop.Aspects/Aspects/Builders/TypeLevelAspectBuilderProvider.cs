using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Core.Extensions;

namespace NCop.Aspects.Aspects.Builders
{
	public class TypeLevelAspectBuilderProvider : IAspectBuilderProvider
	{
		private readonly static Type typeofTypeLevelAspect = typeof(TypeLevelAspectAttribute);

		public bool CanBuild(MemberInfo memberInfo) {
			var aspectAttribute = memberInfo.DeclaringType.GetCustomAttribute<AspectAttribute>();
			
			return CanBuildAspectFromType(aspectAttribute);
        }

		public IAspectBuilder GetBuilder(MemberInfo memberInfo) {
			return new TypeLevelAspectBuilder();
		}

		public bool CanBuildAspectFromType(IAspect aspect) {
			return typeofTypeLevelAspect.IsAssignableFrom(aspect.AspectType);
		}
	}
}
