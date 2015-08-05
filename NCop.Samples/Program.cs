using System.ComponentModel;
using System.Net;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;

namespace NCop.Samples
{
    public class Aspects
    {
        public static FunctionEventInterceptionAspect EventInterception = null;
        public static FunctionEventInterceptionAspect2 EventInterception2 = null;
        public static FunctionEventInterceptionAspect3 EventInterception3 = null;
        public static ActionEventInterceptionAspect EventInterception4 = null;

        static Aspects() {
            EventInterception = new FunctionEventInterceptionAspect();
            EventInterception2 = new FunctionEventInterceptionAspect2();
            EventInterception3 = new FunctionEventInterceptionAspect3();
            EventInterception4 = new ActionEventInterceptionAspect();
        }
    }

    public interface IMusician
    {
        //string RaiseEvent();
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        [EventInterceptionAspect(typeof(FunctionEventInterceptionAspect), AspectPriority = 1)]
        event Func<string> Ev;

        [EventInterceptionAspect(typeof(ActionEventInterceptionAspect))]
        event EventHandler<EventArgs> Ev2;

        //[EventInterceptionAspect(typeof(FunctionEventInterceptionAspect4), AspectPriority = 1)]
        //event EventHandler<EventArgs> Ev2;

        //[MethodInterceptionAspect(typeof(FunctionInterceptionAspectImpl))]
        string RaiseEvent();

        //[MethodInterceptionAspect(typeof(FunctionInterceptionAspectImpl))]
        void RaiseEvent2();

        //string Code(string s);

        //[PropertyInterceptionAspect(typeof(PropertyInterception))]
        //[PropertyInterceptionAspect(typeof(PropertyInterception))]
        //int MyProperty { get; set; }
    }

    public class Developer : IDeveloper, IMusician
    {
        private readonly IMusician musician = null;
        private readonly IDeveloper developer = null;
        private readonly IEventBroker<Func<string>> eventBroker2 = null;
        public readonly IEventBroker<Action<object, EventArgs>> eventBroker = null;

        public Developer(IDeveloper developer) {
            this.developer = developer;
            eventBroker = new EventBroker(this.developer, InvokeEv2);
        }

        private string InvokeEv(IEventFunctionArgs<string> args) {
            var clonedArgs = new EventFunctionInterceptionArgsImpl<IDeveloper, string>(developer, args.Event, args.Handler, EventInterceptionAspectBinding2.singleton, args.EventBroker);

            Aspects.EventInterception.OnInvokeHandler(clonedArgs);

            return clonedArgs.ReturnValue;
        }

        private void InvokeEv2(IEventActionArgs<object, EventArgs> args) {
            var clonedArgs = new EventActionInterceptionArgsImpl<IDeveloper, object, EventArgs>(developer, args.Event, args.Handler, EventActionInterceptionAspectBinding3.singleton, args.EventBroker);

            Aspects.EventInterception4.OnInvokeHandler(clonedArgs);
        }

        public event Func<string> Ev {
            add {
                Func<string> @delegate = value.Invoke;
                var @event = developer.GetType().GetEvent("Ev");
                var args = new EventFunctionInterceptionArgsImpl<IDeveloper, string>(developer, @event, @delegate, EventInterceptionAspectBinding2.singleton, eventBroker2);
                Aspects.EventInterception.OnAddHandler(args);
            }
            remove {
                Func<string> @delegate = value.Invoke;
                var @event = developer.GetType().GetEvent("Ev");
                var args = new EventFunctionInterceptionArgsImpl<IDeveloper, string>(developer, @event, @delegate, EventInterceptionAspectBinding2.singleton, eventBroker2);
                Aspects.EventInterception.OnRemoveHandler(args);
            }
        }

        public event EventHandler<EventArgs> Ev2 {
            add {
                Action<object, EventArgs> stam = value.Invoke;
                var @event = developer.GetType().GetEvent("Ev");
                var args = new EventActionInterceptionArgsImpl<IDeveloper, object, EventArgs>(developer, @event, stam, EventActionInterceptionAspectBinding3.singleton, eventBroker);
                Aspects.EventInterception4.OnAddHandler(args);
            }
            remove {
                var @event = developer.GetType().GetEvent("Ev");
                Action<object, EventArgs> stam = value.Invoke;
                var args = new EventActionInterceptionArgsImpl<IDeveloper, object, EventArgs>(developer, @event, stam, EventActionInterceptionAspectBinding3.singleton, eventBroker);
                Aspects.EventInterception4.OnRemoveHandler(args);
            }
        }

        public void RaiseEvent2() {
            developer.RaiseEvent2();
        }

        public string RaiseEvent() {
            return developer.RaiseEvent();
        }
    }

    internal class Program
    {
        private static void Main(string[] args) {
            IDeveloper d;
            Func<string> func = () => "C# coding";
            Action<object, EventArgs> action = (obj, e) => Console.WriteLine("C# coding");
            var container = new CompositeContainer();
            var eh = new EventHandler<EventArgs>(action);

            //d = new Developer(new CSharpDeveloperMixin());
            container.Configure();
            d = container.Resolve<IDeveloper>();
            d.Ev += func;
            d.Ev2 += eh;
            Console.WriteLine(d.RaiseEvent());
            d.RaiseEvent2();
            d.Ev -= func;
            d.Ev2 -= eh;
            Console.WriteLine(d.RaiseEvent());
            d.RaiseEvent2();
        }
    }

    public class PropertyInterception : PropertyInterceptionAspect<int>
    {
        public override void OnGetValue(PropertyInterceptionArgs<int> args) {
            base.OnGetValue(args);
        }

        public override void OnSetValue(PropertyInterceptionArgs<int> args) {
            base.OnSetValue(args);
        }
    }

    public class FunctionInterceptionAspectImpl : FunctionInterceptionAspect<string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<string> args) {
            base.OnInvoke(args);
        }
    }

    public class FunctionEventInterceptionAspect4 : EventActionInterceptionAspect<object, EventArgs>
    {
        public override void OnAddHandler(EventActionInterceptionArgs<object, EventArgs> args) {
            Console.WriteLine("OnAddHandler");
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventActionInterceptionArgs<object, EventArgs> args) {
            Console.WriteLine("OnInvokeHandler");
            args.ProceedInvokeHandler();
        }

        public override void OnRemoveHandler(EventActionInterceptionArgs<object, EventArgs> args) {
            Console.WriteLine("OnRemoveHandler");
            args.ProceedRemoveHandler();
        }
    }

    public class ActionEventInterceptionAspect : EventActionInterceptionAspect<object, EventArgs>
    {
        public override void OnAddHandler(EventActionInterceptionArgs<object, EventArgs> args) {
            Console.WriteLine("OnAddHandler");
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventActionInterceptionArgs<object, EventArgs> args) {
            Console.WriteLine("OnInvokeHandler");
            base.OnInvokeHandler(args);
        }

        public override void OnRemoveHandler(EventActionInterceptionArgs<object, EventArgs> args) {
            Console.WriteLine("OnRemoveHandler");
            base.OnRemoveHandler(args);
        }
    }

    public class FunctionEventInterceptionAspect : EventFunctionInterceptionAspect<string>
    {
        public override void OnAddHandler(EventFunctionInterceptionArgs<string> args) {
            Console.WriteLine("OnAddHandler");
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventFunctionInterceptionArgs<string> args) {
            Console.WriteLine("OnInvokeHandler");
            args.ProceedInvokeHandler();
        }

        public override void OnRemoveHandler(EventFunctionInterceptionArgs<string> args) {
            Console.WriteLine("OnRemoveHandler");
            args.ProceedRemoveHandler();
        }
    }

    public class FunctionEventInterceptionAspect2 : EventFunctionInterceptionAspect<string>
    {
        public override void OnAddHandler(EventFunctionInterceptionArgs<string> args) {
            Console.WriteLine("OnAddHandler2");
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventFunctionInterceptionArgs<string> args) {
            Console.WriteLine("OnInvokeHandler2");
            args.ProceedInvokeHandler();
        }

        public override void OnRemoveHandler(EventFunctionInterceptionArgs<string> args) {
            Console.WriteLine("OnRemoveHandler2");
            args.ProceedRemoveHandler();
        }
    }

    public class FunctionEventInterceptionAspect3 : EventFunctionInterceptionAspect<string>
    {
        public override void OnAddHandler(EventFunctionInterceptionArgs<string> args) {
            Console.WriteLine("OnAddHandler3");
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventFunctionInterceptionArgs<string> args) {
            Console.WriteLine("OnInvokeHandler3");
            args.ProceedInvokeHandler();
        }

        public override void OnRemoveHandler(EventFunctionInterceptionArgs<string> args) {
            Console.WriteLine("OnRemoveHandler3");
            args.ProceedRemoveHandler();
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
            var clonedArgs = new EventFunctionInterceptionArgsImpl<IDeveloper, string>(instance, args.Event, args.Handler, EventInterceptionAspectBinding2.singleton, args.EventBroker);

            Aspects.EventInterception2.OnAddHandler(clonedArgs);
        }

        public string InvokeHandler(ref IDeveloper instance, Func<string> handler, IEventFunctionArgs<string> args) {
            var clonedArgs = new EventFunctionInterceptionArgsImpl<IDeveloper, string>(instance, args.Event, args.Handler, EventInterceptionAspectBinding2.singleton, args.EventBroker);

            Aspects.EventInterception2.OnInvokeHandler(clonedArgs);

            return clonedArgs.ReturnValue;
        }

        public void RemoveHandler(ref IDeveloper instance, Func<string> handler, IEventFunctionArgs<string> args) {
            var clonedArgs = new EventFunctionInterceptionArgsImpl<IDeveloper, string>(instance, args.Event, args.Handler, EventInterceptionAspectBinding2.singleton, args.EventBroker);

            Aspects.EventInterception2.OnRemoveHandler(clonedArgs);
        }
    }

    public sealed class EventInterceptionAspectBinding2 : IEventFunctionBinding<IDeveloper, string>
    {
        public static EventInterceptionAspectBinding2 singleton = null;

        static EventInterceptionAspectBinding2() {
            singleton = new EventInterceptionAspectBinding2();
        }

        private EventInterceptionAspectBinding2() {
        }

        public void AddHandler(ref IDeveloper instance, Func<string> handler, IEventFunctionArgs<string> args) {
            var clonedArgs = new EventFunctionInterceptionArgsImpl<IDeveloper, string>(instance, args.Event, args.Handler, EventInterceptionAspectBinding3.singleton, args.EventBroker);

            Aspects.EventInterception3.OnAddHandler(clonedArgs);
        }

        public string InvokeHandler(ref IDeveloper instance, Func<string> handler, IEventFunctionArgs<string> args) {
            var clonedArgs = new EventFunctionInterceptionArgsImpl<IDeveloper, string>(instance, args.Event, args.Handler, EventInterceptionAspectBinding3.singleton, args.EventBroker);

            Aspects.EventInterception3.OnInvokeHandler(clonedArgs);

            return clonedArgs.ReturnValue;
        }

        public void RemoveHandler(ref IDeveloper instance, Func<string> handler, IEventFunctionArgs<string> args) {
            var clonedArgs = new EventFunctionInterceptionArgsImpl<IDeveloper, string>(instance, args.Event, args.Handler, EventInterceptionAspectBinding3.singleton, args.EventBroker);

            Aspects.EventInterception3.OnRemoveHandler(clonedArgs);
        }
    }

    public sealed class EventActionInterceptionAspectBinding3 : IEventActionBinding<IDeveloper, object, EventArgs>
    {
        public static EventActionInterceptionAspectBinding3 singleton = null;

        static EventActionInterceptionAspectBinding3() {
            singleton = new EventActionInterceptionAspectBinding3();
        }

        private EventActionInterceptionAspectBinding3() {
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

    public sealed class EventInterceptionAspectBinding3 : IEventFunctionBinding<IDeveloper, string>
    {
        public static EventInterceptionAspectBinding3 singleton = null;

        static EventInterceptionAspectBinding3() {
            singleton = new EventInterceptionAspectBinding3();
        }

        private EventInterceptionAspectBinding3() {
        }

        public void AddHandler(ref IDeveloper instance, Func<string> handler, IEventFunctionArgs<string> args) {
            args.EventBroker.AddHandler(handler);
        }

        public string InvokeHandler(ref IDeveloper instance, Func<string> handler, IEventFunctionArgs<string> args) {
            return handler();
        }

        public string InvokeHandler(ref IDeveloper instance, Func<string, string, string> handler, IEventFunctionArgs<string, string, string> args) {
            return handler(args.Arg1, args.Arg2);
        }

        public void RemoveHandler(ref IDeveloper instance, Func<string> handler, IEventFunctionArgs<string> args) {
            args.EventBroker.RemoveHandler(handler);
        }
    }

    public sealed class EventBroker2 : AbstractFunctionEventBroker<IDeveloper, string>
    {
        public EventBroker2(IDeveloper instance, Func<IEventFunctionArgs<string>, string> handler)
            : base(instance, handler) {
        }

        private string Intercept() {
            return OnEventFired();
        }

        protected override void SubscribeImpl() {
            //instance.Ev2 += new EventHandler<EventArgs>(Intercept);
        }

        protected override void UnsubscribeImpl() {
            //instance.Ev2 -= Intercept;
        }
    }

    public sealed class EventBroker : AbstractActionEventBroker<IDeveloper, object, EventArgs>
    {
        public EventBroker(IDeveloper instance, Action<IEventActionArgs<object, EventArgs>> handler)
            : base(instance, handler) {
        }

        private void Intercept(object arg1, EventArgs arg2) {
            OnEventFired(arg1, arg2);
        }

        protected override void SubscribeImpl() {
            instance.Ev2 += Intercept;
        }

        protected override void UnsubscribeImpl() {
            instance.Ev2 -= Intercept;
        }
    }

    public class CSharpDeveloperMixin : IDeveloper
    {
        public event Func<string> Ev;
        public event EventHandler<EventArgs> Ev2;

        public string RaiseEvent() {
            if (Ev != null) {
                return Ev();
            }

            return "No Event";
        }

        public void RaiseEvent2() {
            if (Ev2 != null) {
                Ev2(this, EventArgs.Empty);
                return;
            }

            Console.WriteLine("No Event");
        }
    }
}