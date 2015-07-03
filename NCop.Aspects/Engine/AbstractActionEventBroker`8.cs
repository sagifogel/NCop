using NCop.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractActionEventBroker<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> : IEventBroker<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>>
    {
        protected readonly EventInfo @event = null;
        protected TInstance instance = default(TInstance);
        private readonly LinkedList<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>> linkedHandlers = null;
        private readonly IEventActionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> binding = null;

        protected AbstractActionEventBroker(TInstance instance, EventInfo @event, IEventActionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8> binding) {
            this.@event = @event;
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
            var args = new EventActionInterceptionArgsImpl<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>();

            args.Arg1 = arg1;
            args.Arg2 = arg2;
            args.Arg3 = arg3;
            args.Arg4 = arg4;
            args.Arg5 = arg5;
            args.Arg6 = arg6;
            args.Arg7 = arg7;
            args.Arg8 = arg8;
            args.Event = @event;
            args.EventBroker = this;

            for (var i = linkedHandlers.First; i != null; i = i.Next) {
                args.Handler = i.Value;
                binding.InvokeHandler(ref instance, args.Handler, args);
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
    }
}
