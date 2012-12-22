using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Aspects.Aspects.Builders
{
    public class TypeLevelAspectBuilderProvider : IAspectBuilderProvider
    {
        private readonly IAspectBuilder _builder = new TypeLevelAspectBuilder();
        private readonly static Type _typeofTypeLevelAspect = typeof(TypeLevelAspect);


        public bool CanBuild(Type type) {
            return _typeofTypeLevelAspect.IsAssignableFrom(type);
        }

        public IAspectBuilder Builder {
            get {
                return _builder;
            }
        }
    }
}
