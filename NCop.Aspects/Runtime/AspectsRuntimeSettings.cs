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
        private static readonly string NCopToken = "5f8f9ac08842d356";
        private static readonly Regex _publicKeyTokenValue = new Regex(@"PublicKeyToken=(?<PublicKeyTokenValue>[A-Fa-f0-9]{16})");

        static AspectsRuntimeSettings() {
            var ignoredAssembliedTokens = new[] {
                    MatchPublicKeyToken(typeof(object).Assembly.FullName),
                    MatchPublicKeyToken(typeof(CSharpBinder.Binder).Assembly.FullName)
            };

            IgnoredAssemblies = AppDomain.CurrentDomain
                                         .GetAssemblies()
                                         .Where(a => {
                                             string name = a.GetName().FullName;

                                             return IsCoreType(name) ||
                                                    HasSamePublicKeyToken(name, ignoredAssembliedTokens[0]) ||
                                                    HasSamePublicKeyToken(name, ignoredAssembliedTokens[1]);
                                         })
                                         .ToSet();
        }


        public IWeaver Weaver { get; set; }

        public IEnumerable<Assembly> Assemblies { get; set; }

        public IAspectBuilderProvider AspectBuilderProvider { get; set; }

        public static ISet<Assembly> IgnoredAssemblies { get; private set; }

        private static string MatchPublicKeyToken(string assemblyFullName) {
            return _publicKeyTokenValue.Match(assemblyFullName).Groups["PublicKeyTokenValue"].Value;
        }

        private static bool HasSamePublicKeyToken(string assemblyFullName, string token) {
            return MatchPublicKeyToken(assemblyFullName).Equals(token);
        }

        private static bool IsCoreType(string assemblyFullName) {
            return MatchPublicKeyToken(assemblyFullName).Equals(NCopToken);
        }
    }
}
