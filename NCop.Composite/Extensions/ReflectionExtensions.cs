using NCop.Mixins.Engine;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NCop.Core.Extensions;

namespace NCop.Mixins.Extensions
{
    public static class ReflectionExtensions
    {
        public static IEnumerable<CompositeMetadata> GetCompositesMetadata(this Assembly assembly) {
            return assembly.GetTypes()
                           .Where(type => type.IsNCopDefined<CompositeAttribute>())
                           .Select(type => new CompositeMetadata(type));
        }
    }
}
