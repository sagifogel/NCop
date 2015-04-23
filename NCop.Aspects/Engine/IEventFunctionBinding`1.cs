using System;

namespace NCop.Aspects.Engine
{
    public interface IEventFunctionBinding<TInstance, TArg1, TResult>
    {
        void AddHandler(ref TInstance instance, Func<TArg1, TResult> handler, IEventFunctionArgs<TArg1, TResult> args);
        void RemoveHandler(ref TInstance instance, Func<TArg1, TResult> handler, IEventFunctionArgs<TArg1, TResult> args);
        TResult InvokeHandler(ref TInstance instance, Func<TArg1, TResult> handler, IEventFunctionArgs<TArg1, TResult> args);
    }
}
