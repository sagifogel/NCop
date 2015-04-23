using System;

namespace NCop.Aspects.Engine
{
    public interface IEventActionBinding<TInstance, TArg1, TArg2, TArg3>
    {
        void AddHandler(ref TInstance instance, Action<TArg1, TArg2, TArg3> handler, IEventActionArgs<TArg1, TArg2, TArg3> args);
        void InvokeHandler(ref TInstance instance, Action<TArg1, TArg2, TArg3> handler, IEventActionArgs<TArg1, TArg2, TArg3> args);
        void RemoveHandler(ref TInstance instance, Action<TArg1, TArg2, TArg3> handler, IEventActionArgs<TArg1, TArg2, TArg3> args);
    }
}
