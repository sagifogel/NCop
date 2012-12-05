using NCop.Core;
using NCop.Core.Runtime;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

namespace NCop.Aspects.Runtime
{
    public class AspectsRuntime : AbstractRuntime
    {
        private IWeaver _weaver = null;
        private AspectsRuntimeSettings _settings = null;
        private IEnumerable<Assembly> _assemblies = null;

        public AspectsRuntime(AspectsRuntimeSettings settings) {
            Contract.Assert(settings != null, "Runtime Settings can not be null.");

            _settings = settings;
            settings.Assemblies = GetAssemblies();
            settings.AspectBuilderProvider = settings.AspectBuilderProvider;
        }

        private IEnumerable<Assembly> GetAssemblies() {
            return _settings.Assemblies ??
                   AppDomain.CurrentDomain
                            .GetAssemblies()
                            .Where(assembly => !AspectsRuntimeSettings.IgnoredAssemblies.Contains(assembly));
        }

        public override void Run() {
            _weaver.Weave();
        }
    }
}
