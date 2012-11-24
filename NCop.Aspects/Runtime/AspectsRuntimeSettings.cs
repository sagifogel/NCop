using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NCop.Core.Extensions;
using System.Text.RegularExpressions;
using CSharpBinder = Microsoft.CSharp.RuntimeBinder;
using NCop.Aspects.Engine;
using System.Configuration;

namespace NCop.Aspects.Runtime
{
    public class AspectsRuntimeSettings
    {
        static AspectsRuntimeSettings() {
            var ignoredAssembliedTokens = new[] {
                    typeof(object).Assembly.MatchPublicKeyToken(),
                    typeof(CSharpBinder.Binder).Assembly.MatchPublicKeyToken()
            };

            IgnoredAssemblies = AppDomain.CurrentDomain
                                         .GetAssemblies()
                                         .Where(assembly => {
                                             return assembly.IsNCopAssembly() ||
                                                    assembly.HasSamePublicKeyToken(ignoredAssembliedTokens[0]) ||
                                                    assembly.HasSamePublicKeyToken(ignoredAssembliedTokens[1]);
                                         })
                                         .ToSet();
        }

        public IWeaver Weaver { get; set; }

        public IEnumerable<Assembly> Assemblies { get; set; }

        public IAspectBuilderProvider AspectBuilderProvider { get; set; }

        public static ISet<Assembly> IgnoredAssemblies { get; private set; }
    }
}
