using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Tests.EventActionWithoutArgumentsAspectSubjects.Subjects
{
    public interface IEventActionWithoutArgumentsAspect
    {
        List<AspectJoinPoints> Values { get; set; }
        event Action InterceptionAspect;
        event Action MultipleInterceptionAspects;
        event Action MultipleIgnoredInterceptionAspects;
        void RaiseInterceptionAspect();
        void RaiseMultipleInterceptionAspect();
        void RaiseMultipleIgnoredInterceptionAspects();
    }

    public class Mixin : IEventActionWithoutArgumentsAspect
    {
        public event Action InterceptionAspect;
        public event Action MultipleInterceptionAspects;
        public event Action MultipleIgnoredInterceptionAspects;

        public Mixin() {
            Values = new List<AspectJoinPoints>();
        }

        public List<AspectJoinPoints> Values { get; set; }

        public void RaiseInterceptionAspect() {
            RaiseInterceptionAspect(InterceptionAspect);
        }

        public void RaiseMultipleInterceptionAspect() {
            RaiseInterceptionAspect(MultipleInterceptionAspects);
        }

        public void RaiseMultipleIgnoredInterceptionAspects() {
            RaiseInterceptionAspect(MultipleIgnoredInterceptionAspects);
        }

        public void RaiseInterceptionAspect(Action action) {
            if (action.IsNotNull()) {
                action();
            }
        }
    }

    [TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IEventActionWithoutArgumentsComposite : IEventActionWithoutArgumentsAspect
    {
        [EventInterceptionAspect(typeof(EventActionInterceptionAspectImpl))]
        new event Action InterceptionAspect;

        [EventInterceptionAspect(typeof(EventActionInterceptionAspectImpl), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(EventActionInterceptionAspectImpl), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(EventActionInterceptionAspectImpl), AspectPriority = 1)]
        new event Action MultipleInterceptionAspects;

        [EventInterceptionAspect(typeof(EventActionInterceptionAspectIgnoreFollowingfAspects), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(EventActionInterceptionAspectImpl), AspectPriority = 2)]
        [EventInterceptionAspect(typeof(EventActionInterceptionAspectImpl), AspectPriority = 3)]
        new event Action MultipleIgnoredInterceptionAspects;
    }

    public class EventActionInterceptionAspectImpl : EventActionInterceptionAspect
    {
        public override void OnAddHandler(EventActionInterceptionArgs args) {
            var instance = (IEventActionWithoutArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnAddEvent);
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventActionInterceptionArgs args) {
            var instance = (IEventActionWithoutArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnInvoke);
            args.ProceedInvokeHandler();
        }

        public override void OnRemoveHandler(EventActionInterceptionArgs args) {
            var instance = (IEventActionWithoutArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnRemoveEvent);
            args.ProceedRemoveHandler();
        }
    }

    public class EventActionInterceptionAspectIgnoreFollowingfAspects : EventActionInterceptionAspect
    {
        public override void OnAddHandler(EventActionInterceptionArgs args) {
            var instance = (IEventActionWithoutArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnAddEvent);
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventActionInterceptionArgs args) {
            var instance = (IEventActionWithoutArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnInvoke);
            args.InvokeHanlder();
        }

        public override void OnRemoveHandler(EventActionInterceptionArgs args) {
            var instance = (IEventActionWithoutArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnRemoveEvent);
            args.ProceedRemoveHandler();
        }
    }
}
