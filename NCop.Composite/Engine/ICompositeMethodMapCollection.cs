using System.Collections.Generic;

namespace NCop.Composite.Engine
{
    public interface ICompositeMethodMapCollection
    {
        IEnumerable<ICompositeMethodMap> Methods { get; }
    }
}
