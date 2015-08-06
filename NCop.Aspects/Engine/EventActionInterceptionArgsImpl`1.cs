using NCop.Aspects.Framework;
using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class EventActionInterceptionArgsImpl<TInstance, TArg1> : EventActionInterceptionArgs<TArg1>, IEventActionArgs<TArg1>
    {
        private TInstance instance = default(TInstance);
        private readonly IEventActionBinding<TInstance, TArg1> actionBinding = null;

        public EventActionInterceptionArgsImpl() { }

        public EventActionInterceptionArgsImpl(TInstance instance, EventInfo @event, Action<TArg1> handler, IEventActionBinding<TInstance, TArg1> actionBinding, IEventBroker<Action<TArg1>> eventBroker = null, TArg1 arg1 = default(TArg1)) {
            Arg1 = arg1;
            Event = @event;
            Handler = handler;
            EventBroker = eventBroker;
            this.actionBinding = actionBinding;
            Instance = this.instance = instance;
        }

        public Action<TArg1> Handler { get; set; }

        public IEventBroker<Action<TArg1>> EventBroker { get; set; }

        public override void InvokeHanlder() {
            Handler.Invoke(Arg1);
        }

        public override void ProceedAddHandler() {
            actionBinding.AddHandler(ref instance, Handler, this);
        }

        public override void ProceedInvokeHandler() {
            actionBinding.InvokeHandler(ref instance, Handler, this);
        }

        public override void ProceedRemoveHandler() {
            actionBinding.RemoveHandler(ref instance, Handler, this);
        }
    }
}
