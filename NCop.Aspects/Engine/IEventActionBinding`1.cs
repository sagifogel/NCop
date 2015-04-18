using System;

namespace NCop.Aspects.Engine
{
    public interface IEventActionBinding<TInstance, TArg1>
    {
        void AddHandler(ref TInstance instance, Action<TArg1> handler);
        void RemoveHandler(ref TInstance instance, Action<TArg1> handler);
        void InvokeHandler(ref TInstance instance, Action<TArg1> handler, IEventActionArgs<TArg1> args);
        void ProceedAddHandler(ref TInstance instance, Action<TArg1> handler, IEventActionArgs<TArg1> args);
        void ProceedInvokeHandler(ref TInstance instance, Action<TArg1> handler, IEventActionArgs<TArg1> args);
        void ProceedRemoveHandler(ref TInstance instance, Action<TArg1> handler, IEventActionArgs<TArg1> args);
    }
}
