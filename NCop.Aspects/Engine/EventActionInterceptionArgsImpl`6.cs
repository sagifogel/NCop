using NCop.Aspects.Framework;
using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class EventActionInterceptionArgsImpl<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> : EventActionInterceptionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, IEventActionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
    {
        private TInstance instance = default(TInstance);
        private readonly Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> handler = null;
        private readonly IEventActionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> actionBinding = null;

        public EventActionInterceptionArgsImpl(TInstance instance, EventInfo @event, Action<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> handler, IEventActionBinding<TInstance, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> actionBinding, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6) {
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
            Arg4 = arg4;
            Arg5 = arg5;
            Arg6 = arg6;
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
