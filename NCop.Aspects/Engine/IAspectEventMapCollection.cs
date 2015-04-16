using System.Collections.Generic;

namespace NCop.Aspects.Engine
{
    public interface IAspectEventMapCollection
    {
        IEnumerable<IAspectEventMap> Events { get; }
    }
}
