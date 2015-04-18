using System;

namespace NCop.Aspects.Engine
{
    public interface IEventActionBinding<TInstance, TArg1, TArg2, TArg3>
    {
        void AddHandler(ref TInstance instance, Action<TArg1, TArg2, TArg3> handlelr);
        void RemoveHandler(ref TInstance instance, Action<TArg1, TArg2, TArg3> handlelr);
        void InvokeHndler(ref TInstance instance, Action<TArg1, TArg2, TArg3> handler, IEventActionArgs<TArg1, TArg2, TArg3> args);
    }
}
