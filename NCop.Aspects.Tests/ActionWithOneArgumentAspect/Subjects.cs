using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;

namespace NCop.Aspects.Tests.ActionWithOneArgumentAspect.Subjects
{
    public interface IActionWithOneArgumentBoundaryAspect
    {
        void InterceptionAspect(List<AspectJoinPoints> joinPoints);
        void OnMethodBoundaryAspect(List<AspectJoinPoints> joinPoints);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> joinPoints);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehavipurAspect(List<AspectJoinPoints> joinPoints);
    }

    public class CSharpDeveloperMixin : IActionWithOneArgumentBoundaryAspect
    {
        public void OnMethodBoundaryAspect(List<AspectJoinPoints> joinPoints) {
            joinPoints.Add(AspectJoinPoints.InMethod);
        }

        public void InterceptionAspect(List<AspectJoinPoints> joinPoints) {
            joinPoints.Add(AspectJoinPoints.InMethod);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> joinPoints) {
            joinPoints.Add(AspectJoinPoints.InMethod);
            throw new Exception("InMethodException");
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehavipurAspect(List<AspectJoinPoints> joinPoints) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(joinPoints);
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IActionWithOneArgumentComposite : IActionWithOneArgumentBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(ActionWithOneArgumnetInterceptionAspect))]
        new void InterceptionAspect(List<AspectJoinPoints> language);

        [OnMethodBoundaryAspect(typeof(ActionWithOneArgumnetBoundaryAspect))]
        new void OnMethodBoundaryAspect(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(ActionWithOneArgumnetBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurActionWithOneArgumnetBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehavipurAspect(List<AspectJoinPoints> joinPoints);
    }

    public class ActionWithOneArgumnetBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>>
    {
        public override void OnEntry(ActionExecutionArgs<List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<List<AspectJoinPoints>> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurActionWithOneArgumnetBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>>
    {
        public override void OnEntry(ActionExecutionArgs<List<AspectJoinPoints>> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<List<AspectJoinPoints>> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class ActionWithOneArgumnetInterceptionAspect : ActionInterceptionAspect<List<AspectJoinPoints>>
    {
        public override void OnInvoke(ActionInterceptionArgs<List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnInvoke);
            base.OnInvoke(args);
        }
    }
}
