using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCop.Core.Weaving
{
    public interface IMixinTypeWeaver : ITypeWeaver
    {
        Type Type { get; }
        Type Interface { get; }
        IEnumerable<IMethodWeaver> MethodWeavers { get; }
    }
}
