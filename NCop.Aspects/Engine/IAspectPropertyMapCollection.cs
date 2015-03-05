using System.Collections.Generic;

namespace NCop.Aspects.Engine
{
    public interface IAspectPropertyMapCollection
    {
        IEnumerable<IAspectPropertyMap> Properties { get; }
    }
}
