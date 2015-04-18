using NCop.Aspects.Framework;
using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
	public class EventActionInterceptionArgsImpl<TInstance> : EventActionInterceptionArgs, IEventActionArgs 
    {
        private readonly Action handler = null;
        private TInstance instance = default(TInstance);
        private readonly IEventActionBinding<TInstance> actionBinding = null;

        public EventActionInterceptionArgsImpl(TInstance instance, EventInfo @event, Action handler, IEventActionBinding<TInstance> actionBinding) {
            Event = @event;
            this.handler = handler;
            this.actionBinding = actionBinding;
            Instance = this.instance = instance;
        }

        public override void ProceedAddHandler() {
            actionBinding.ProceedAddHandler(ref instance, handler, this);
        }

        public override void ProceedInvokeHandler() {
            actionBinding.ProceedInvokeHandler(ref instance, handler, this);
        }

        public override void ProceedRemoveHandler() {
            actionBinding.ProceedRemoveHandler(ref instance, handler, this);
        }

        public override void InvokeHanlder() {
            actionBinding.InvokeHandler(ref instance, handler, this);
        }

        public override void AddHandler() {
            actionBinding.AddHandler(ref instance, handler);
        }

        public override void RemoveHandler() {
            actionBinding.RemoveHandler(ref instance, handler);
        }
    }
}
