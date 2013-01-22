using System;
using System.Linq;
using NCop.Aspects.Engine;
using System.Reflection;
using NCop.Core.Extensions;
using System.Collections.Generic;
using NCop.Core.Visitors;

namespace NCop.Aspects.Aspects.Builders
{
    public class AttributeAspectBuilderProvider : IAspectBuilderProvider, IProjectionTypeVisitor<bool>
    {
        private readonly IAspectBuilder _builder = new AttributeAspectBuilder();

        public bool CanBuild(Type type) {
            return Visit(type);
        }

        public IAspectBuilder Builder {
            get {
                return _builder;
            }
        }

        public BindingFlags Flags {
            get {
                return BindingFlags.Public | BindingFlags.Instance;
            }
        }

        public bool Visit(Type type) {
            return Visit(type.GetMethods()) || Visit(type.GetProperties());
        }

        public bool Visit(MethodInfo[] methods) {
            return methods.Any(method => {
                return method.IsDefined<AspectAttribute>();
            });
        }

        public bool Visit(PropertyInfo[] properties) {
            return properties.Any(property => {
                return property.IsDefined<AspectAttribute>();
            });
        }
    }
}
