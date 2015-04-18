using NCop.Aspects.Framework;
using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class EventActionInterceptionArgsImpl<TInstance, TArg1> : EventActionInterceptionArgs<TArg1>, IEventActionArgs<TArg1>
    {
        private readonly Action<TArg1> handler = null;
        private TInstance instance = default(TInstance);
        private readonly IEventActionBinding<TInstance, TArg1> actionBinding = null;

        public EventActionInterceptionArgsImpl(TInstance instance, EventInfo @event, Action<TArg1> handler, IEventActionBinding<TInstance, TArg1> actionBinding, TArg1 arg1) {
            Arg1 = arg1;
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
