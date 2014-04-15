using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;

namespace NCop.Aspects.Tests.ActionWith1ArgumentAspect.Subjects
{
    public interface IActionWith1ArgumentBoundaryAspect
    {
        void InterceptionAspect(List<AspectJoinPoints> joinPoints);
        void OnMethodBoundaryAspect(List<AspectJoinPoints> joinPoints);
        void MultipleInterceptionAspects(List<AspectJoinPoints> joinPoints);
        void MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> joinPoints);
        void AllAspectsStartingWithInterception(List<AspectJoinPoints> joinPoints);
        void AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> joinPoints);
        void AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> joinPoints);
        void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> joinPoints);
        void AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> joinPoints);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> joinPoints);
        void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> joinPoints);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> joinPoints);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> joinPoints);
    }

    public class CSharpDeveloperMixin : IActionWith1ArgumentBoundaryAspect
    {
        private void AddInMethodJoinPoint(List<AspectJoinPoints> joinPoints) {
            joinPoints.Add(AspectJoinPoints.InMethod);
        }

        public void InterceptionAspect(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
        }

        public void OnMethodBoundaryAspect(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
        }

        public void MultipleInterceptionAspects(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
        }

        public void MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
        }

        public void AllAspectsStartingWithInterception(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
        }

        public void AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
        }

        public void AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
        }

        public void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
        }

        public void AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
            throw new Exception("InMethodException");
        }

        public void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> joinPoints) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(joinPoints);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> joinPoints) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(joinPoints);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> joinPoints) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(joinPoints);
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IActionWith1ArgumentComposite : IActionWith1ArgumentBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(ActionWith1ArgumentInterceptionAspect))]
        new void InterceptionAspect(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(ActionWith1ArgumentOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspect(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(ActionWith1ArgumentOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith1ArgumentOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith1ArgumentOnMethodBoundaryAspect))]
        new void MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> joinPoints);

        [MethodInterceptionAspect(typeof(ActionWith1ArgumentInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith1ArgumentInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith1ArgumentInterceptionAspect))]
        new void MultipleInterceptionAspects(List<AspectJoinPoints> joinPoints);

        [MethodInterceptionAspect(typeof(ActionWith1ArgumentInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith1ArgumentOnMethodBoundaryAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithInterception(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(ActionWith1ArgumentOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith1ArgumentInterceptionAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> joinPoints);

        [MethodInterceptionAspect(typeof(ActionWith1ArgumentInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith1ArgumentOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(ActionWith1ArgumentInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(ActionWith1ArgumentOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(ActionWith1ArgumentInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(ActionWith1ArgumentOnMethodBoundaryAspect), AspectPriority = 6)]
        new void AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(OnEntry_ActionWith1ArgumentBoundaryAspect))]
        new void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(ActionWith1ArgumentOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith1ArgumentInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(ActionWith1ArgumentOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(ActionWith1ArgumentInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(ActionWith1ArgumentOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(ActionWith1ArgumentInterceptionAspect), AspectPriority = 6)]
        new void AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(ActionWith1ArgumentOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_ActionWith1ArgumentBoundaryAspect))]
        new void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_ActionWith1ArgumentBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurActionWith1ArgumentBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> joinPoints);
    }

    public class ActionWith1ArgumentOnMethodBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>>
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

    public class OnEntry_ActionWith1ArgumentBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>>
    {
        public override void OnEntry(ActionExecutionArgs<List<AspectJoinPoints>> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_ActionWith1ArgumentBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>>
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
    }

    public class OnEntry_OnSuccess_OnExit_ActionWith1ArgumentBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>>
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

        public override void OnExit(ActionExecutionArgs<List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurActionWith1ArgumentBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>>
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

    public class ActionWith1ArgumentInterceptionAspect : ActionInterceptionAspect<List<AspectJoinPoints>>
    {
        public override void OnInvoke(ActionInterceptionArgs<List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnInvoke);
            base.OnInvoke(args);
        }
    }
}
