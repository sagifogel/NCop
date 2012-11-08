using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NET_4_0

namespace NCop.Core
{
    public interface IReadOnlyCollection<T> : IEnumerable<T>
    {
        int Count { get; }
    }
}

#endif
