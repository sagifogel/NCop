using NCop.Aspects.Framework;
using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class EventFunctionInterceptionArgsImpl<TInstance, TResult> : EventFunctionInterceptionArgs<TResult>, IEventFunctionArgs<TResult>
    {
        private readonly Func<TResult> handler = null;
        private TInstance instance = default(TInstance);
        private readonly IEventFunctionBinding<TInstance, TResult> funcBinding = null;

        public EventFunctionInterceptionArgsImpl(TInstance instance, EventInfo @event, Func<TResult> handler, IEventFunctionBinding<TInstance, TResult> funcBinding) {
            Event = @event;
            this.handler = handler;
            this.funcBinding = funcBinding;
            Instance = this.instance = instance;
        }

        public override void ProceedAddHandler() {
            funcBinding.ProceedAddHandler(ref instance, handler, this);
        }

        public override void ProceedInvokeHandler() {
            funcBinding.ProceedInvokeHandler(ref instance, handler, this);
        }

        public override void ProceedRemoveHandler() {
            funcBinding.ProceedRemoveHandler(ref instance, handler, this);
        }

        public override TResult InvokeHanlder() {
            return funcBinding.InvokeHandler(ref instance, handler, this);
        }

        public override void AddHandler() {
            funcBinding.AddHandler(ref instance, handler);
        }

        public override void RemoveHandler() {
            funcBinding.RemoveHandler(ref instance, handler);
        }
    }
}