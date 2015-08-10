using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Tests.EventActionWith1ArgumentAspect.Subjects
{
    public interface IEventActionWith1ArgumentAspect
    {
        List<AspectJoinPoints> Values { get; set; }
        event Action<List<AspectJoinPoints>> InterceptionAspect;
        event Action<List<AspectJoinPoints>> MultipleInterceptionAspects;
        event Action<List<AspectJoinPoints>> MultipleIgnoredInterceptionAspects;
        void RaiseInterceptionAspect(List<AspectJoinPoints> args);
        void RaiseMultipleInterceptionAspect(List<AspectJoinPoints> args);
        void RaiseMultipleIgnoredInterceptionAspects(List<AspectJoinPoints> args);
    }

    public class Mixin : IEventActionWith1ArgumentAspect
    {
        public event Action<List<AspectJoinPoints>> InterceptionAspect;
        public event Action<List<AspectJoinPoints>> MultipleInterceptionAspects;
        public event Action<List<AspectJoinPoints>> MultipleIgnoredInterceptionAspects;

        public Mixin() {
            Values = new List<AspectJoinPoints>();
        }

        public List<AspectJoinPoints> Values { get; set; }

        public void RaiseInterceptionAspect(List<AspectJoinPoints> args) {
            RaiseInterceptionAspect(InterceptionAspect, args);
        }

        public void RaiseMultipleInterceptionAspect(List<AspectJoinPoints> args) {
            RaiseInterceptionAspect(MultipleInterceptionAspects, args);
        }

        public void RaiseMultipleIgnoredInterceptionAspects(List<AspectJoinPoints> args) {
            RaiseInterceptionAspect(MultipleIgnoredInterceptionAspects, args);
        }

        public void RaiseInterceptionAspect(Action<List<AspectJoinPoints>> action, List<AspectJoinPoints> args) {
            if (action.IsNotNull()) {
                action(args);
            }
        }
    }

    [TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IEventActionWith1ArgumentComposite : IEventActionWith1ArgumentAspect
    {
        [EventInterceptionAspect(typeof(EventActionInterceptionAspect))]
        new event Action<List<AspectJoinPoints>> InterceptionAspect;

        [EventInterceptionAspect(typeof(EventActionInterceptionAspect), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(EventActionInterceptionAspect), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(EventActionInterceptionAspect), AspectPriority = 1)]
        new event Action<List<AspectJoinPoints>> MultipleInterceptionAspects;

        [EventInterceptionAspect(typeof(EventActionInterceptionAspectIgnoreFollowingfAspects), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(EventActionInterceptionAspect), AspectPriority = 2)]
        [EventInterceptionAspect(typeof(EventActionInterceptionAspect), AspectPriority = 3)]
        new event Action<List<AspectJoinPoints>> MultipleIgnoredInterceptionAspects;
    }

    public class EventActionInterceptionAspect : EventActionInterceptionAspect<List<AspectJoinPoints>>
    {
        public override void OnAddHandler(EventActionInterceptionArgs<List<AspectJoinPoints>> args) {
            var instance = (IEventActionWith1ArgumentAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnAddEvent);
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventActionInterceptionArgs<List<AspectJoinPoints>> args) {
            var instance = (IEventActionWith1ArgumentAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnInvoke);
            args.Arg1.Add(AspectJoinPoints.OnInvoke);
            args.ProceedInvokeHandler();
        }

        public override void OnRemoveHandler(EventActionInterceptionArgs<List<AspectJoinPoints>> args) {
            var instance = (IEventActionWith1ArgumentAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnRemoveEvent);
            args.ProceedRemoveHandler();
        }
    }

    public class EventActionInterceptionAspectIgnoreFollowingfAspects : EventActionInterceptionAspect<List<AspectJoinPoints>>
    {
        public override void OnAddHandler(EventActionInterceptionArgs<List<AspectJoinPoints>> args) {
            var instance = (IEventActionWith1ArgumentAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnAddEvent);
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventActionInterceptionArgs<List<AspectJoinPoints>> args) {
            var instance = (IEventActionWith1ArgumentAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnInvoke);
            args.Arg1.Add(AspectJoinPoints.OnInvoke);
            args.InvokeHanlder();
        }

        public override void OnRemoveHandler(EventActionInterceptionArgs<List<AspectJoinPoints>> args) {
            var instance = (IEventActionWith1ArgumentAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnRemoveEvent);
            args.ProceedRemoveHandler();
        }
    }
}
