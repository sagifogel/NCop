using NCop.Aspects.Runtime;
using NCop.Core;
using NCop.Core.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NCop.Aspects.Runtime
{
    internal class MixinsWeaver : IWeaver
    {
        private IEnumerable<Assembly> _assemblies = null;

        internal MixinsWeaver(RuntimeSettings settings) {
            _assemblies = settings.Assemblies;
        }

        public void Weave() {
        }
    }
}
