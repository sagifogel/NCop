using NCop.Composite.Engine;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using System;
using System.Reflection;

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

        public static bool GetDisposableFromAttribute(this Type type) {
            var compositeAtrribute = type.GetCustomAttribute<CompositeAttribute>();

            if (compositeAtrribute.IsNotNull()) {
                return compositeAtrribute.Disposable;
            }

            return false;
        }
    }
}
