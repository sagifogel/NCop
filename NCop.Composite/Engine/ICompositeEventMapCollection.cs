using System.Collections.Generic;

namespace NCop.Composite.Engine
{
    public interface ICompositeEventMapCollection
    {
        IEnumerable<ICompositeEventMap> Events { get; }
    }
}