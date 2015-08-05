using NCop.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractFunctionEventBroker<TInstance, TArg1, TArg2, TResult> : IEventBroker<Func<TArg1, TArg2, TResult>>
    {
        protected TInstance instance = default(TInstance);
        private readonly LinkedList<Func<TArg1, TArg2, TResult>> linkedHandlers = null;
        private readonly Func<IEventFunctionArgs<TArg1, TArg2, TResult>, TResult> argsHandler = null;

        protected AbstractFunctionEventBroker(TInstance instance, Func<IEventFunctionArgs<TArg1, TArg2, TResult>, TResult> argsHandler) {
            this.instance = instance;
            this.argsHandler = argsHandler;
            linkedHandlers = new LinkedList<Func<TArg1, TArg2, TResult>>();
        }

        public void AddHandler(Func<TArg1, TArg2, TResult> handler) {
            var isFirst = linkedHandlers.First.IsNull();

            if (isFirst) {
                SubscribeImpl();
            }

            linkedHandlers.AddLast(handler);
        }

        protected TResult OnEventFired(TArg1 arg1, TArg2 arg2) {
            var args = new EventFunctionInterceptionArgsImpl<TInstance, TArg1, TArg2, TResult>();

            args.Arg1 = arg1;
            args.Arg2 = arg2;
            args.EventBroker = this;

            for (var i = linkedHandlers.First; i != null; i = i.Next) {
                args.Handler = i.Value;
                args.ReturnValue = argsHandler(args);
            }

            return args.ReturnValue;
        }

        public void RemoveHandler(Func<TArg1, TArg2, TResult> handler) {
            linkedHandlers.Remove(handler);

            if (linkedHandlers.First.IsNull()) {
                UnsubscribeImpl();
            }
        }

        protected abstract void SubscribeImpl();

        protected abstract void UnsubscribeImpl();
    }
}
