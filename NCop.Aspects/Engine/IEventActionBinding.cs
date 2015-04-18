using System;

namespace NCop.Aspects.Engine
{
    public interface IEventActionBinding<TInstance>
    {
        void AddHandler(ref TInstance instance, Action handler);
        void RemoveHandler(ref TInstance instance, Action handler);
        void InvokeHandler(ref TInstance instance, Action handler, IEventActionArgs args);
        void ProceedAddHandler(ref TInstance instance, Action handler, IEventActionArgs args);
        void ProceedInvokeHandler(ref TInstance instance, Action handler, IEventActionArgs args);
        void ProceedRemoveHandler(ref TInstance instance, Action handler, IEventActionArgs args);
    }
}
