using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NCop.Core
{
    public interface IRuntime
    {
        void Run();
        IEnumerable<Assembly> Assemblies { get; }
        ISet<Assembly> IgnoredAssemblies { get; }
    }
}
