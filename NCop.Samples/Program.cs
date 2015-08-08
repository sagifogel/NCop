using System.Collections.Generic;
using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;

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
        [EventInterceptionAspect(typeof(FunctionEventInterceptionAspect), AspectPriority = 1)]
        event Func<List<string>, string> Ev;
        
        [EventInterceptionAspect(typeof(FunctionEventInterceptionAspect), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(FunctionEventInterceptionAspect), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(FunctionEventInterceptionAspect), AspectPriority = 1)]
        event Func<List<string>, string> Ev2;

        string RaiseEvent(List<string> list);
        string RaiseEvent2(List<string> list);
    }

    public class Developer : IDeveloper
    {
        private readonly IDeveloper developer = null;
        private readonly IEventBroker<Func<List<string>, string>> eventBroker = null;

        public Developer(IDeveloper developer) {
            this.developer = developer;
            eventBroker = new EventBroker(this.developer, InvokeEv);
        }

        private string InvokeEv(IEventFunctionArgs<List<string>, string> args) {
            var clonedArgs = new EventFunctionInterceptionArgsImpl<IDeveloper, List<string>, string>(developer, args.Event, args.Handler, EventInterceptionAspectBinding.singleton, args.EventBroker, args.Arg1);

            Aspects.EventInterception.OnInvokeHandler(clonedArgs);

            return clonedArgs.ReturnValue;
        }

        public event Func<List<string>, string> Ev2 {
            add {
                developer.Ev += value;
            }
            remove {
                developer.Ev -= value;
            }
        }

        public event Func<List<string>, string> Ev {
            add {
                Func<List<string>, string> @delegate = value.Invoke;
                var @event = developer.GetType().GetEvent("Ev");
                var args = new EventFunctionInterceptionArgsImpl<IDeveloper, List<string>, string>(developer, @event, @delegate, EventInterceptionAspectBinding.singleton, eventBroker);
                Aspects.EventInterception.OnAddHandler(args);
            }
            remove {
                Func<List<string>, string> @delegate = value.Invoke;
                var @event = developer.GetType().GetEvent("Ev");
                var args = new EventFunctionInterceptionArgsImpl<IDeveloper, List<string>, string>(developer, @event, @delegate, EventInterceptionAspectBinding.singleton, eventBroker);
                Aspects.EventInterception.OnRemoveHandler(args);
            }
        }

        public string RaiseEvent(List<string> list) {
            return developer.RaiseEvent(list);
        }


        public string RaiseEvent2(List<string> list) {
            throw new NotImplementedException();
        }
    }

    public class CSharpDeveloperMixin : IDeveloper
    {
        public event Func<List<string>, string> Ev;
        public event Func<List<string>, string> Ev2;

        public string RaiseEvent(List<string> list) {
            Console.WriteLine("Raising Ev");
            if (Ev != null) {
                return Ev(list);
            }

            return "No Event";
        }

        public string RaiseEvent2(List<string> list) {
            Console.WriteLine("Raising Ev2");

            if (Ev2 != null) {
                return Ev2(list);
            }

            return "No Event";
        }
    }

    internal class Program
    {
        private static void Main(string[] args) {
            IDeveloper d;
            Func<List<string>, string> func = l => "C# coding";
            var container = new CompositeContainer();

            var list = new List<string>();
            var list2 = new List<string>();
            container.Configure();
            //d = container.Resolve<IDeveloper>();
            d = new Developer(new CSharpDeveloperMixin());
            d.Ev += func;
            //d.Ev2 += func;
            Console.WriteLine(d.RaiseEvent(list));
            //Console.WriteLine(d.RaiseEvent2(list2));
            d.Ev -= func;
            //d.Ev2 -= func;
            Console.WriteLine(d.RaiseEvent(list));
            //Console.WriteLine(d.RaiseEvent2(list2));
        }
    }

    public class FunctionEventInterceptionAspect : EventFunctionInterceptionAspect<List<string>, string>
    {
        public override void OnAddHandler(EventFunctionInterceptionArgs<List<string>, string> args) {
            Console.WriteLine("OnAddHandler");
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventFunctionInterceptionArgs<List<string>, string> args) {
            Console.WriteLine("OnInvokeHandler");
            args.Arg1.Add("Sagi");
            args.ProceedInvokeHandler();
        }

        public override void OnRemoveHandler(EventFunctionInterceptionArgs<List<string>, string> args) {
            Console.WriteLine("OnRemoveHandler");
            args.ProceedRemoveHandler();
        }
    }

    public sealed class EventInterceptionAspectBinding2 : IEventFunctionBinding<IDeveloper, List<string>, string>
    {
        public static EventInterceptionAspectBinding2 singleton = null;

        static EventInterceptionAspectBinding2() {
            singleton = new EventInterceptionAspectBinding2();
        }

        private EventInterceptionAspectBinding2() {
        }

        public void AddHandler(ref IDeveloper instance, Func<List<string>, string> handler, IEventFunctionArgs<List<string>, string> args) {
            args.EventBroker.AddHandler(handler);
        }

        public string InvokeHandler(ref IDeveloper instance, Func<List<string>, string> handler, IEventFunctionArgs<List<string>, string> args) {
            return handler(args.Arg1);
        }

        public void RemoveHandler(ref IDeveloper instance, Func<List<string>, string> handler, IEventFunctionArgs<List<string>, string> args) {
            args.EventBroker.RemoveHandler(handler);
        }
    }

    public sealed class EventInterceptionAspectBinding : IEventFunctionBinding<IDeveloper, List<string>, string>
    {
        public static EventInterceptionAspectBinding singleton = null;

        static EventInterceptionAspectBinding() {
            singleton = new EventInterceptionAspectBinding();
        }

        private EventInterceptionAspectBinding() {
        }

        public void AddHandler(ref IDeveloper instance, Func<List<string>, string> handler, IEventFunctionArgs<List<string>, string> args) {
            var clonedArgs = new EventFunctionInterceptionArgsImpl<IDeveloper, List<string>, string>(instance, args.Event, args.Handler, EventInterceptionAspectBinding2.singleton, args.EventBroker, args.Arg1);

            Aspects.EventInterception.OnAddHandler(clonedArgs);
        }

        public string InvokeHandler(ref IDeveloper instance, Func<List<string>, string> handler, IEventFunctionArgs<List<string>, string> args) {
            var clonedArgs = new EventFunctionInterceptionArgsImpl<IDeveloper, List<string>, string>(instance, args.Event, args.Handler, EventInterceptionAspectBinding2.singleton, args.EventBroker, args.Arg1);

            Aspects.EventInterception.OnInvokeHandler(clonedArgs);

            return clonedArgs.ReturnValue;
        }

        public void RemoveHandler(ref IDeveloper instance, Func<List<string>, string> handler, IEventFunctionArgs<List<string>, string> args) {
            var clonedArgs = new EventFunctionInterceptionArgsImpl<IDeveloper, List<string>, string>(instance, args.Event, args.Handler, EventInterceptionAspectBinding2.singleton, args.EventBroker, args.Arg1);

            Aspects.EventInterception.OnRemoveHandler(clonedArgs);
        }
    }

    public sealed class EventBroker : AbstractFunctionEventBroker<IDeveloper, List<string>, string>
    {
        public EventBroker(IDeveloper instance, Func<IEventFunctionArgs<List<string>, string>, string> handler)
            : base(instance, handler) {
        }

        private string Intercept(List<string> list) {
            return OnEventFired(list);
        }

        protected override void SubscribeImpl() {
            instance.Ev += Intercept;
        }

        protected override void UnsubscribeImpl() {
            instance.Ev -= Intercept;
        }
    }
}