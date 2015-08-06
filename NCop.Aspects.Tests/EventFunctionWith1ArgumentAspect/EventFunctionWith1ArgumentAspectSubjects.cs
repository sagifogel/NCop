using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Tests.EventFunctionWith1ArgumentAspect.Subjects
{
    public interface IEventFunctionWith1ArgumentBoundaryAspect
    {
        List<AspectJoinPoints> Values { get; set; }
        event Func<List<AspectJoinPoints>, string> InterceptionAspect;
        event Func<List<AspectJoinPoints>, string> MutipleInterceptionAspect;
        string RaiseInterceptionAspect(List<AspectJoinPoints> args);
        string RaiseMultipleInterceptionAspect(List<AspectJoinPoints> args);
    }

    public class Mixin : IEventFunctionWith1ArgumentBoundaryAspect
    {
        public event Func<List<AspectJoinPoints>, string> InterceptionAspect;
        public event Func<List<AspectJoinPoints>, string> MutipleInterceptionAspect;

        public Mixin() {
            Values = new List<AspectJoinPoints>();
        }

        public List<AspectJoinPoints> Values { get; set; }

        public string RaiseInterceptionAspect(List<AspectJoinPoints> args) {
            return RaiseInterceptionAspect(InterceptionAspect, args);
        }

        public string RaiseMultipleInterceptionAspect(List<AspectJoinPoints> args) {
            return RaiseInterceptionAspect(MutipleInterceptionAspect, args);
        }

        public string RaiseInterceptionAspect(Func<List<AspectJoinPoints>, string> func, List<AspectJoinPoints> args) {
            if (func.IsNotNull()) {
                return func(args);
            }

            return AspectJoinPoints.NoEvent.ToString();
        }
    }

    [TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IEventFunctionWith1ArgumentComposite : IEventFunctionWith1ArgumentBoundaryAspect
    {
        [EventInterceptionAspect(typeof(FunctionEventInterceptionAspect))]
        new event Func<List<AspectJoinPoints>, string> InterceptionAspect;

        [EventInterceptionAspect(typeof(FunctionEventInterceptionAspect), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(FunctionEventInterceptionAspect), AspectPriority = 1)]
        [EventInterceptionAspect(typeof(FunctionEventInterceptionAspect), AspectPriority = 1)]
        new event Func<List<AspectJoinPoints>, string> MutipleInterceptionAspect;
    }

    public class FunctionEventInterceptionAspect : EventFunctionInterceptionAspect<List<AspectJoinPoints>, string>
    {
        public override void OnAddHandler(EventFunctionInterceptionArgs<List<AspectJoinPoints>, string> args) {
            var instance = (IEventFunctionWith1ArgumentBoundaryAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnAddEvent);
            args.ProceedAddHandler();
        }

        public override void OnInvokeHandler(EventFunctionInterceptionArgs<List<AspectJoinPoints>, string> args) {
            var instance = (IEventFunctionWith1ArgumentBoundaryAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnInvoke);
            args.ProceedInvokeHandler();
        }

        public override void OnRemoveHandler(EventFunctionInterceptionArgs<List<AspectJoinPoints>, string> args) {
            var instance = (IEventFunctionWith1ArgumentBoundaryAspect)args.Instance;

            instance.Values.Add(AspectJoinPoints.OnRemoveEvent);
            args.ProceedRemoveHandler();
        }
    }
}
