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
        private readonly static string compositeTypeFmt = "<NCop>{0}";

        internal static string GetNameFromAttribute(this Type type) {
            var namedAtrribute = type.GetCustomAttribute<NamedAttribute>();

            return namedAtrribute.IsNotNull() ? namedAtrribute.Name : null;
        }

        internal static Type GetTypeFromAttribute(this Type type) {
            var compositeAtrribute = type.GetCustomAttribute<CompositeAttribute>();

            return compositeAtrribute.IsNotNull() ? compositeAtrribute.As : null;
        }

        internal static string ToCompositeName(this string name) {
            name = name ?? string.Empty;

            return compositeTypeFmt.Fmt(name);
        }
    }
}
