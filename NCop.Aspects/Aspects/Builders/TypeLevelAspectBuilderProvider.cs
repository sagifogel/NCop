using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Aspects.Builders
{
    public class TypeLevelAspectBuilderProvider : IAspectBuilderProvider
    {
        private readonly IAspectBuilder _builder = new TypeLevelAspectBuilder();
        private readonly static Type _typeofTypeLevelAspect = typeof(TypeLevelAspect);

        public bool CanBuild(MethodInfo methodInfo) {
            return CanBuildAspectFromType(methodInfo.DeclaringType);
        }

        public IAspectBuilder Builder {
            get {
                return _builder;
            }
        }

        public bool CanBuildAspectFromType(Type aspectType) {
            return _typeofTypeLevelAspect.IsAssignableFrom(aspectType);
        }
    }
}
