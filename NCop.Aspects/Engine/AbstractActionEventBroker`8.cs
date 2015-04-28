using NCop.Aspects.Framework;
using NCop.Core.Extensions;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractActionEventBroker<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> : IEventBroker<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>>
    {
        protected readonly TInstance instance = default(TInstance);
        private readonly LinkedList<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>> linkedHandlers = null;
        private readonly IEventActionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> binding = null;

        protected AbstractActionEventBroker(TInstance instance, IEventActionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> binding) {
            this.binding = binding;
            this.instance = instance;
            linkedHandlers = new LinkedList<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>>();
        }

        public void AddHandler(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> handler) {
            var isFirst = linkedHandlers.First.IsNull();

            if (isFirst) {
                SubscribeImpl();
            }

            linkedHandlers.AddLast(handler);
        }

        protected void OnEventFired(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7, TArg8 arg8) {
            var @event = instance.GetType().GetEvents()[0];
            var args = new EventActionInterceptionArgsImpl<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(instance, @event, null, binding, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, this);

            for (var i = linkedHandlers.First; i != null; i = i.Next) {
                args.Handler = i.Value;
                OnInvokeHandler(args);
            }
        }

        public void RemoveHandler(Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> handler) {
            linkedHandlers.Remove(handler);

            if (linkedHandlers.First.IsNull()) {
                UnsubscribeImpl();
            }
        }

        protected abstract void SubscribeImpl();

        protected abstract void UnsubscribeImpl();

        public abstract void OnInvokeHandler(EventActionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> args);
    }
}
