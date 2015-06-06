using NCop.Aspects.Framework;
using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class EventActionInterceptionArgsImpl<TInstance, TArg1, TArg2, TArg3> : EventActionInterceptionArgs<TArg1, TArg2, TArg3>, IEventActionArgs<TArg1, TArg2, TArg3>
    {
        private TInstance instance = default(TInstance);
        private readonly IEventActionBinding<TInstance, TArg1, TArg2, TArg3> actionBinding = null;

        public EventActionInterceptionArgsImpl() {
        }

        public EventActionInterceptionArgsImpl(TInstance instance, EventInfo @event, Action<TArg1, TArg2, TArg3> handler, IEventActionBinding<TInstance, TArg1, TArg2, TArg3> actionBinding, IEventBroker<Action<TArg1, TArg2, TArg3>> eventBroker = null, TArg1 arg1 = default(TArg1), TArg2 arg2 = default(TArg2), TArg3 arg3 = default(TArg3)) {
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
            Event = @event;
            Handler = handler;
            EventBroker = eventBroker;
            this.actionBinding = actionBinding;
            Instance = this.instance = instance;
        }

        public Action<TArg1, TArg2, TArg3> Handler { get; set; }

        public IEventBroker<Action<TArg1, TArg2, TArg3>> EventBroker { get; set; }

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
