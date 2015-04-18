using System;

namespace NCop.Aspects.Engine
{
    public interface IEventFunctionBinding<TInstance, TArg1, TArg2, TResult>
    {
        void AddHandler(ref TInstance instance, Func<TArg1, TArg2, TResult> handler);
        void RemoveHandler(ref TInstance instance, Func<TArg1, TArg2, TResult> handler);
        TResult InvokeHandler(ref TInstance instance, Func<TArg1, TArg2, TResult> handler, IEventFunctionArgs<TArg1, TArg2, TResult> args);
        void ProceedAddHandler(ref TInstance instance, Func<TArg1, TArg2, TResult> handler, IEventFunctionArgs<TArg1, TArg2, TResult> args);
        void ProceedInvokeHandler(ref TInstance instance, Func<TArg1, TArg2, TResult> handler, IEventFunctionArgs<TArg1, TArg2, TResult> args);
        void ProceedRemoveHandler(ref TInstance instance, Func<TArg1, TArg2, TResult> handler, IEventFunctionArgs<TArg1, TArg2, TResult> args);
    }
}
