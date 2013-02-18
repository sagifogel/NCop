using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Aspects.Builders
{
    public class TypeLevelAspectBuilderProvider : IAspectBuilderProvider
    {
        private readonly static Type _typeofTypeLevelAspect = typeof(TypeLevelAspectAttribute);

        public bool CanBuild(MethodInfo methodInfo) {
            return CanBuildAspectFromType(methodInfo.DeclaringType);
        }

        public IAspectBuilder GetBuilder(MethodInfo methodInfo) {
            return new TypeLevelAspectBuilder();
        }

        public bool CanBuildAspectFromType(Type aspectType) {
            return _typeofTypeLevelAspect.IsAssignableFrom(aspectType);
        }
    }
}
