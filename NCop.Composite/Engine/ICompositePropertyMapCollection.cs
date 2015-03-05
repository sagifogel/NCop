using System.Collections.Generic;

namespace NCop.Composite.Engine
{
    public interface ICompositePropertyMapCollection
    {
        IEnumerable<ICompositePropertyMap> Properties { get; }
    }
}