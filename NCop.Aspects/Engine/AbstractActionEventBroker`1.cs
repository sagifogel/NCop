using NCop.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractActionEventBroker<TInstance, TArg1> : IEventBroker<Action<TArg1>>
    {
        protected TInstance instance = default(TInstance);
        private readonly LinkedList<Action<TArg1>> linkedHandlers = null;
        protected readonly Action<IEventActionArgs<TArg1>> argsHandler = null;

        protected AbstractActionEventBroker(TInstance instance, Action<IEventActionArgs<TArg1>> argsHandler) {
            this.instance = instance;
            this.argsHandler = argsHandler;
            linkedHandlers = new LinkedList<Action<TArg1>>();
        }

        public void AddHandler(Action<TArg1> handler) {
            var isFirst = linkedHandlers.First.IsNull();

            if (isFirst) {
                SubscribeImpl();
            }

            linkedHandlers.AddLast(handler);
        }

        protected void OnEventFired(TArg1 arg1) {
            var args = new EventActionInterceptionArgsImpl<TInstance, TArg1>();

            args.Arg1 = arg1;
            args.EventBroker = this;

            for (var i = linkedHandlers.First; i != null; i = i.Next) {
                args.Handler = i.Value;
                argsHandler(args);
            }
        }

        public void RemoveHandler(Action<TArg1> handler) {
            linkedHandlers.Remove(handler);

            if (linkedHandlers.First.IsNull()) {
                UnsubscribeImpl();
            }
        }

        protected abstract void SubscribeImpl();

        protected abstract void UnsubscribeImpl();
    }
}
