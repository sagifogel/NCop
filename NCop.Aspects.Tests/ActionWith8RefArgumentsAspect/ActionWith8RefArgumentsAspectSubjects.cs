using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;

namespace NCop.Aspects.Tests.ActionWith8RefArgumentsAspect.Subjects
{
    public interface IActionWith8RefArgumentsBoundaryAspect
    {
        void InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        void OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        void MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        void InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        void MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        void AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        void AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        void AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        void AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
    }

    public class Mixin : IActionWith8RefArgumentsBoundaryAspect
    {
        private void AddInMethodJoinPoint(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            p = o = n = m = l = k = j = i += (int)AspectJoinPoints.InMethod;
        }

        public void InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public void OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public void MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public void InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public void MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public void AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public void AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public void AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public void AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
            throw new Exception("InMethodException");
        }

        public void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }
    }

    [TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IActionWith8RefArgumentsComposite : IActionWith8RefArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(ActionWith8RefArgumentsInterceptionAspect))]
        new void InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [OnMethodBoundaryAspect(typeof(ActionWith8RefArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [OnMethodBoundaryAspect(typeof(ActionWith8RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith8RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith8RefArgumentsOnMethodBoundaryAspect))]
        new void MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [MethodInterceptionAspect(typeof(ActionWith8RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith8RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith8RefArgumentsInterceptionAspect))]
        new void MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [MethodInterceptionAspect(typeof(ActionWith8RefArgumentsInterceptionUsinInvokeAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith8RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new void InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [MethodInterceptionAspect(typeof(ActionWith8RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith8RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [OnMethodBoundaryAspect(typeof(ActionWith8RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith8RefArgumentsInterceptionAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [MethodInterceptionAspect(typeof(ActionWith8RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith8RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(ActionWith8RefArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(ActionWith8RefArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(ActionWith8RefArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(ActionWith8RefArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new void AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [OnMethodBoundaryAspect(typeof(OnEntry_ActionWith8RefArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [OnMethodBoundaryAspect(typeof(ActionWith8RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith8RefArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(ActionWith8RefArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(ActionWith8RefArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(ActionWith8RefArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(ActionWith8RefArgumentsInterceptionAspect), AspectPriority = 6)]
        new void AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [OnMethodBoundaryAspect(typeof(ActionWith8RefArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_ActionWith8RefArgumentsBoundaryAspect))]
        new void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_ActionWith8RefArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurActionWith8RefArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
    }

    public class ActionWith8RefArgumentsOnMethodBoundaryAspect : OnActionBoundaryAspect<int, int, int, int, int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int, int, int, int, int> args) {
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int, int, int, int, int, int> args) {
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<int, int, int, int, int, int, int, int> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<int, int, int, int, int, int, int, int> args) {
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class OnEntry_ActionWith8RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int, int, int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int, int, int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_ActionWith8RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int, int, int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int, int, int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int, int, int, int, int, int> args) {
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_ActionWith8RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int, int, int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int, int, int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int, int, int, int, int, int> args) {
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnExit(ActionExecutionArgs<int, int, int, int, int, int, int, int> args) {
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurActionWith8RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int, int, int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int, int, int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int, int, int, int, int, int> args) {
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<int, int, int, int, int, int, int, int> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<int, int, int, int, int, int, int, int> args) {
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class ActionWith8RefArgumentsInterceptionAspect : ActionInterceptionAspect<int, int, int, int, int, int, int, int>
    {
        public override void OnInvoke(ActionInterceptionArgs<int, int, int, int, int, int, int, int> args) {
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnInvoke;
            base.OnInvoke(args);
        }
    }

    public class ActionWith8RefArgumentsInterceptionUsinInvokeAspect : ActionInterceptionAspect<int, int, int, int, int, int, int, int>
    {
        public override void OnInvoke(ActionInterceptionArgs<int, int, int, int, int, int, int, int> args) {
            args.Invoke();
        }
    }
}
