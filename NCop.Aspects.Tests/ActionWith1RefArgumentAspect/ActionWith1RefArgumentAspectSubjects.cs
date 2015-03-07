using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;

namespace NCop.Aspects.Tests.ActionWith1RefArgumentAspect.Subjects
{
    public interface IActionWith1RefArgumentBoundaryAspect
    {
        void InterceptionAspect(ref int i);
        void OnMethodBoundaryAspect(ref int i);
        void MultipleInterceptionAspects(ref int i);
        void InterceptionAspectUsingInvoke(ref int i);
        void MultipleOnMethodBoundaryAspects(ref int i);
        void AllAspectsStartingWithInterception(ref int i);
        void AllAspectsStartingWithOnMethodBoundary(ref int i);
        void AlternatelAspectsStartingWithInterception(ref int i);
        void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i);
        void AlternateAspectsStartingWithOnMethodBoundary(ref int i);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i);
        void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i);
    }

    public class Mixin : IActionWith1RefArgumentBoundaryAspect
    {
        private void AddInMethodJoinPoint(ref int i) {
            i += (int)AspectJoinPoints.InMethod;
        }

        public void InterceptionAspect(ref int i) {
            AddInMethodJoinPoint(ref i);
        }

        public void OnMethodBoundaryAspect(ref int i) {
            AddInMethodJoinPoint(ref i);
        }

        public void MultipleInterceptionAspects(ref int i) {
            AddInMethodJoinPoint(ref i);
        }

        public void InterceptionAspectUsingInvoke(ref int i) {
            AddInMethodJoinPoint(ref i);
        }

        public void MultipleOnMethodBoundaryAspects(ref int i) {
            AddInMethodJoinPoint(ref i);
        }

        public void AllAspectsStartingWithInterception(ref int i) {
            AddInMethodJoinPoint(ref i);
        }

        public void AllAspectsStartingWithOnMethodBoundary(ref int i) {
            AddInMethodJoinPoint(ref i);
        }

        public void AlternatelAspectsStartingWithInterception(ref int i) {
            AddInMethodJoinPoint(ref i);
        }

        public void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i) {
            AddInMethodJoinPoint(ref i);
        }

        public void AlternateAspectsStartingWithOnMethodBoundary(ref int i) {
            AddInMethodJoinPoint(ref i);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i) {
            AddInMethodJoinPoint(ref i);
            throw new Exception("InMethodException");
        }

        public void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i);
        }
    }

    [TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IActionWith1RefArgumentComposite : IActionWith1RefArgumentBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(ActionWith1RefArgumentInterceptionAspect))]
        new void InterceptionAspect(ref int i);

        [OnMethodBoundaryAspect(typeof(ActionWith1RefArgumentOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspect(ref int i);

        [OnMethodBoundaryAspect(typeof(ActionWith1RefArgumentOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith1RefArgumentOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith1RefArgumentOnMethodBoundaryAspect))]
        new void MultipleOnMethodBoundaryAspects(ref int i);

        [MethodInterceptionAspect(typeof(ActionWith1RefArgumentInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith1RefArgumentInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith1RefArgumentInterceptionAspect))]
        new void MultipleInterceptionAspects(ref int i);

        [MethodInterceptionAspect(typeof(ActionWith1RefArgumentInterceptionUsinInvokeAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith1RefArgumentOnMethodBoundaryAspect), AspectPriority = 2)]
        new void InterceptionAspectUsingInvoke(ref int i);

        [MethodInterceptionAspect(typeof(ActionWith1RefArgumentInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith1RefArgumentOnMethodBoundaryAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithInterception(ref int i);

        [OnMethodBoundaryAspect(typeof(ActionWith1RefArgumentOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith1RefArgumentInterceptionAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithOnMethodBoundary(ref int i);

        [MethodInterceptionAspect(typeof(ActionWith1RefArgumentInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith1RefArgumentOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(ActionWith1RefArgumentInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(ActionWith1RefArgumentOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(ActionWith1RefArgumentInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(ActionWith1RefArgumentOnMethodBoundaryAspect), AspectPriority = 6)]
        new void AlternatelAspectsStartingWithInterception(ref int i);

        [OnMethodBoundaryAspect(typeof(OnEntry_ActionWith1RefArgumentBoundaryAspect))]
        new void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i);

        [OnMethodBoundaryAspect(typeof(ActionWith1RefArgumentOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith1RefArgumentInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(ActionWith1RefArgumentOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(ActionWith1RefArgumentInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(ActionWith1RefArgumentOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(ActionWith1RefArgumentInterceptionAspect), AspectPriority = 6)]
        new void AlternateAspectsStartingWithOnMethodBoundary(ref int i);

        [OnMethodBoundaryAspect(typeof(ActionWith1RefArgumentOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_ActionWith1RefArgumentBoundaryAspect))]
        new void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_ActionWith1RefArgumentBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurActionWith1RefArgumentBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i);
    }

    public class ActionWith1RefArgumentOnMethodBoundaryAspect : OnActionBoundaryAspect<int>
    {
        public override void OnEntry(ActionExecutionArgs<int> args) {
            args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int> args) {
            args.Arg1 += (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<int> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1 += (int)AspectJoinPoints.OnException;
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<int> args) {
            args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class OnEntry_ActionWith1RefArgumentBoundaryAspect : OnActionBoundaryAspect<int>
    {
        public override void OnEntry(ActionExecutionArgs<int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_ActionWith1RefArgumentBoundaryAspect : OnActionBoundaryAspect<int>
    {
        public override void OnEntry(ActionExecutionArgs<int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int> args) {
            args.Arg1 += (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_ActionWith1RefArgumentBoundaryAspect : OnActionBoundaryAspect<int>
    {
        public override void OnEntry(ActionExecutionArgs<int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int> args) {
            args.Arg1 += (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnExit(ActionExecutionArgs<int> args) {
            args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurActionWith1RefArgumentBoundaryAspect : OnActionBoundaryAspect<int>
    {
        public override void OnEntry(ActionExecutionArgs<int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int> args) {
            args.Arg1 += (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<int> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1 += (int)AspectJoinPoints.OnException;
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<int> args) {
            args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class ActionWith1RefArgumentInterceptionAspect : ActionInterceptionAspect<int>
    {
        public override void OnInvoke(ActionInterceptionArgs<int> args) {
            args.Arg1 += (int)AspectJoinPoints.OnInvoke;
            base.OnInvoke(args);
        }
    }

    public class ActionWith1RefArgumentInterceptionUsinInvokeAspect : ActionInterceptionAspect<int>
    {
        public override void OnInvoke(ActionInterceptionArgs<int> args) {
            args.Invoke();
        }
    }
}
