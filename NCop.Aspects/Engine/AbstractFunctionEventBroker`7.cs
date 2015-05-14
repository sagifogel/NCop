using NCop.Aspects.Framework;
using NCop.Core.Extensions;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractFunctionEventBroker<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> : IEventBroker<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>>
    {
        protected readonly TInstance instance = default(TInstance);
        private readonly LinkedList<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>> linkedHandlers = null;
        private readonly IEventFunctionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> binding = null;

        protected AbstractFunctionEventBroker(TInstance instance, IEventFunctionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> binding) {
            this.binding = binding;
            this.instance = instance;
            linkedHandlers = new LinkedList<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>>();
        }

        public void AddHandler(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> handler) {
            var isFirst = linkedHandlers.First.IsNull();

            if (isFirst) {
                SubscribeImpl();
            }

            linkedHandlers.AddLast(handler);
        }

        protected TResult OnEventFired(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7) {
            var @event = instance.GetType().GetEvents()[0];
            var args = new EventFunctionInterceptionArgsImpl<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(instance, @event, null, binding, this, arg1, arg2, arg3, arg4, arg5, arg6, arg7);

            for (var i = linkedHandlers.First; i != null; i = i.Next) {
                args.Handler = i.Value;
                OnInvokeHandler(args);
            }

            return args.ReturnValue;
        }

        public void RemoveHandler(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> handler) {
            linkedHandlers.Remove(handler);

            if (linkedHandlers.First.IsNull()) {
                UnsubscribeImpl();
            }
        }

        protected abstract void SubscribeImpl();

        protected abstract void UnsubscribeImpl();

        public abstract void OnInvokeHandler(EventFunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> args);
    }
}
