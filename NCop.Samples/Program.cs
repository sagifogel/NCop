using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;

namespace NCop.Samples
{
    public class Aspects
    {
        public static FunctionEventInterceptionAspect EventInterception = null;

        static Aspects() {
            EventInterception = new FunctionEventInterceptionAspect();
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        [EventInterceptionAspect(typeof(FunctionEventInterceptionAspect))]
        event Func<string> Ev;

        string RaiseEvent();
    }

    public class FunctionEventInterceptionAspect : EventFunctionInterceptionAspect<string>
    {
        public override void OnAddHandler(EventFunctionInterceptionArgs<string> args) {
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventFunctionInterceptionArgs<string> args) {
            args.ProceedInvokeHandler();
        }

        public override void OnRemoveHandler(EventFunctionInterceptionArgs<string> args) {
            args.ProceedRemoveHandler();
        }
    }

    public class Developer : IDeveloper
    {
        private readonly IDeveloper developer = null;
        private readonly IEventBroker<Func<string>> eventBroker = null;

        public Developer() {
            developer = new CSharpDeveloperMixin();
            eventBroker = new EventBroker(developer, EventInterceptionAspectBinding.singleton);
        }

        public event Func<string> Ev {
            add {
                var @event = GetType().GetEvents()[0];
                var args = new EventFunctionInterceptionArgsImpl<IDeveloper, string>(developer, @event, value, EventInterceptionAspectBinding.singleton, eventBroker);
                Aspects.EventInterception.OnAddHandler(args);
            }
            remove {
                var @event = GetType().GetEvents()[0];
                var args = new EventFunctionInterceptionArgsImpl<IDeveloper, string>(developer, @event, value, EventInterceptionAspectBinding.singleton, eventBroker);
                Aspects.EventInterception.OnRemoveHandler(args);
            }
        }

        public string RaiseEvent() {
            return developer.RaiseEvent();
        }
    }

    public sealed class EventInterceptionAspectBinding : IEventFunctionBinding<IDeveloper, string>
    {
        public static EventInterceptionAspectBinding singleton = null;

        static EventInterceptionAspectBinding() {
            singleton = new EventInterceptionAspectBinding();
        }

        private EventInterceptionAspectBinding() {
        }

        public void AddHandler(ref IDeveloper instance, Func<string> handler, IEventFunctionArgs<string> args) {
            args.EventBroker.AddHandler(handler);
        }

        public string InvokeHandler(ref IDeveloper instance, Func<string> handler, IEventFunctionArgs<string> args) {
            return handler();
        }

        public void RemoveHandler(ref IDeveloper instance, Func<string> handler, IEventFunctionArgs<string> args) {
            args.EventBroker.RemoveHandler(handler);
        }
    }

    public abstract class AbstractFunctionEventBroker<TInstance, TResult> : IEventBroker<Func<TResult>>
    {
        protected readonly TInstance instance = default(TInstance);
        private readonly LinkedList<Func<TResult>> linkedHandlers = null;
        private readonly IEventFunctionBinding<TInstance, TResult> binding = null;

        protected AbstractFunctionEventBroker(TInstance instance, IEventFunctionBinding<TInstance, TResult> binding) {
            this.binding = binding;
            this.instance = instance;
            linkedHandlers = new LinkedList<Func<TResult>>();
        }

        public void AddHandler(Func<TResult> handler) {
            var isFirst = linkedHandlers.First == null;

            if (isFirst) {
                SubscribeImpl();
            }

            linkedHandlers.AddLast(handler);
        }

        protected TResult OnEventFired() {
            var @event = instance.GetType().GetEvents()[0];
            var args = new EventFunctionInterceptionArgsImpl<TInstance, TResult>(instance, @event, null, binding, this);

            for (var i = linkedHandlers.First; i != null; i = i.Next) {
                args.Handler = i.Value;
                OnInvokeHandler(args);
            }

            return args.ReturnValue;
        }

        public void RemoveHandler(Func<TResult> handler) {
            linkedHandlers.Remove(handler);

            if (linkedHandlers.First == null) {
                UnsubscribeImpl();
            }
        }

        protected abstract void SubscribeImpl();

        protected abstract void UnsubscribeImpl();

        public abstract void OnInvokeHandler(EventFunctionInterceptionArgs<TResult> args);
    }

    public sealed class EventBroker : AbstractFunctionEventBroker<IDeveloper, string>
    {
        public EventBroker(IDeveloper developer, IEventFunctionBinding<IDeveloper, string> binding)
            : base(developer, binding) {
        }

        private string Intercept() {
            return OnEventFired();
        }

        protected override void SubscribeImpl() {
            instance.Ev += Intercept;
        }

        protected override void UnsubscribeImpl() {
            instance.Ev -= Intercept;
        }

        public override void OnInvokeHandler(EventFunctionInterceptionArgs<string> args) {
            Aspects.EventInterception.OnInvokeHandler(args);
        }
    }

    public class CSharpDeveloperMixin : IDeveloper
    {
        public event Func<string> Ev;

        public string RaiseEvent() {
            if (Ev != null) {
                return Ev();
            }

            return string.Empty;
        }
    }

    class Program
    {
        static void Main(string[] args) {
            var developer = new Developer();
            Func<string> func = () => "C# coding";
            developer.Ev += func;
            developer.Ev -= func;
            Console.WriteLine(developer.RaiseEvent());
        }
    }
}