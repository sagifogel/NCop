using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;

namespace NCop.Aspects.Tests.ActionWith4RefArgumentsAspect.Subjects
{
    public interface IActionWith4RefArgumentsBoundaryAspect
    {
        void InterceptionAspect(ref int i, ref int j, ref int k, ref int l);
        void OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l);
        void MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l);
        void InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l);
        void MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l);
        void AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l);
        void AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l);
        void AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l);
        void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l);
        void AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l);
        void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l);
    }

    public class CSharpDeveloperMixin : IActionWith4RefArgumentsBoundaryAspect
    {
        private void AddInMethodJoinPoint(ref int i, ref int j, ref int k, ref int l) {
            l = k = j = i += (int)AspectJoinPoints.InMethod;
        }

        public void InterceptionAspect(ref int i, ref int j, ref int k, ref int l) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l);
        }

        public void OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l);
        }

        public void MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l);
        }

        public void InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l);
        }

        public void MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l);
        }

        public void AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l);
        }

        public void AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l);
        }

        public void AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l);
        }

        public void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l);
        }

        public void AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l);
            throw new Exception("InMethodException");
        }

        public void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l);
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IActionWith4RefArgumentsComposite : IActionWith4RefArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(ActionWith4RefArgumentsInterceptionAspect))]
        new void InterceptionAspect(ref int i, ref int j, ref int k, ref int l);

        [OnMethodBoundaryAspect(typeof(ActionWith4RefArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l);

        [OnMethodBoundaryAspect(typeof(ActionWith4RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith4RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith4RefArgumentsOnMethodBoundaryAspect))]
        new void MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l);

        [MethodInterceptionAspect(typeof(ActionWith4RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith4RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith4RefArgumentsInterceptionAspect))]
        new void MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l);

        [MethodInterceptionAspect(typeof(ActionWith4RefArgumentsInterceptionUsinInvokeAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith4RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new void InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l);

        [MethodInterceptionAspect(typeof(ActionWith4RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith4RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l);

        [OnMethodBoundaryAspect(typeof(ActionWith4RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith4RefArgumentsInterceptionAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l);

        [MethodInterceptionAspect(typeof(ActionWith4RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith4RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(ActionWith4RefArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(ActionWith4RefArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(ActionWith4RefArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(ActionWith4RefArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new void AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l);

        [OnMethodBoundaryAspect(typeof(OnEntry_ActionWith4RefArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l);

        [OnMethodBoundaryAspect(typeof(ActionWith4RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith4RefArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(ActionWith4RefArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(ActionWith4RefArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(ActionWith4RefArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(ActionWith4RefArgumentsInterceptionAspect), AspectPriority = 6)]
        new void AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l);

        [OnMethodBoundaryAspect(typeof(ActionWith4RefArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_ActionWith4RefArgumentsBoundaryAspect))]
        new void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_ActionWith4RefArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurActionWith4RefArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l);
    }

    public class ActionWith4RefArgumentsOnMethodBoundaryAspect : OnActionBoundaryAspect<int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int> args) {
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int, int> args) {
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<int, int, int, int> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<int, int, int, int> args) {
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class OnEntry_ActionWith4RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_ActionWith4RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int, int> args) {
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_ActionWith4RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int, int> args) {
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnExit(ActionExecutionArgs<int, int, int, int> args) {
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurActionWith4RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int, int> args) {
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<int, int, int, int> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<int, int, int, int> args) {
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class ActionWith4RefArgumentsInterceptionAspect : ActionInterceptionAspect<int, int, int, int>
    {
        public override void OnInvoke(ActionInterceptionArgs<int, int, int, int> args) {
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnInvoke;
            base.OnInvoke(args);
        }
    }

    public class ActionWith4RefArgumentsInterceptionUsinInvokeAspect : ActionInterceptionAspect<int, int, int, int>
    {
        public override void OnInvoke(ActionInterceptionArgs<int, int, int, int> args) {
            args.Invoke();
        }
    }
}
