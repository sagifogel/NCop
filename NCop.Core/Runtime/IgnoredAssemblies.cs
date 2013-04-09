using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using CSharpBinder = Microsoft.CSharp.RuntimeBinder;
using NCop.Core.Extensions;
using System.Collections;

namespace NCop.Core.Runtime
{
    public sealed class IgnoredAssemblies : IEnumerable<Assembly>
    {
        private ISet<Assembly> _assemblies = null;
        private static Lazy<IgnoredAssemblies> _ignoredAssemblies = new Lazy<IgnoredAssemblies>(() => new IgnoredAssemblies());
        private string _objectPublicKeyToken = typeof(object).GetAssemblyPublicKeyToken();
        private string _binderPublicKeyToken = typeof(CSharpBinder.Binder).GetAssemblyPublicKeyToken();

        private IgnoredAssemblies() {
            _assemblies = AppDomain.CurrentDomain
                                        .GetAssemblies()
                                        .Where(assembly => {
                                            return assembly.IsNCopAssembly() ||
                                                   assembly.HasSamePublicKeyToken(_objectPublicKeyToken) ||
                                                   assembly.HasSamePublicKeyToken(_binderPublicKeyToken);
                                        })
                                        .ToSet();
        }

        public static IgnoredAssemblies Instance {
            get {
                return _ignoredAssemblies.Value;
            }
        }

        public IEnumerator<Assembly> GetEnumerator() {
            return _assemblies.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public bool Contains(Assembly assembly) {
            return _assemblies.Contains(assembly);
        }
    }
}
