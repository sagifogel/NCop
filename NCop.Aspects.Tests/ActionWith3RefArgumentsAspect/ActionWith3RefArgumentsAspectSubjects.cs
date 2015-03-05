using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;

namespace NCop.Aspects.Tests.ActionWith3RefArgumentsAspect.Subjects
{
    public interface IActionWith3RefArgumentsBoundaryAspect
    {
        void InterceptionAspect(ref int i, ref int j, ref int k);
        void OnMethodBoundaryAspect(ref int i, ref int j, ref int k);
        void MultipleInterceptionAspects(ref int i, ref int j, ref int k);
        void InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k);
        void MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k);
        void AllAspectsStartingWithInterception(ref int i, ref int j, ref int k);
        void AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k);
        void AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k);
        void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k);
        void AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k);
        void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k);
    }

    public class CSharpDeveloperMixin : IActionWith3RefArgumentsBoundaryAspect
    {
        private void AddInMethodJoinPoint(ref int i, ref int j, ref int k) {
            k = j = i += (int)AspectJoinPoints.InMethod;
        }

        public void InterceptionAspect(ref int i, ref int j, ref int k) {
            AddInMethodJoinPoint(ref i, ref j, ref k);
        }

        public void OnMethodBoundaryAspect(ref int i, ref int j, ref int k) {
            AddInMethodJoinPoint(ref i, ref j, ref k);
        }

        public void MultipleInterceptionAspects(ref int i, ref int j, ref int k) {
            AddInMethodJoinPoint(ref i, ref j, ref k);
        }

        public void InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k) {
            AddInMethodJoinPoint(ref i, ref j, ref k);
        }

        public void MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k) {
            AddInMethodJoinPoint(ref i, ref j, ref k);
        }

        public void AllAspectsStartingWithInterception(ref int i, ref int j, ref int k) {
            AddInMethodJoinPoint(ref i, ref j, ref k);
        }

        public void AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k) {
            AddInMethodJoinPoint(ref i, ref j, ref k);
        }

        public void AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k) {
            AddInMethodJoinPoint(ref i, ref j, ref k);
        }

        public void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k) {
            AddInMethodJoinPoint(ref i, ref j, ref k);
        }

        public void AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k) {
            AddInMethodJoinPoint(ref i, ref j, ref k);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k) {
            AddInMethodJoinPoint(ref i, ref j, ref k);
            throw new Exception("InMethodException");
        }

        public void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k);
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IActionWith3RefArgumentsComposite : IActionWith3RefArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(ActionWith3RefArgumentsInterceptionAspect))]
        new void InterceptionAspect(ref int i, ref int j, ref int k);

        [OnMethodBoundaryAspect(typeof(ActionWith3RefArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspect(ref int i, ref int j, ref int k);

        [OnMethodBoundaryAspect(typeof(ActionWith3RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith3RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith3RefArgumentsOnMethodBoundaryAspect))]
        new void MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k);

        [MethodInterceptionAspect(typeof(ActionWith3RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith3RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith3RefArgumentsInterceptionAspect))]
        new void MultipleInterceptionAspects(ref int i, ref int j, ref int k);

        [MethodInterceptionAspect(typeof(ActionWith3RefArgumentsInterceptionUsinInvokeAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith3RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new void InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k);

        [MethodInterceptionAspect(typeof(ActionWith3RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith3RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithInterception(ref int i, ref int j, ref int k);

        [OnMethodBoundaryAspect(typeof(ActionWith3RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith3RefArgumentsInterceptionAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k);

        [MethodInterceptionAspect(typeof(ActionWith3RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith3RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(ActionWith3RefArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(ActionWith3RefArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(ActionWith3RefArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(ActionWith3RefArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new void AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k);

        [OnMethodBoundaryAspect(typeof(OnEntry_ActionWith3RefArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k);

        [OnMethodBoundaryAspect(typeof(ActionWith3RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith3RefArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(ActionWith3RefArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(ActionWith3RefArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(ActionWith3RefArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(ActionWith3RefArgumentsInterceptionAspect), AspectPriority = 6)]
        new void AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k);

        [OnMethodBoundaryAspect(typeof(ActionWith3RefArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_ActionWith3RefArgumentsBoundaryAspect))]
        new void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_ActionWith3RefArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurActionWith3RefArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k);
    }

    public class ActionWith3RefArgumentsOnMethodBoundaryAspect : OnActionBoundaryAspect<int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int> args) {
            args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int> args) {
            args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<int, int, int> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<int, int, int> args) {
            args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class OnEntry_ActionWith3RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_ActionWith3RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int> args) {
            args.Arg3 = args.Arg2 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_ActionWith3RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int> args) {
            args.Arg3 = args.Arg2 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnExit(ActionExecutionArgs<int, int, int> args) {
            args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurActionWith3RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int> args) {
            args.Arg3 = args.Arg2 = args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<int, int, int> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<int, int, int> args) {
            args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class ActionWith3RefArgumentsInterceptionAspect : ActionInterceptionAspect<int, int, int>
    {
        public override void OnInvoke(ActionInterceptionArgs<int, int, int> args) {
            args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnInvoke;
            base.OnInvoke(args);
        }
    }

    public class ActionWith3RefArgumentsInterceptionUsinInvokeAspect : ActionInterceptionAspect<int, int, int>
    {
        public override void OnInvoke(ActionInterceptionArgs<int, int, int> args) {
            args.Invoke();
        }
    }
}
