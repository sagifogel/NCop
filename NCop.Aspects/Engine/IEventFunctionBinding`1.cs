
using System;
namespace NCop.Aspects.Engine
{
    public interface IEventFunctionBinding<TInstance, TArg1, TResult>
    {
        void AddHandler(ref TInstance instance, Func<TArg1, TResult> handlelr);
        void RemoveHandler(ref TInstance instance, Func<TArg1, TResult> handlelr);
        TResult InvokeHndler(ref TInstance instance, Func<TArg1, TResult> handler, IEventFunctionArgs<TArg1, TResult> args);
    }
}
