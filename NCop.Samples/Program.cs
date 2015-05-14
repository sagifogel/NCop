using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;

namespace NCop.Samples
{
    public class Aspects
    {
        public static ActionEventInterceptionAspect EventInterception2 = null;
        public static FunctionEventInterceptionAspect EventInterception = null;

        static Aspects() {
            EventInterception2 = new ActionEventInterceptionAspect();
            EventInterception = new FunctionEventInterceptionAspect();
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        //[EventInterceptionAspect(typeof(FunctionEventInterceptionAspect))]
        event Func<int, int, string> Ev;

        event EventHandler<EventArgs> Ev2;

        string RaiseEvent();
        void RaiseEvent2();
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

    public class ActionEventInterceptionAspect : EventActionInterceptionAspect<object, EventArgs>
    {
        public override void OnAddHandler(EventActionInterceptionArgs<object, EventArgs> args) {
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventActionInterceptionArgs<object, EventArgs> args) {
            args.Arg2 = new AssemblyLoadEventArgs(this.GetType().Assembly);
            args.ProceedInvokeHandler();
        }

        public override void OnRemoveHandler(EventActionInterceptionArgs<object, EventArgs> args) {
            args.ProceedRemoveHandler();
        }
    }

    //public class Developer : IDeveloper
    //{
    //    private readonly IDeveloper developer = null;
    //    private readonly IEventBroker<Func<string>> eventBroker = null;
    //    private readonly IEventBroker<Action<object, EventArgs>> eventBroker2 = null;

    //    public Developer() {
    //        developer = new CSharpDeveloperMixin();
    //        eventBroker = new EventBroker(developer, EventInterceptionAspectBinding.singleton);
    //        eventBroker2 = new EventBroker2(developer, EventInterceptionAspectBinding2.singleton);
    //    }

    //    public event Func<string> Ev {
    //        add {
    //            var @event = GetType().GetEvent("Ev");
    //            var args = new EventFunctionInterceptionArgsImpl<IDeveloper, string>(developer, @event, value, EventInterceptionAspectBinding.singleton, eventBroker);
    //            Aspects.EventInterception.OnAddHandler(args);
    //        }
    //        remove {
    //            var @event = GetType().GetEvent("Ev");
    //            var args = new EventFunctionInterceptionArgsImpl<IDeveloper, string>(developer, @event, value, EventInterceptionAspectBinding.singleton, eventBroker);
    //            Aspects.EventInterception.OnRemoveHandler(args);
    //        }
    //    }

    //    public event EventHandler<EventArgs> Ev2 {
    //        add {
    //            var @event = GetType().GetEvent("Ev2");
    //            Action<object, EventArgs> action = value.Invoke;
    //            var args = new EventActionInterceptionArgsImpl<IDeveloper, object, EventArgs>(developer, @event, action, EventInterceptionAspectBinding2.singleton, eventBroker2);
    //            Aspects.EventInterception2.OnAddHandler(args);
    //        }
    //        remove {
    //            var @event = GetType().GetEvent("Ev2");
    //            Action<object, EventArgs> action = value.Invoke;
    //            var args = new EventActionInterceptionArgsImpl<IDeveloper, object, EventArgs>(developer, @event, action, EventInterceptionAspectBinding2.singleton, eventBroker2);
    //            Aspects.EventInterception2.OnRemoveHandler(args);
    //        }
    //    }

    //    public string RaiseEvent() {
    //        return developer.RaiseEvent();
    //    }

    //    public void RaiseEvent2() {
    //        developer.RaiseEvent2();
    //    }
    //}

    public sealed class EventInterceptionAspectBinding2 : IEventActionBinding<IDeveloper, object, EventArgs>
    {
        public static EventInterceptionAspectBinding2 singleton = null;

        static EventInterceptionAspectBinding2() {
            singleton = new EventInterceptionAspectBinding2();
        }

        private EventInterceptionAspectBinding2() {
        }

        public void AddHandler(ref IDeveloper instance, Action<object, EventArgs> handler, IEventActionArgs<object, EventArgs> args) {
            args.EventBroker.AddHandler(handler);
        }

        public void InvokeHandler(ref IDeveloper instance, Action<object, EventArgs> handler, IEventActionArgs<object, EventArgs> args) {
            handler(args.Arg1, args.Arg2);
        }

        public void RemoveHandler(ref IDeveloper instance, Action<object, EventArgs> handler, IEventActionArgs<object, EventArgs> args) {
            args.EventBroker.RemoveHandler(handler);
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

            if (linkedHandlers.First.IsNotNull()) {
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
            //instance.Ev += Intercept;
        }

        protected override void UnsubscribeImpl() {
            //instance.Ev -= Intercept;
        }

        public override void OnInvokeHandler(EventFunctionInterceptionArgs<string> args) {
            Aspects.EventInterception.OnInvokeHandler(args);
        }
    }

    public sealed class EventBroker2 : AbstractActionEventBroker<IDeveloper, object, EventArgs>
    {
        public EventBroker2(IDeveloper developer, IEventActionBinding<IDeveloper, object, EventArgs> binding)
            : base(developer, binding) {
        }

        private void Intercept(object sender, EventArgs args) {
            OnEventFired(sender, args);
        }

        protected override void SubscribeImpl() {
            instance.Ev2 += Intercept;
        }

        protected override void UnsubscribeImpl() {
            instance.Ev2 -= Intercept;
        }

        public override void OnInvokeHandler(EventActionInterceptionArgs<object, EventArgs> args) {
            Aspects.EventInterception2.OnInvokeHandler(args);
        }
    }

    public class CSharpDeveloperMixin : IDeveloper
    {
        public event Func<int, int, string> Ev;
        public event EventHandler<EventArgs> Ev2;

        public string RaiseEvent() {
            if (Ev != null) {
                return Ev(1, 1);
            }

            return string.Empty;
        }

        public void RaiseEvent2() {
            if (Ev2 != null) {
                Ev2(this, EventArgs.Empty);
            }
        }
    }

    class Program
    {
        static void Main(string[] args) {
            var container = new CompositeContainer();
            container.Configure();
            var d = container.Resolve<IDeveloper>();

            //d.RaiseEvent();
            //var developer = new Developer();
            //EventHandler<EventArgs> action = (sender, args2) => Console.WriteLine("C# coding");
            //developer.Ev2 += action;
            //developer.RaiseEvent2();
            //developer.Ev2 -= action;
            //developer.RaiseEvent2();
            //Console.WriteLine(developer.RaiseEvent());
        }
    }
}