using System;

namespace NCop.Aspects.Engine
{
    public interface IEventActionBinding<TInstance, TArg1, TArg2>
    {
        void AddHandler(ref TInstance instance, Action<TArg1, TArg2> handler, IEventActionArgs<TArg1, TArg2> args);
        void InvokeHandler(ref TInstance instance, Action<TArg1, TArg2> handler, IEventActionArgs<TArg1, TArg2> args);
        void RemoveHandler(ref TInstance instance, Action<TArg1, TArg2> handler, IEventActionArgs<TArg1, TArg2> args);
    }
}
