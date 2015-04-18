using NCop.Aspects.Framework;
using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class EventFunctionInterceptionArgsImpl<TInstance, TArg1, TResult> : EventFunctionInterceptionArgs<TArg1, TResult>, IEventFunctionArgs<TArg1, TResult>
    {
        private TInstance instance = default(TInstance);
        private readonly Func<TArg1, TResult> handler = null;
        private readonly IEventFunctionBinding<TInstance, TArg1, TResult> funcBinding = null;

        public EventFunctionInterceptionArgsImpl(TInstance instance, EventInfo @event, Func<TArg1, TResult> handler, IEventFunctionBinding<TInstance, TArg1, TResult> funcBinding, TArg1 arg1) {
            Arg1 = arg1;
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