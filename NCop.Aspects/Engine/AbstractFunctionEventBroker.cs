using NCop.Core.Extensions;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractFunctionEventBroker<TInstance, TResult> : IEventBroker<Func<TResult>>
    {
        protected readonly TInstance instance = default(TInstance);
        private readonly LinkedList<Func<TResult>> linkedHandlers = null;
        protected readonly Func<IEventFunctionArgs<TResult>, TResult> handler = null;

        protected AbstractFunctionEventBroker(TInstance instance, Func<IEventFunctionArgs<TResult>, TResult> handler) {
            this.handler = handler;
            this.instance = instance;
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

            args.EventBroker = this;

            for (var i = linkedHandlers.First; i != null; i = i.Next) {
                args.Handler = i.Value;
                args.ReturnValue = handler(args);
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
    }
}
