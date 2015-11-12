using System;
using System.Collections.Generic;

namespace NCop.Core.Runtime
{
    public interface ITypeFactory
    {
        IEnumerable<Type> Types { get; }
    }
}
