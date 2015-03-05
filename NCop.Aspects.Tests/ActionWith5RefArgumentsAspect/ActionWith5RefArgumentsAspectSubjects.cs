using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;

namespace NCop.Aspects.Tests.ActionWith5RefArgumentsAspect.Subjects
{
    public interface IActionWith5RefArgumentsBoundaryAspect
    {
        void InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m);
        void OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m);
        void MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m);
        void InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l, ref int m);
        void MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m);
        void AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m);
        void AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m);
        void AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m);
        void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m);
        void AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m);
        void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m);
    }

    public class CSharpDeveloperMixin : IActionWith5RefArgumentsBoundaryAspect
    {
        private void AddInMethodJoinPoint(ref int i, ref int j, ref int k, ref int l, ref int m) {
            m = l = k = j = i += (int)AspectJoinPoints.InMethod;
        }

        public void InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
        }

        public void OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
        }

        public void MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
        }

        public void InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l, ref int m) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
        }

        public void MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
        }

        public void AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
        }

        public void AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
        }

        public void AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
        }

        public void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
        }

        public void AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
            throw new Exception("InMethodException");
        }

        public void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m);
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IActionWith5RefArgumentsComposite : IActionWith5RefArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(ActionWith5RefArgumentsInterceptionAspect))]
        new void InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m);

        [OnMethodBoundaryAspect(typeof(ActionWith5RefArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m);

        [OnMethodBoundaryAspect(typeof(ActionWith5RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith5RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith5RefArgumentsOnMethodBoundaryAspect))]
        new void MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m);

        [MethodInterceptionAspect(typeof(ActionWith5RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith5RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith5RefArgumentsInterceptionAspect))]
        new void MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m);

        [MethodInterceptionAspect(typeof(ActionWith5RefArgumentsInterceptionUsinInvokeAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith5RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new void InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l, ref int m);

        [MethodInterceptionAspect(typeof(ActionWith5RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith5RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m);

        [OnMethodBoundaryAspect(typeof(ActionWith5RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith5RefArgumentsInterceptionAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m);

        [MethodInterceptionAspect(typeof(ActionWith5RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith5RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(ActionWith5RefArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(ActionWith5RefArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(ActionWith5RefArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(ActionWith5RefArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new void AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m);

        [OnMethodBoundaryAspect(typeof(OnEntry_ActionWith5RefArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m);

        [OnMethodBoundaryAspect(typeof(ActionWith5RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith5RefArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(ActionWith5RefArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(ActionWith5RefArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(ActionWith5RefArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(ActionWith5RefArgumentsInterceptionAspect), AspectPriority = 6)]
        new void AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m);

        [OnMethodBoundaryAspect(typeof(ActionWith5RefArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_ActionWith5RefArgumentsBoundaryAspect))]
        new void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_ActionWith5RefArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurActionWith5RefArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m);
    }

    public class ActionWith5RefArgumentsOnMethodBoundaryAspect : OnActionBoundaryAspect<int, int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int, int> args) {
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int, int, int> args) {
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<int, int, int, int, int> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<int, int, int, int, int> args) {
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class OnEntry_ActionWith5RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_ActionWith5RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int, int, int> args) {
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_ActionWith5RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int, int, int> args) {
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnExit(ActionExecutionArgs<int, int, int, int, int> args) {
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurActionWith5RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int, int, int> args) {
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<int, int, int, int, int> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<int, int, int, int, int> args) {
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class ActionWith5RefArgumentsInterceptionAspect : ActionInterceptionAspect<int, int, int, int, int>
    {
        public override void OnInvoke(ActionInterceptionArgs<int, int, int, int, int> args) {
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnInvoke;
            base.OnInvoke(args);
        }
    }

    public class ActionWith5RefArgumentsInterceptionUsinInvokeAspect : ActionInterceptionAspect<int, int, int, int, int>
    {
        public override void OnInvoke(ActionInterceptionArgs<int, int, int, int, int> args) {
            args.Invoke();
        }
    }
}
