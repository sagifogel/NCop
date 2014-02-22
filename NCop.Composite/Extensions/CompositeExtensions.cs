using NCop.Composite.Framework;
using System;
using System.Linq;
using System.Reflection;
using NCop.Core.Extensions;
using NCop.Composite.Engine;

namespace NCop.Composite.Extensions
{
    public static class CompositeExtensions
    {
        public static string GetNameFromAttribute(this Type type) {
            var namedAtrribute = type.GetCustomAttribute<NamedAttribute>();

            return namedAtrribute.IsNotNull() ? namedAtrribute.Name : null;
        }

        public static Type GetTypeFromAttribute(this Type type) {
            var compositeAtrribute = type.GetCustomAttribute<CompositeAttribute>();

            return compositeAtrribute.IsNotNull() ? compositeAtrribute.As : null;
        }
    }
}
