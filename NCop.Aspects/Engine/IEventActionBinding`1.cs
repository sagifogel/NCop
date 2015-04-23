using System;

namespace NCop.Aspects.Engine
{
    public interface IEventActionBinding<TInstance, TArg1>
    {
        void AddHandler(ref TInstance instance, Action<TArg1> handler, IEventActionArgs<TArg1> args);
        void InvokeHandler(ref TInstance instance, Action<TArg1> handler, IEventActionArgs<TArg1> args);
        void RemoveHandler(ref TInstance instance, Action<TArg1> handler, IEventActionArgs<TArg1> args);
    }
}
