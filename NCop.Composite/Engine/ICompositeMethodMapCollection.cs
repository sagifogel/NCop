using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Composite.Engine
{
    public interface ICompositeMethodMapCollection
    {
        IEnumerable<ICompositeMethodMap> Methods { get; }
    }
}
