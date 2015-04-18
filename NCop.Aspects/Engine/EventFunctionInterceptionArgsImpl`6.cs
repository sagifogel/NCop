using NCop.Aspects.Framework;
using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class EventFunctionInterceptionArgsImpl<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> : EventFunctionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>, IEventFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>
    {
        private TInstance instance = default(TInstance);
        private readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> handler = null;
        private readonly IEventFunctionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> funcBinding = null;

        public EventFunctionInterceptionArgsImpl(TInstance instance, EventInfo @event, Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> handler, IEventFunctionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> funcBinding, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6) {
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
            Arg4 = arg4;
            Arg5 = arg5;
            Arg6 = arg6;
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
