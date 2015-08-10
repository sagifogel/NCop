﻿using NCop.Core.Extensions;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractFunctionEventBroker<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> : IEventBroker<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>>
    {
        protected TInstance instance = default(TInstance);
        private readonly LinkedList<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>> linkedHandlers = null;
        private readonly Func<IEventFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>, TResult> argsHandler = null;

        protected AbstractFunctionEventBroker(TInstance instance, Func<IEventFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>, TResult> argsHandler) {
            this.instance = instance;
            this.argsHandler = argsHandler;
            linkedHandlers = new LinkedList<Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>>();
        }

        public void AddHandler(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> handler) {
            var isFirst = linkedHandlers.First.IsNull();

            if (isFirst) {
                SubscribeImpl();
            }

            linkedHandlers.AddLast(handler);
        }

        protected TResult OnEventFired(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6) {
            var args = new EventFunctionInterceptionArgsImpl<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>();

            args.Arg1 = arg1;
            args.Arg2 = arg2;
            args.Arg3 = arg3;
            args.Arg4 = arg4;
            args.Arg5 = arg5;
            args.Arg6 = arg6;
            args.EventBroker = this;

            for (var i = linkedHandlers.First; i != null; i = i.Next) {
                args.Handler = i.Value;
                args.ReturnValue = argsHandler(args);
            }

            return args.ReturnValue;
        }

        public void RemoveHandler(Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> handler) {
            linkedHandlers.Remove(handler);

            if (linkedHandlers.First.IsNull()) {
                UnsubscribeImpl();
            }
        }

        protected abstract void SubscribeImpl();

        protected abstract void UnsubscribeImpl();
    }
}
