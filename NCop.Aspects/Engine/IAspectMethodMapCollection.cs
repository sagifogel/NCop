using System.Collections.Generic;

namespace NCop.Aspects.Engine
{
    public interface IAspectMethodMapCollection
    {
        IEnumerable<IAspectMethodMap> Methods { get; }
    }
}
