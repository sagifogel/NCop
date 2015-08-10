using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Tests.EventActionWith4ArgumentsAspect.Subjects
{
    public interface IEventActionWith4ArgumentsAspect
    {
        List<AspectJoinPoints> Values { get; set; }
        event Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> InterceptionAspect;
        event Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> MultipleInterceptionAspects;
        event Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> MultipleIgnoredInterceptionAspects;
        void RaiseInterceptionAspect(List<AspectJoinPoints> arg1, List<AspectJoinPoints> arg2, List<AspectJoinPoints> arg3, List<AspectJoinPoints> arg4);
        void RaiseMultipleInterceptionAspect(List<AspectJoinPoints> arg1, List<AspectJoinPoints> arg2, List<AspectJoinPoints> arg3, List<AspectJoinPoints> arg4);
        void RaiseMultipleIgnoredInterceptionAspects(List<AspectJoinPoints> arg1, List<AspectJoinPoints> arg2, List<AspectJoinPoints> arg3, List<AspectJoinPoints> arg4);
    }

    public class Mixin : IEventActionWith4ArgumentsAspect
    {
        public event Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> InterceptionAspect;
        public event Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> MultipleInterceptionAspects;
        public event Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> MultipleIgnoredInterceptionAspects;

        public Mixin() {
            Values = new List<AspectJoinPoints>();
        }

        public List<AspectJoinPoints> Values { get; set; }

        public void RaiseInterceptionAspect(List<AspectJoinPoints> arg1, List<AspectJoinPoints> arg2, List<AspectJoinPoints> arg3, List<AspectJoinPoints> arg4) {
            RaiseInterceptionAspect(InterceptionAspect, arg1, arg2, arg3, arg4);
        }

        public void RaiseMultipleInterceptionAspect(List<AspectJoinPoints> arg1, List<AspectJoinPoints> arg2, List<AspectJoinPoints> arg3, List<AspectJoinPoints> arg4) {
            RaiseInterceptionAspect(MultipleInterceptionAspects, arg1, arg2, arg3, arg4);
        }

        public void RaiseMultipleIgnoredInterceptionAspects(List<AspectJoinPoints> arg1, List<AspectJoinPoints> arg2, List<AspectJoinPoints> arg3, List<AspectJoinPoints> arg4) {
            RaiseInterceptionAspect(MultipleIgnoredInterceptionAspects, arg1, arg2, arg3, arg4);
        }

        public void RaiseInterceptionAspect(Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> action, List<AspectJoinPoints> arg1, List<AspectJoinPoints> arg2, List<AspectJoinPoints> arg3, List<AspectJoinPoints> arg4) {
            if (action.IsNotNull()) {
                action(arg1, arg2, arg3, arg4);
            }
        }
    }

    [TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IEventActionWith4ArgumentsComposite : IEventActionWith4ArgumentsAspect
    {
        [EventInterceptionAspect(typeof(EventActionInterceptionAspect))]
        new event Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> InterceptionAspect;

        [EventInterceptionAspect(typeof(EventActionInterceptionAspect), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(EventActionInterceptionAspect), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(EventActionInterceptionAspect), AspectPriority = 1)]
        new event Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> MultipleInterceptionAspects;

        [EventInterceptionAspect(typeof(EventActionInterceptionAspectIgnoreFollowingfAspects), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(EventActionInterceptionAspect), AspectPriority = 2)]
        [EventInterceptionAspect(typeof(EventActionInterceptionAspect), AspectPriority = 3)]
        new event Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> MultipleIgnoredInterceptionAspects;
    }

    public class EventActionInterceptionAspect : EventActionInterceptionAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnAddHandler(EventActionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            var instance = (IEventActionWith4ArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnAddEvent);
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventActionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            var instance = (IEventActionWith4ArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnInvoke);
            args.Arg1.Add(AspectJoinPoints.OnInvoke);
            args.Arg2.Add(AspectJoinPoints.OnInvoke);
            args.Arg3.Add(AspectJoinPoints.OnInvoke);
            args.Arg4.Add(AspectJoinPoints.OnInvoke);
            args.ProceedInvokeHandler();
        }

        public override void OnRemoveHandler(EventActionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            var instance = (IEventActionWith4ArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnRemoveEvent);
            args.ProceedRemoveHandler();
        }
    }

    public class EventActionInterceptionAspectIgnoreFollowingfAspects : EventActionInterceptionAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnAddHandler(EventActionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            var instance = (IEventActionWith4ArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnAddEvent);
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventActionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            var instance = (IEventActionWith4ArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnInvoke);
            args.Arg1.Add(AspectJoinPoints.OnInvoke);
            args.Arg2.Add(AspectJoinPoints.OnInvoke);
            args.Arg3.Add(AspectJoinPoints.OnInvoke);
            args.Arg4.Add(AspectJoinPoints.OnInvoke);
            args.InvokeHanlder();
        }

        public override void OnRemoveHandler(EventActionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            var instance = (IEventActionWith4ArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnRemoveEvent);
            args.ProceedRemoveHandler();
        }
    }
}
