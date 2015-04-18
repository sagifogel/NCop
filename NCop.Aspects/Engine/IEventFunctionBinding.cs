using System;

namespace NCop.Aspects.Engine
{
    public interface IEventFunctionBinding<TInstance, TResult>
    {
        void AddHandler(ref TInstance instance, Func<TResult> handler);
        void RemoveHandler(ref TInstance instance, Func<TResult> handler);
        TResult InvokeHandler(ref TInstance instance, Func<TResult> handler, IEventFunctionArgs<TResult> args);
        void ProceedAddHandler(ref TInstance instance, Func<TResult> handler, IEventFunctionArgs<TResult> args);
        void ProceedInvokeHandler(ref TInstance instance, Func<TResult> handler, IEventFunctionArgs<TResult> args);
        void ProceedRemoveHandler(ref TInstance instance, Func<TResult> handler, IEventFunctionArgs<TResult> args);
    }
}
