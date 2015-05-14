using NCop.Aspects.Framework;
using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class EventFunctionInterceptionArgsImpl<TInstance, TArg1, TArg2, TResult> : EventFunctionInterceptionArgs<TArg1, TArg2, TResult>, IEventFunctionArgs<TArg1, TArg2, TResult>
    {
        private TInstance instance = default(TInstance);
        private readonly IEventFunctionBinding<TInstance, TArg1, TArg2, TResult> funcBinding = null;

        public EventFunctionInterceptionArgsImpl(TInstance instance, EventInfo @event, Func<TArg1, TArg2, TResult> handler, IEventFunctionBinding<TInstance, TArg1, TArg2, TResult> funcBinding, IEventBroker<Func<TArg1, TArg2, TResult>> eventBroker = null, TArg1 arg1 = default(TArg1), TArg2 arg2 = default(TArg2)) {
            Arg1 = arg1;
            Arg2 = arg2;
            Event = @event;
            Handler = handler;
            EventBroker = eventBroker;
            this.funcBinding = funcBinding;
            Instance = this.instance = instance;
        }

        public Func<TArg1, TArg2, TResult> Handler { get; set; }

        public IEventBroker<Func<TArg1, TArg2, TResult>> EventBroker { get; set; }

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