using NCop.Aspects.Framework;
using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class EventActionInterceptionArgsImpl<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> : EventActionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, IEventActionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
    {
        private TInstance instance = default(TInstance);
        private readonly IEventActionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> actionBinding = null;

        public EventActionInterceptionArgsImpl(TInstance instance, EventInfo @event, Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> handler, IEventActionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> actionBinding, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, IEventBroker<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>> eventBroker = null) {
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
            Arg4 = arg4;
            Arg5 = arg5;
            Arg6 = arg6;
            Event = @event;
            Handler = handler;
            EventBroker = eventBroker;
            this.actionBinding = actionBinding;
            Instance = this.instance = instance;
        }
        public Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> Handler { get; set; }

        public IEventBroker<Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>> EventBroker { get; set; }

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
