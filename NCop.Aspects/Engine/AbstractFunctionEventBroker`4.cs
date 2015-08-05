using NCop.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractFunctionEventBroker<TInstance, TArg1, TArg2, TArg3, TArg4, TResult> : IEventBroker<Func<TArg1, TArg2, TArg3, TArg4, TResult>>
    {
        protected TInstance instance = default(TInstance);
        private readonly LinkedList<Func<TArg1, TArg2, TArg3, TArg4, TResult>> linkedHandlers = null;
        private readonly Func<IEventFunctionArgs<TArg1, TArg2, TArg3, TArg4, TResult>, TResult> argsHanlder = null;

        protected AbstractFunctionEventBroker(TInstance instance, Func<IEventFunctionArgs<TArg1, TArg2, TArg3, TArg4, TResult>, TResult> argsHanlder) {
            this.instance = instance;
            this.argsHanlder = argsHanlder;
            linkedHandlers = new LinkedList<Func<TArg1, TArg2, TArg3, TArg4, TResult>>();
        }

        public void AddHandler(Func<TArg1, TArg2, TArg3, TArg4, TResult> handler) {
            var isFirst = linkedHandlers.First.IsNull();

            if (isFirst) {
                SubscribeImpl();
            }

            linkedHandlers.AddLast(handler);
        }

        protected TResult OnEventFired(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4) {
            var args = new EventFunctionInterceptionArgsImpl<TInstance, TArg1, TArg2, TArg3, TArg4, TResult>();

            args.Arg1 = arg1;
            args.Arg2 = arg2;
            args.Arg3 = arg3;
            args.Arg4 = arg4;
            args.EventBroker = this;

            for (var i = linkedHandlers.First; i != null; i = i.Next) {
                args.Handler = i.Value;
                args.ReturnValue = argsHanlder(args);
            }

            return args.ReturnValue;
        }

        public void RemoveHandler(Func<TArg1, TArg2, TArg3, TArg4, TResult> handler) {
            linkedHandlers.Remove(handler);

            if (linkedHandlers.First.IsNull()) {
                UnsubscribeImpl();
            }
        }

        protected abstract void SubscribeImpl();

        protected abstract void UnsubscribeImpl();
    }
}
