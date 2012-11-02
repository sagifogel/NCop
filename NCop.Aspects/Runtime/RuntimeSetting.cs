using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NCop.Core.Extensions;
using System.Text.RegularExpressions;
using CSharpBinder = Microsoft.CSharp.RuntimeBinder;

namespace NCop.Aspects.Runtime
{
    public class RuntimeSetting
    {
        public IWeaver Weaver { get; set; }
        public IEnumerable<Assembly> Assemblies { get; set; }
        private readonly static Regex _publicKeyTokenValue = new Regex(@"PublicKeyToken=(?<PublicKeyTokenValue>[A-Fa-f0-9]{16})");

        static RuntimeSetting() {
            
            var ignoredAssembliedTokens = new [] {
                    MatchPublicKeyToken(typeof(Object).Assembly.FullName),
                    MatchPublicKeyToken(typeof(CSharpBinder.Binder).Assembly.FullName)
            };

            IgnoredAssemblies = AppDomain.CurrentDomain
                                         .GetAssemblies()
                                         .Where(a => {
                                             string name = a.GetName().FullName;

                                             return HasSamePublicKeyToken(name, ignoredAssembliedTokens[0]) ||
                                                    HasSamePublicKeyToken(name, ignoredAssembliedTokens[1]);
                                         })
                                         .ToSet();

        }

        private static string MatchPublicKeyToken(string assemblyFullName) {
            return _publicKeyTokenValue.Match(assemblyFullName).Groups["PublicKeyTokenValue"].Value;
        }

        private static bool HasSamePublicKeyToken(string assemblyFullName, string token) {
            return MatchPublicKeyToken(assemblyFullName).Equals(token);
        }

        public static ISet<Assembly> IgnoredAssemblies { get; private set; }
    }
}
