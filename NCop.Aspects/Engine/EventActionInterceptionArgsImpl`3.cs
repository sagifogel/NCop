using NCop.Aspects.Framework;
using System;
using System.Reflection;

namespace NCop.Aspects.Engine
{
    public class EventActionInterceptionArgsImpl<TInstance, TArg1, TArg2, TArg3> : EventActionInterceptionArgs<TArg1, TArg2, TArg3>, IEventActionArgs<TArg1, TArg2, TArg3>
    {
        private TInstance instance = default(TInstance);
        private readonly Action<TArg1, TArg2, TArg3> handler = null;
        private readonly IEventActionBinding<TInstance, TArg1, TArg2, TArg3> actionBinding = null;

        public EventActionInterceptionArgsImpl(TInstance instance, EventInfo @event, Action<TArg1, TArg2, TArg3> handler, IEventActionBinding<TInstance, TArg1, TArg2, TArg3> actionBinding, TArg1 arg1, TArg2 arg2, TArg3 arg3) {
            Arg1 = arg1;
            Arg2 = arg2;
            Arg3 = arg3;
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
