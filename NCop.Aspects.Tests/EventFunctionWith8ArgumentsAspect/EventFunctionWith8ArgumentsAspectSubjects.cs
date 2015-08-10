using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Tests.EventFunctionWith8ArgumentsAspect.Subjects
{
    public interface IEventFunctionWith8ArgumentsAspect
    {
        List<AspectJoinPoints> Values { get; set; }
        event Func<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> InterceptionAspect;
        event Func<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> MultipleInterceptionAspects;
        event Func<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> MultipleIgnoredInterceptionAspects;
        string RaiseInterceptionAspect(List<AspectJoinPoints> arg1, List<AspectJoinPoints> arg2, List<AspectJoinPoints> arg3, List<AspectJoinPoints> arg4, List<AspectJoinPoints> arg5, List<AspectJoinPoints> arg6, List<AspectJoinPoints> arg7, List<AspectJoinPoints> arg8);
        string RaiseMultipleInterceptionAspect(List<AspectJoinPoints> arg1, List<AspectJoinPoints> arg2, List<AspectJoinPoints> arg3, List<AspectJoinPoints> arg4, List<AspectJoinPoints> arg5, List<AspectJoinPoints> arg6, List<AspectJoinPoints> arg7, List<AspectJoinPoints> arg8);
        string RaiseMultipleIgnoredInterceptionAspects(List<AspectJoinPoints> arg1, List<AspectJoinPoints> arg2, List<AspectJoinPoints> arg3, List<AspectJoinPoints> arg4, List<AspectJoinPoints> arg5, List<AspectJoinPoints> arg6, List<AspectJoinPoints> arg7, List<AspectJoinPoints> arg8);
    }

    public class Mixin : IEventFunctionWith8ArgumentsAspect
    {
        public event Func<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> InterceptionAspect;
        public event Func<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> MultipleInterceptionAspects;
        public event Func<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> MultipleIgnoredInterceptionAspects;

        public Mixin() {
            Values = new List<AspectJoinPoints>();
        }

        public List<AspectJoinPoints> Values { get; set; }

        public string RaiseInterceptionAspect(List<AspectJoinPoints> arg1, List<AspectJoinPoints> arg2, List<AspectJoinPoints> arg3, List<AspectJoinPoints> arg4, List<AspectJoinPoints> arg5, List<AspectJoinPoints> arg6, List<AspectJoinPoints> arg7, List<AspectJoinPoints> arg8) {
            return RaiseInterceptionAspect(InterceptionAspect, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public string RaiseMultipleInterceptionAspect(List<AspectJoinPoints> arg1, List<AspectJoinPoints> arg2, List<AspectJoinPoints> arg3, List<AspectJoinPoints> arg4, List<AspectJoinPoints> arg5, List<AspectJoinPoints> arg6, List<AspectJoinPoints> arg7, List<AspectJoinPoints> arg8) {
            return RaiseInterceptionAspect(MultipleInterceptionAspects, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public string RaiseMultipleIgnoredInterceptionAspects(List<AspectJoinPoints> arg1, List<AspectJoinPoints> arg2, List<AspectJoinPoints> arg3, List<AspectJoinPoints> arg4, List<AspectJoinPoints> arg5, List<AspectJoinPoints> arg6, List<AspectJoinPoints> arg7, List<AspectJoinPoints> arg8) {
            return RaiseInterceptionAspect(MultipleIgnoredInterceptionAspects, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public string RaiseInterceptionAspect(Func<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> func, List<AspectJoinPoints> arg1, List<AspectJoinPoints> arg2, List<AspectJoinPoints> arg3, List<AspectJoinPoints> arg4, List<AspectJoinPoints> arg5, List<AspectJoinPoints> arg6, List<AspectJoinPoints> arg7, List<AspectJoinPoints> arg8) {
            if (func.IsNotNull()) {
                return func(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
            }

            return AspectJoinPoints.NoEvent.ToString();
        }
    }

    [TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IEventFunctionWith8ArgumentsComposite : IEventFunctionWith8ArgumentsAspect
    {
        [EventInterceptionAspect(typeof(EventFunctionInterceptionAspect))]
        new event Func<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> InterceptionAspect;

        [EventInterceptionAspect(typeof(EventFunctionInterceptionAspect), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(EventFunctionInterceptionAspect), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(EventFunctionInterceptionAspect), AspectPriority = 1)]
        new event Func<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> MultipleInterceptionAspects;

        [EventInterceptionAspect(typeof(EventFunctionInterceptionAspectIgnoreFollowingfAspects), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(EventFunctionInterceptionAspect), AspectPriority = 2)]
        [EventInterceptionAspect(typeof(EventFunctionInterceptionAspect), AspectPriority = 3)]
        new event Func<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> MultipleIgnoredInterceptionAspects;
    }

    public class EventFunctionInterceptionAspect : EventFunctionInterceptionAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnAddHandler(EventFunctionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            var instance = (IEventFunctionWith8ArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnAddEvent);
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventFunctionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            var instance = (IEventFunctionWith8ArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnInvoke);
            args.Arg1.Add(AspectJoinPoints.OnInvoke);
            args.Arg2.Add(AspectJoinPoints.OnInvoke);
            args.Arg3.Add(AspectJoinPoints.OnInvoke);
            args.Arg4.Add(AspectJoinPoints.OnInvoke);
            args.Arg5.Add(AspectJoinPoints.OnInvoke);
            args.Arg6.Add(AspectJoinPoints.OnInvoke);
            args.Arg7.Add(AspectJoinPoints.OnInvoke);
            args.Arg8.Add(AspectJoinPoints.OnInvoke);
            args.ProceedInvokeHandler();
        }

        public override void OnRemoveHandler(EventFunctionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            var instance = (IEventFunctionWith8ArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnRemoveEvent);
            args.ProceedRemoveHandler();
        }
    }

    public class EventFunctionInterceptionAspectIgnoreFollowingfAspects : EventFunctionInterceptionAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnAddHandler(EventFunctionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            var instance = (IEventFunctionWith8ArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnAddEvent);
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventFunctionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            var instance = (IEventFunctionWith8ArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnInvoke);
            args.Arg1.Add(AspectJoinPoints.OnInvoke);
            args.Arg2.Add(AspectJoinPoints.OnInvoke);
            args.Arg3.Add(AspectJoinPoints.OnInvoke);
            args.Arg4.Add(AspectJoinPoints.OnInvoke);
            args.Arg5.Add(AspectJoinPoints.OnInvoke);
            args.Arg6.Add(AspectJoinPoints.OnInvoke);
            args.Arg7.Add(AspectJoinPoints.OnInvoke);
            args.Arg8.Add(AspectJoinPoints.OnInvoke);
            args.InvokeHanlder();
        }

        public override void OnRemoveHandler(EventFunctionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            var instance = (IEventFunctionWith8ArgumentsAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnRemoveEvent);
            args.ProceedRemoveHandler();
        }
    }
}
