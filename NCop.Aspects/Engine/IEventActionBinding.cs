using System;

namespace NCop.Aspects.Engine
{
    public interface IEventActionBinding<TInstance>
    {
        void AddHandler(ref TInstance instance, Action handlelr);
        void RemoveHandler(ref TInstance instance, Action handlelr);
        void InvokeHndler(ref TInstance instance, Action handler, IEventActionArgs args);
    }
}
