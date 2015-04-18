using System;

namespace NCop.Aspects.Engine
{
    public interface IEventActionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
    {
        void AddHandler(ref TInstance instance, Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> handler);
        void RemoveHandler(ref TInstance instance, Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> handler);
        void InvokeHandler(ref TInstance instance, Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> handler, IEventActionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> args);
        void ProceedAddHandler(ref TInstance instance, Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> handler, IEventActionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> args);
        void ProceedInvokeHandler(ref TInstance instance, Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> handler, IEventActionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> args);
        void ProceedRemoveHandler(ref TInstance instance, Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> handler, IEventActionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> args);
    }
}
