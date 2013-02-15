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
        public bool CanBuild(MethodInfo methodInfo) {
            return methodInfo.IsDefined<AspectAttribute>();
        }

        public IAspectBuilder GetBuilder(MethodInfo methodInfo) {
            return new AttributeAspectBuilder(methodInfo);
        }

        public bool CanBuildAspectFromType(Type aspectType) {
            return aspectType.GetInterfaces()
                             .Any(@interface => @interface.Equals(typeof(IAspectFilter)));
        }
    }
}
