using System;
using System.Collections.Generic;

namespace NCop.Weaving
{
    public interface IEventWeaver : IWeaver, IEnumerable<IMethodWeaver>
    {
        Type EventType { get; }
        string EventName { get; }
        IMethodWeaver GetAddMethod();
        IMethodWeaver GetRaiseMethod();
        IMethodWeaver GetRemoveMethod();
    }
}
