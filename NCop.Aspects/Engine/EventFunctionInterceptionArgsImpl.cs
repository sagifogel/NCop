using NCop.Aspects.Framework;
using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class EventFunctionInterceptionArgsImpl<TInstance, TResult> : EventFunctionInterceptionArgs<TResult>, IEventFunctionArgs<TResult>
    {
        private TInstance instance = default(TInstance);
        private readonly IEventFunctionBinding<TInstance, TResult> funcBinding = null;

        public EventFunctionInterceptionArgsImpl() { }

        public EventFunctionInterceptionArgsImpl(TInstance instance, EventInfo @event, Func<TResult> handler, IEventFunctionBinding<TInstance, TResult> funcBinding, IEventBroker<Func<TResult>> eventBroker = null) {
            Event = @event;
            Handler = handler;
            EventBroker = eventBroker;
            this.funcBinding = funcBinding;
            Instance = this.instance = instance;
        }

        public Func<TResult> Handler { get; set; }

        public IEventBroker<Func<TResult>> EventBroker { get; set; }

        public override void InvokeHanlder() {
            ReturnValue = Handler.Invoke();
        }

        public override void ProceedAddHandler() {
            funcBinding.AddHandler(ref instance, Handler, this);
        }

        public override void ProceedInvokeHandler() {
            ReturnValue = funcBinding.InvokeHandler(ref instance, Handler, this);
        }

        public override void ProceedRemoveHandler() {
            funcBinding.RemoveHandler(ref instance, Handler, this);
        }
    }
}