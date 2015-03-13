using System.Collections;
using System.Collections.Generic;

namespace NCop.Composite.Engine
{
    public class CompositePropertyMap : ICompositePropertyMap
    {
        private readonly IEnumerable<ICompositePropertyFragmentMap> propertyMaps = null;

        public CompositePropertyMap(IEnumerable<ICompositePropertyFragmentMap> propertyMaps) {
            this.propertyMaps = propertyMaps;
        }

        public IEnumerator<ICompositePropertyFragmentMap> GetEnumerator() {
            return propertyMaps.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
