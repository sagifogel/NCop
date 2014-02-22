using NCop.Composite.Framework;
using System;
using System.Linq;
using System.Reflection;
using NCop.Core.Extensions;

namespace NCop.Composite.Extensions
{
    public static class CompositeExtensions
    {
        public static string GetNamedAttribute(this Type type) {
            var namedAtrribute = type.GetCustomAttribute<NamedAttribute>();

            return namedAtrribute.IsNotNull() ? namedAtrribute.Name : null;
        }
    }
}
