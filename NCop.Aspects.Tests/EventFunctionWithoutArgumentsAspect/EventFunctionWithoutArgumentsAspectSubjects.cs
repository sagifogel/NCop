using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Tests.EventFunctionWithoutArgumentsAspectSubjects.Subjects
{
    public interface IEventFunctionWithoutArgumentsAspect
    {
        List<AspectJoinPoints> Values { get; set; }
        event Func<List<AspectJoinPoints>> InterceptionAspect;
        event Func<List<AspectJoinPoints>> MultipleInterceptionAspects;
        event Func<List<AspectJoinPoints>> MultipleIgnoredInterceptionAspects;
        List<AspectJoinPoints> RaiseInterceptionAspect();
        List<AspectJoinPoints> RaiseMultipleInterceptionAspect();
        List<AspectJoinPoints> RaiseMultipleIgnoredInterceptionAspects();
    }

    public class Mixin : IEventFunctionWithoutArgumentsAspect
    {
        public event Func<List<AspectJoinPoints>> InterceptionAspect;
        public event Func<List<AspectJoinPoints>> MultipleInterceptionAspects;
        public event Func<List<AspectJoinPoints>> MultipleIgnoredInterceptionAspects;

        public Mixin() {
            Values = new List<AspectJoinPoints>();
        }

        public List<AspectJoinPoints> Values { get; set; }

        public List<AspectJoinPoints> RaiseInterceptionAspect() {
            return RaiseInterceptionAspect(InterceptionAspect);
        }

        public List<AspectJoinPoints> RaiseMultipleInterceptionAspect() {
            return RaiseInterceptionAspect(MultipleInterceptionAspects);
        }

        public List<AspectJoinPoints> RaiseMultipleIgnoredInterceptionAspects() {
            return RaiseInterceptionAspect(MultipleIgnoredInterceptionAspects);
        }

        public List<AspectJoinPoints> RaiseInterceptionAspect(Func<List<AspectJoinPoints>> func) {
            if (func.IsNotNull()) {
                return func();
            }

            return new List<AspectJoinPoints>();
        }
    }

    [TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IEventFunctionWithoutArgumentsComposite : IEventFunctionWithoutArgumentsAspect
    {
        [EventInterceptionAspect(typeof(EventFunctionInterceptionAspect))]
        new event Func<List<AspectJoinPoints>> InterceptionAspect;

        [EventInterceptionAspect(typeof(EventFunctionInterceptionAspect), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(EventFunctionInterceptionAspect), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(EventFunctionInterceptionAspect), AspectPriority = 1)]
        new event Func<List<AspectJoinPoints>> MultipleInterceptionAspects;

        [EventInterceptionAspect(typeof(EventFunctionInterceptionAspectIgnoreFollowingfAspects), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(EventFunctionInterceptionAspect), AspectPriority = 2)]
        [EventInterceptionAspect(typeof(EventFunctionInterceptionAspect), AspectPriority = 3)]
        new event Func<List<AspectJoinPoints>> MultipleIgnoredInterceptionAspects;
    }

    public class EventFunctionInterceptionAspect : EventFunctionInterceptionAspect<List<AspectJoinPoints>>
    {
        public override void OnAddHandler(EventFunctionInterceptionArgs<List<AspectJoinPoints>> args) {
            var instance = (IEventFunctionWithoutArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnAddEvent);
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventFunctionInterceptionArgs<List<AspectJoinPoints>> args) {
            var instance = (IEventFunctionWithoutArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnInvoke);
            args.ReturnValue = instance.Values;
            args.ProceedInvokeHandler();
        }

        public override void OnRemoveHandler(EventFunctionInterceptionArgs<List<AspectJoinPoints>> args) {
            var instance = (IEventFunctionWithoutArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnRemoveEvent);
            args.ProceedRemoveHandler();
        }
    }

    public class EventFunctionInterceptionAspectIgnoreFollowingfAspects : EventFunctionInterceptionAspect<List<AspectJoinPoints>>
    {
        public override void OnAddHandler(EventFunctionInterceptionArgs<List<AspectJoinPoints>> args) {
            var instance = (IEventFunctionWithoutArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnAddEvent);
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventFunctionInterceptionArgs<List<AspectJoinPoints>> args) {
            var instance = (IEventFunctionWithoutArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnInvoke);
            args.InvokeHanlder();
        }

        public override void OnRemoveHandler(EventFunctionInterceptionArgs<List<AspectJoinPoints>> args) {
            var instance = (IEventFunctionWithoutArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnRemoveEvent);
            args.ProceedRemoveHandler();
        }
    }
}
