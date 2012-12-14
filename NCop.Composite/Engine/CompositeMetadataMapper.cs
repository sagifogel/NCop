using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NCop.Core.Extensions;

namespace NCop.Composite.Engine
{
    public class CompositeMetadataMapper
    {
        public IEnumerable<CompositeMetadata> Map(IEnumerable<Assembly> assemblies) {
            return assemblies.SelectMany(assembly => {
                return assembly.GetTypes()
                               .Where(type => type.IsNCopDefined<CompositeAttribute>())
                               .Select(type => new CompositeMetadata(type));
            });
        }
    }
}
