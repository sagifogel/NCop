using NCop.Aspects.Runtime;
using NCop.Core.Runtime;

using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NCop.Composite.Runtime
{
    internal class MixinsWeaver : IWeaver
    {
        private IEnumerable<Assembly> _assemblies = null;

        internal MixinsWeaver(AspectsRuntimeSettings settings) {
            _assemblies = settings.Assemblies;
        }

        public void Weave() {
        }
    }
}
