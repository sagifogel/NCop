using System;

namespace NCop.Aspects.Engine
{
    public interface IEventActionBinding<TInstance>
    {
        void AddHandler(ref TInstance instance, Action handler, IEventActionArgs args);
        void InvokeHandler(ref TInstance instance, Action handler, IEventActionArgs args);
        void RemoveHandler(ref TInstance instance, Action handler, IEventActionArgs args);
    }
}
