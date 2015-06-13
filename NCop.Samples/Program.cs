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
        public static FunctionEventInterceptionAspect EventInterception = null;
        public static FunctionEventInterceptionAspect2 EventInterception2 = null;
        public static FunctionEventInterceptionAspect3 EventInterception3 = null;

        static Aspects() {
            EventInterception = new FunctionEventInterceptionAspect();
            EventInterception2 = new FunctionEventInterceptionAspect2();
            EventInterception3 = new FunctionEventInterceptionAspect3();
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IDeveloper
    {
        //[EventInterceptionAspect(typeof(FunctionEventInterceptionAspect), AspectPriority = 1)]
        //[EventInterceptionAspect(typeof(FunctionEventInterceptionAspect), AspectPriority = 2)]
        event Func<string> Ev;

        //[EventInterceptionAspect(typeof(ActionEventInterceptionAspect))]
        //event EventHandler<EventArgs> Ev2;

        ////[EventInterceptionAspect(typeof(ActionEventInterceptionAspect2))]
        //event Action Ev3;

        //[MethodInterceptionAspect(typeof(FunctionInterceptionAspectImpl))]
        string RaiseEvent();

        ////[MethodInterceptionAspect(typeof(ActionInterceptionAspectImpl))]
        //void RaiseEvent2();

        //string Code(string s);

        [PropertyInterceptionAspect(typeof(PropertyInterception))]
        [PropertyInterceptionAspect(typeof(PropertyInterception))]
        int MyProperty { get; set; }
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

    public class Developer : IDeveloper
    {
        private readonly IDeveloper developer = null;
        private readonly IEventBroker<Func<string>> eventBroker = null;
        //private readonly IEventBroker<Action<object, EventArgs>> eventBroker2 = null;

        public Developer() {
            developer = new CSharpDeveloperMixin();
            eventBroker = new EventBroker(developer, OnInvokeHanlder);
            //eventBroker2 = new EventBroker2(developer, OnIvokeHanlder);
        }

        public void OnInvokeHanlder(EventFunctionInterceptionArgsImpl<IDeveloper, string> args) {
            var @event = GetType().GetEvent("Ev");
            var eventArgs = new EventFunctionInterceptionArgsImpl<IDeveloper, string>(developer, @event, args.Handler, EventInterceptionAspectBinding.singleton, eventBroker);

            Aspects.EventInterception.OnInvokeHandler(eventArgs);
            args.ReturnValue = eventArgs.ReturnValue;
        }

        //private void OnIvokeHanlder(EventActionInterceptionArgsImpl<IDeveloper, object, EventArgs> args) {
        //    Aspects.EventActionInterception.OnInvokeHandler(args);
        //}

        public event Func<string> Ev {
            add {
                var @event = GetType().GetEvent("Ev");
                var args = new EventFunctionInterceptionArgsImpl<IDeveloper, string>(developer, @event, value, EventInterceptionAspectBinding.singleton, eventBroker);
                Aspects.EventInterception.OnAddHandler(args);
            }
            remove {
                var @event = GetType().GetEvent("Ev");
                var args = new EventFunctionInterceptionArgsImpl<IDeveloper, string>(developer, @event, value, EventInterceptionAspectBinding.singleton, eventBroker);
                Aspects.EventInterception.OnRemoveHandler(args);
            }
        }

        //public event EventHandler<EventArgs> Ev2 {
        //    add {
        //        var @event = GetType().GetEvent("Ev2");
        //        Action<object, EventArgs> action = value.Invoke;
        //        var args = new EventActionInterceptionArgsImpl<IDeveloper, object, EventArgs>(developer, @event, action, EventInterceptionAspectBinding2.singleton, eventBroker2);
        //        Aspects.EventInterception2.OnAddHandler(args);
        //    }
        //    remove {
        //        var @event = GetType().GetEvent("Ev2");
        //        Action<object, EventArgs> action = value.Invoke;
        //        var args = new EventActionInterceptionArgsImpl<IDeveloper, object, EventArgs>(developer, @event, action, EventInterceptionAspectBinding2.singleton, eventBroker2);
        //        Aspects.EventInterception2.OnRemoveHandler(args);
        //    }
        //}

        public int MyProperty { get; set; }

        public string RaiseEvent() {
            return developer.RaiseEvent();
        }

        //public void RaiseEvent2() {
        //    developer.RaiseEvent2();
        //}


        public string Code(string s) {
            throw new NotImplementedException();
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

        public void RemoveHandler(ref IDeveloper instance, Func<string> handler, IEventFunctionArgs<string> args) {
            args.EventBroker.RemoveHandler(handler);
        }
    }

    public sealed class EventBroker : AbstractFunctionEventBroker<IDeveloper, string>
    {
        private readonly Action<EventFunctionInterceptionArgsImpl<IDeveloper, string>> onInvokeHandler = null;

        public EventBroker(IDeveloper developer, Action<EventFunctionInterceptionArgsImpl<IDeveloper, string>> onInvokeHandler)
            : base(developer, onInvokeHandler) {
            this.onInvokeHandler = onInvokeHandler;
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
    }

    //public sealed class EventBroker2 : AbstractActionEventBroker<IDeveloper, object, EventArgs>
    //{
    //    private readonly Action<EventActionInterceptionArgsImpl<IDeveloper, object, EventArgs>> onInvokeHandler = null;

    //    public EventBroker2(IDeveloper developer, IEventActionBinding<IDeveloper, object, EventArgs> binding, Action<EventActionInterceptionArgsImpl<IDeveloper, object, EventArgs>> onInvokeHandler)
    //        : base(developer, binding) {
    //        this.onInvokeHandler = onInvokeHandler;
    //    }

    //    private void Intercept(object sender, EventArgs args) {
    //        OnEventFired(sender, args);
    //    }

    //    protected override void SubscribeImpl() {
    //        instance.Ev2 += Intercept;
    //    }

    //    protected override void UnsubscribeImpl() {
    //        instance.Ev2 -= Intercept;
    //    }

    //    public override void OnInvokeHandler(EventActionInterceptionArgsImpl<IDeveloper, object, EventArgs> args) {
    //        onInvokeHandler(args);
    //    }
    //}

    public class CSharpDeveloperMixin : IDeveloper
    {
        public event Func<string> Ev;
        public event Action Ev3;
        public event EventHandler<EventArgs> Ev2;

        public string RaiseEvent() {
            if (Ev != null) {
                return Ev();
            }

            return string.Empty;
        }

        public void RaiseEvent2() {
            if (Ev2 != null) {
                Ev2(this, EventArgs.Empty);
            }
        }

        public int MyProperty { get; set; }

        public string Code(string s) {
            return s;
        }
    }

    class Program
    {
        static void Main(string[] args) {
            var developer = new Developer();
            Func<string> action = () => "C# coding";
            developer.Ev += action;
            Console.WriteLine(developer.RaiseEvent());
            developer.Ev -= action;
            Console.WriteLine(developer.RaiseEvent());
            var container = new CompositeContainer();
            container.Configure();
            var d = container.Resolve<IDeveloper>();
            //Console.WriteLine(d.Code("Sagi"));
        }
    }
}