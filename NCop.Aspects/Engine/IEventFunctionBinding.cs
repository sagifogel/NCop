
using System;
namespace NCop.Aspects.Engine
{
    public interface IEventFunctionBinding<TInstance, TResult>
    {
        void AddHandler(ref TInstance instance, Func<TResult> handlelr);
        void RemoveHandler(ref TInstance instance, Func<TResult> handlelr);
        TResult InvokeHndler(ref TInstance instance, Func<TResult> handler, IEventFunctionArgs<TResult> args);
    }
}
