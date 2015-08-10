using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Tests.EventActionWith6ArgumentsAspect.Subjects
{
    public interface IEventActionWith6ArgumentsAspect
    {
        List<AspectJoinPoints> Values { get; set; }
        event Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> InterceptionAspect;
        event Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> MultipleInterceptionAspects;
        event Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> MultipleIgnoredInterceptionAspects;
        void RaiseInterceptionAspect(List<AspectJoinPoints> arg1, List<AspectJoinPoints> arg2, List<AspectJoinPoints> arg3, List<AspectJoinPoints> arg4, List<AspectJoinPoints> arg5, List<AspectJoinPoints> arg6);
        void RaiseMultipleInterceptionAspect(List<AspectJoinPoints> arg1, List<AspectJoinPoints> arg2, List<AspectJoinPoints> arg3, List<AspectJoinPoints> arg4, List<AspectJoinPoints> arg5, List<AspectJoinPoints> arg6);
        void RaiseMultipleIgnoredInterceptionAspects(List<AspectJoinPoints> arg1, List<AspectJoinPoints> arg2, List<AspectJoinPoints> arg3, List<AspectJoinPoints> arg4, List<AspectJoinPoints> arg5, List<AspectJoinPoints> arg6);
    }

    public class Mixin : IEventActionWith6ArgumentsAspect
    {
        public event Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> InterceptionAspect;
        public event Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> MultipleInterceptionAspects;
        public event Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> MultipleIgnoredInterceptionAspects;

        public Mixin() {
            Values = new List<AspectJoinPoints>();
        }

        public List<AspectJoinPoints> Values { get; set; }

        public void RaiseInterceptionAspect(List<AspectJoinPoints> arg1, List<AspectJoinPoints> arg2, List<AspectJoinPoints> arg3, List<AspectJoinPoints> arg4, List<AspectJoinPoints> arg5, List<AspectJoinPoints> arg6) {
            RaiseInterceptionAspect(InterceptionAspect, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public void RaiseMultipleInterceptionAspect(List<AspectJoinPoints> arg1, List<AspectJoinPoints> arg2, List<AspectJoinPoints> arg3, List<AspectJoinPoints> arg4, List<AspectJoinPoints> arg5, List<AspectJoinPoints> arg6) {
            RaiseInterceptionAspect(MultipleInterceptionAspects, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public void RaiseMultipleIgnoredInterceptionAspects(List<AspectJoinPoints> arg1, List<AspectJoinPoints> arg2, List<AspectJoinPoints> arg3, List<AspectJoinPoints> arg4, List<AspectJoinPoints> arg5, List<AspectJoinPoints> arg6) {
            RaiseInterceptionAspect(MultipleIgnoredInterceptionAspects, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public void RaiseInterceptionAspect(Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> action, List<AspectJoinPoints> arg1, List<AspectJoinPoints> arg2, List<AspectJoinPoints> arg3, List<AspectJoinPoints> arg4, List<AspectJoinPoints> arg5, List<AspectJoinPoints> arg6) {
            if (action.IsNotNull()) {
                action(arg1, arg2, arg3, arg4, arg5, arg6);
            }
        }
    }

    [TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IEventActionWith6ArgumentsComposite : IEventActionWith6ArgumentsAspect
    {
        [EventInterceptionAspect(typeof(EventActionInterceptionAspect))]
        new event Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> InterceptionAspect;

        [EventInterceptionAspect(typeof(EventActionInterceptionAspect), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(EventActionInterceptionAspect), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(EventActionInterceptionAspect), AspectPriority = 1)]
        new event Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> MultipleInterceptionAspects;

        [EventInterceptionAspect(typeof(EventActionInterceptionAspectIgnoreFollowingfAspects), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(EventActionInterceptionAspect), AspectPriority = 2)]
        [EventInterceptionAspect(typeof(EventActionInterceptionAspect), AspectPriority = 3)]
        new event Action<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> MultipleIgnoredInterceptionAspects;
    }

    public class EventActionInterceptionAspect : EventActionInterceptionAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnAddHandler(EventActionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            var instance = (IEventActionWith6ArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnAddEvent);
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventActionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            var instance = (IEventActionWith6ArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnInvoke);
            args.Arg1.Add(AspectJoinPoints.OnInvoke);
            args.Arg2.Add(AspectJoinPoints.OnInvoke);
            args.Arg3.Add(AspectJoinPoints.OnInvoke);
            args.Arg4.Add(AspectJoinPoints.OnInvoke);
            args.Arg5.Add(AspectJoinPoints.OnInvoke);
            args.Arg6.Add(AspectJoinPoints.OnInvoke);
            args.ProceedInvokeHandler();
        }

        public override void OnRemoveHandler(EventActionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            var instance = (IEventActionWith6ArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnRemoveEvent);
            args.ProceedRemoveHandler();
        }
    }

    public class EventActionInterceptionAspectIgnoreFollowingfAspects : EventActionInterceptionAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnAddHandler(EventActionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            var instance = (IEventActionWith6ArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnAddEvent);
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventActionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            var instance = (IEventActionWith6ArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnInvoke);
            args.Arg1.Add(AspectJoinPoints.OnInvoke);
            args.Arg2.Add(AspectJoinPoints.OnInvoke);
            args.Arg3.Add(AspectJoinPoints.OnInvoke);
            args.Arg4.Add(AspectJoinPoints.OnInvoke);
            args.Arg5.Add(AspectJoinPoints.OnInvoke);
            args.Arg6.Add(AspectJoinPoints.OnInvoke);
            args.InvokeHanlder();
        }

        public override void OnRemoveHandler(EventActionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            var instance = (IEventActionWith6ArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnRemoveEvent);
            args.ProceedRemoveHandler();
        }
    }
}
