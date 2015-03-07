using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;

namespace NCop.Aspects.Tests.ActionWith6RefArgumentsAspect.Subjects
{
    public interface IActionWith6RefArgumentsBoundaryAspect
    {
        void InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        void OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        void MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        void InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        void MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        void AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        void AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        void AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        void AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
    }

    public class Mixin : IActionWith6RefArgumentsBoundaryAspect
    {
        private void AddInMethodJoinPoint(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            n = m = l = k = j = i += (int)AspectJoinPoints.InMethod;
        }

        public void InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public void OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public void MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public void InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public void MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public void AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public void AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public void AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public void AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
            throw new Exception("InMethodException");
        }

        public void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n);
        }
    }

    [TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IActionWith6RefArgumentsComposite : IActionWith6RefArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(ActionWith6RefArgumentsInterceptionAspect))]
        new void InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [OnMethodBoundaryAspect(typeof(ActionWith6RefArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [OnMethodBoundaryAspect(typeof(ActionWith6RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith6RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith6RefArgumentsOnMethodBoundaryAspect))]
        new void MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [MethodInterceptionAspect(typeof(ActionWith6RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith6RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith6RefArgumentsInterceptionAspect))]
        new void MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [MethodInterceptionAspect(typeof(ActionWith6RefArgumentsInterceptionUsinInvokeAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith6RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new void InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [MethodInterceptionAspect(typeof(ActionWith6RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith6RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [OnMethodBoundaryAspect(typeof(ActionWith6RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith6RefArgumentsInterceptionAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [MethodInterceptionAspect(typeof(ActionWith6RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith6RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(ActionWith6RefArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(ActionWith6RefArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(ActionWith6RefArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(ActionWith6RefArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new void AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [OnMethodBoundaryAspect(typeof(OnEntry_ActionWith6RefArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [OnMethodBoundaryAspect(typeof(ActionWith6RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith6RefArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(ActionWith6RefArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(ActionWith6RefArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(ActionWith6RefArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(ActionWith6RefArgumentsInterceptionAspect), AspectPriority = 6)]
        new void AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [OnMethodBoundaryAspect(typeof(ActionWith6RefArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_ActionWith6RefArgumentsBoundaryAspect))]
        new void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_ActionWith6RefArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurActionWith6RefArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
    }

    public class ActionWith6RefArgumentsOnMethodBoundaryAspect : OnActionBoundaryAspect<int, int, int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int, int, int> args) {
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int, int, int, int> args) {
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<int, int, int, int, int, int> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<int, int, int, int, int, int> args) {
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class OnEntry_ActionWith6RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_ActionWith6RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int, int, int, int> args) {
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_ActionWith6RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int, int, int, int> args) {
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnExit(ActionExecutionArgs<int, int, int, int, int, int> args) {
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurActionWith6RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int, int, int, int> args) {
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<int, int, int, int, int, int> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<int, int, int, int, int, int> args) {
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class ActionWith6RefArgumentsInterceptionAspect : ActionInterceptionAspect<int, int, int, int, int, int>
    {
        public override void OnInvoke(ActionInterceptionArgs<int, int, int, int, int, int> args) {
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnInvoke;
            base.OnInvoke(args);
        }
    }

    public class ActionWith6RefArgumentsInterceptionUsinInvokeAspect : ActionInterceptionAspect<int, int, int, int, int, int>
    {
        public override void OnInvoke(ActionInterceptionArgs<int, int, int, int, int, int> args) {
            args.Invoke();
        }
    }
}
