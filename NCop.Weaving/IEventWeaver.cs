using System;

namespace NCop.Weaving
{
    public interface IEventWeaver : IWeaver
    {
        Type EventType { get; }
        string EventName { get; }
        IMethodWeaver GetAddMethod();
        IMethodWeaver GetRaiseMethod();
        IMethodWeaver GetRemoveMethod();
    }
}
