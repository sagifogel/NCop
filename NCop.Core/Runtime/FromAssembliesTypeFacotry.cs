using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NCop.Core.Runtime
{
    public class FromAssembliesTypeFacotry : ITypeFactory
    {
        private readonly List<Type> types = null;

        public FromAssembliesTypeFacotry(IEnumerable<Assembly> assemblies = null) {
            assemblies = assemblies ?? AppDomain.CurrentDomain
                                                .GetAssemblies()
                                                .Where(assembly => !IgnoredAssemblies.Instance.Contains(assembly));
            
            types = assemblies.SelectMany(assembly => assembly.GetTypes())
                              .ToList();
        }

        public IEnumerable<Type> Types {
            get {
                return types;
            }
        }
    }
}
