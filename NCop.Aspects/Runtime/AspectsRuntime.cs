using NCop.Aspects.Engine;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NCop.Aspects.Runtime
{
    public class AspectsRuntime
    {
        private IWeaver _weaver = null;
        private IEnumerable<Assembly> _assemblies = null;

        public AspectsRuntime(RuntimeSetting setting) {
            Contract.Assert(setting != null, "RuntimeSettings can not be null.");

            _weaver = setting.Weaver ?? new MixinsWeaver();
            _assemblies = setting.Assemblies ?? GetAllAssemblies();
        }

        private IEnumerable<Assembly> GetAllAssemblies() {
            return AppDomain.CurrentDomain
                            .GetAssemblies()
                            .Where(a => !RuntimeSetting.IgnoredAssemblies.Contains(a));
        }
    }
}
