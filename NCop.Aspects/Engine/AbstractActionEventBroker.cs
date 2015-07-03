using NCop.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public abstract class AbstractActionEventBroker<TInstance> : IEventBroker<Action>
    {
        protected readonly EventInfo @event = null;
        protected TInstance instance = default(TInstance);
        private readonly LinkedList<Action> linkedHandlers = null;
        private readonly IEventActionBinding<TInstance> binding = null;

        protected AbstractActionEventBroker(TInstance instance, EventInfo @event, IEventActionBinding<TInstance> binding) {
            this.@event = @event;
            this.binding = binding;
            this.instance = instance;
            linkedHandlers = new LinkedList<Action>();
        }

        public void AddHandler(Action handler) {
            var isFirst = linkedHandlers.First.IsNull();

            if (isFirst) {
                SubscribeImpl();
            }

            linkedHandlers.AddLast(handler);
        }

        protected void OnEventFired() {
            var args = new EventActionInterceptionArgsImpl<TInstance>();

            args.Event = @event;
            args.EventBroker = this;

            for (var i = linkedHandlers.First; i != null; i = i.Next) {
                args.Handler = i.Value;
                binding.InvokeHandler(ref instance, args.Handler, args);
            }
        }

        public void RemoveHandler(Action handler) {
            linkedHandlers.Remove(handler);

            if (linkedHandlers.First.IsNull()) {
                UnsubscribeImpl();
            }
        }

        protected abstract void SubscribeImpl();

        protected abstract void UnsubscribeImpl();
    }
}
