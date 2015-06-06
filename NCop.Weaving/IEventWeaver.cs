using System;

namespace NCop.Weaving
{
    public interface IEventWeaver : IWeaver
    {
        Type EventType { get; }
        string EventName { get; }
        IMethodWeaver GetOnAddMethod();
        IMethodWeaver GetOnRemoveMethod();
    }
}
