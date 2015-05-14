using NCop.Aspects.Framework;
using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class EventFunctionInterceptionArgsImpl<TInstance, TArg1, TArg2, TArg3, TArg4, TResult> : EventFunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TResult>, IEventFunctionArgs<TArg1, TArg2, TArg3, TArg4, TResult>
    {
        private TInstance instance = default(TInstance);
        private readonly IEventFunctionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TResult> funcBinding = null;

        public EventFunctionInterceptionArgsImpl(TInstance instance, EventInfo @event, Func<TArg1, TArg2, TArg3, TArg4, TResult> handler, IEventFunctionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TResult> funcBinding, IEventBroker<Func<TArg1, TArg2, TArg3, TArg4, TResult>> eventBroker = null, TArg1 arg1 = default(TArg1), TArg2 arg2 = default(TArg2), TArg3 arg3 = default(TArg3), TArg4 arg4 = default(TArg4)) {
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
            Arg4 = arg4;
            Event = @event;
            Handler = handler;
            EventBroker = eventBroker;
            this.funcBinding = funcBinding;
            Instance = this.instance = instance;
        }

        public Func<TArg1, TArg2, TArg3, TArg4, TResult> Handler { get; set; }

        public IEventBroker<Func<TArg1, TArg2, TArg3, TArg4, TResult>> EventBroker { get; set; }

        public override void ProceedAddHandler() {
            funcBinding.AddHandler(ref instance, Handler,this);
        }

        public override void ProceedInvokeHandler() {
            funcBinding.InvokeHandler(ref instance, Handler,this);
        }

        public override void ProceedRemoveHandler() {
            funcBinding.RemoveHandler(ref instance, Handler,this);
        }
    }
}

