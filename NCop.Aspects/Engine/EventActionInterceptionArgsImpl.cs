using NCop.Aspects.Framework;
using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
	public class EventActionInterceptionArgsImpl<TInstance> : EventActionInterceptionArgs, IEventActionArgs 
    {
        private TInstance instance = default(TInstance);
        private readonly IEventActionBinding<TInstance> actionBinding = null;

        public EventActionInterceptionArgsImpl(TInstance instance, EventInfo @event, Action handler, IEventActionBinding<TInstance> actionBinding, IEventBroker<Action> eventBroker = null) {
            Event = @event;
            Handler = handler;
            EventBroker = eventBroker;
            this.actionBinding = actionBinding;
            Instance = this.instance = instance;
        }

        public Action Handler { get; set; }

        public IEventBroker<Action> EventBroker { get; set; }

        public override void ProceedAddHandler() {
            actionBinding.AddHandler(ref instance, Handler,this);
        }

        public override void ProceedInvokeHandler() {
            actionBinding.InvokeHandler(ref instance, Handler,this);
        }

        public override void ProceedRemoveHandler() {
            actionBinding.RemoveHandler(ref instance, Handler,this);
        }
    }
}
