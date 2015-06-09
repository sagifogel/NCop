using NCop.Aspects.Framework;
using NCop.Core.Extensions;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractFunctionEventBroker<TInstance, TResult> : IEventBroker<Func<TResult>>
    {
        protected readonly TInstance instance = default(TInstance);
        private readonly LinkedList<Func<TResult>> linkedHandlers = null;
        private readonly Action<EventFunctionInterceptionArgsImpl<TInstance, TResult>> onInvokeHandler = null;

        protected AbstractFunctionEventBroker(TInstance instance, Action<EventFunctionInterceptionArgsImpl<TInstance, TResult>> onInvokeHandler) {
            this.instance = instance;
            this.onInvokeHandler = onInvokeHandler;
            linkedHandlers = new LinkedList<Func<TResult>>();
        }

        public void AddHandler(Func<TResult> handler) {
            var isFirst = linkedHandlers.First.IsNull();

            if (isFirst) {
                SubscribeImpl();
            }

            linkedHandlers.AddLast(handler);
        }

        protected TResult OnEventFired() {
            var args = new EventFunctionInterceptionArgsImpl<TInstance, TResult>();

            for (var i = linkedHandlers.First; i != null; i = i.Next) {
                args.Handler = i.Value;
                OnInvokeHandler(args);
            }

            return args.ReturnValue;
        }

        public void RemoveHandler(Func<TResult> handler) {
            linkedHandlers.Remove(handler);

            if (linkedHandlers.First.IsNull()) {
                UnsubscribeImpl();
            }
        }

        protected abstract void SubscribeImpl();

        protected abstract void UnsubscribeImpl();

        protected void OnInvokeHandler(EventFunctionInterceptionArgsImpl<TInstance, TResult> args) {
            onInvokeHandler(args);
        }
    }
}
