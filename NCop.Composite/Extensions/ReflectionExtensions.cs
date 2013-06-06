using NCop.Composite.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Core.Extensions;

namespace NCop.Composite.Extensions
{
    internal static class ReflectionExtensions
    {
        internal static Type GetAsCastedOrSelf(this Type compositeType) {
            var attr = compositeType.GetCustomAttribute<CompositeAttribute>();

            return attr.As.IsNotNull() ? attr.As : compositeType;
        }
    }
}
