using System;

namespace NCop.Aspects.Engine
{
    public interface IEventFunctionBinding<TInstance, TResult>
    {
        void AddHandler(ref TInstance instance, Func<TResult> handler, IEventFunctionArgs<TResult> args);
        void RemoveHandler(ref TInstance instance, Func<TResult> handler, IEventFunctionArgs<TResult> args);
        TResult InvokeHandler(ref TInstance instance, Func<TResult> handler, IEventFunctionArgs<TResult> args);
    }
}
