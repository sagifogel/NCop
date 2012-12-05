using NCop.Aspects.Runtime;
using NCop.Core.Runtime;
using NCop.Composite.Extensions;
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
            MapTypes();
        }

        private void MapTypes() {
            var composites = _assemblies.SelectMany(assembly => {
                return assembly.GetCompositesMetadata();
            });

            foreach (var item in composites) {
                
            }
        }
    }
}
