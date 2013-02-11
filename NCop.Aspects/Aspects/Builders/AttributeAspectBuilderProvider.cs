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
    public class AttributeAspectBuilderProvider : IAspectBuilderProvider
    {
        private readonly IAspectBuilder _builder = new AttributeAspectBuilder();

        public bool CanBuild(MethodInfo methodInfo) {
            return methodInfo.IsDefined<AspectAttribute>();
        }

        public IAspectBuilder Builder {
            get {
                return _builder;
            }
        }

        public bool CanBuildAspectFromType(Type aspectType) {
            return aspectType.GetInterfaces()
                             .Any(@interface => @interface.Equals(typeof(IAspectFilter)));
        }
    }
}
