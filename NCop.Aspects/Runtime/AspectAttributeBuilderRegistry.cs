using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Aspects.Runtime
{
    public class AttributeAspectBuilderRegistry : AbstractBuilderRegistry
    {   
        private IEnumerable<Assembly> _assemblies = null;

        public AttributeAspectBuilderRegistry(IEnumerable<Assembly> assemblies) {
            _assemblies = assemblies;
        }
    }
}
