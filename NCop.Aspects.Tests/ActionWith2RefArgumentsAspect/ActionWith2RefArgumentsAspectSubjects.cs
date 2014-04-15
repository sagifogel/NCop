using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;

namespace NCop.Aspects.Tests.ActionWith2RefArgumentsAspect.Subjects
{
    public interface IActionWith2RefArgumentsBoundaryAspect
    {
        void InterceptionAspect(ref int i, ref int j);
        void OnMethodBoundaryAspect(ref int i, ref int j);
        void MultipleInterceptionAspects(ref int i, ref int j);
        void MultipleOnMethodBoundaryAspects(ref int i, ref int j);
        void AllAspectsStartingWithInterception(ref int i, ref int j);
        void AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j);
        void AlternatelAspectsStartingWithInterception(ref int i, ref int j);
        void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j);
        void AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j);
        void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j);
    }

    public class CSharpDeveloperMixin : IActionWith2RefArgumentsBoundaryAspect
    {
        private void AddInMethodJoinPoint(ref int i, ref int j) {
            j = i += (int)AspectJoinPoints.InMethod;
        }

        public void InterceptionAspect(ref int i, ref int j) {
            AddInMethodJoinPoint(ref i, ref j);
        }

        public void OnMethodBoundaryAspect(ref int i, ref int j) {
            AddInMethodJoinPoint(ref i, ref j);
        }

        public void MultipleInterceptionAspects(ref int i, ref int j) {
            AddInMethodJoinPoint(ref i, ref j);
        }

        public void MultipleOnMethodBoundaryAspects(ref int i, ref int j) {
            AddInMethodJoinPoint(ref i, ref j);
        }

        public void AllAspectsStartingWithInterception(ref int i, ref int j) {
            AddInMethodJoinPoint(ref i, ref j);
        }

        public void AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j) {
            AddInMethodJoinPoint(ref i, ref j);
        }

        public void AlternatelAspectsStartingWithInterception(ref int i, ref int j) {
            AddInMethodJoinPoint(ref i, ref j);
        }

        public void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j) {
            AddInMethodJoinPoint(ref i, ref j);
        }

        public void AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j) {
            AddInMethodJoinPoint(ref i, ref j);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j) {
            AddInMethodJoinPoint(ref i, ref j);
            throw new Exception("InMethodException");
        }

        public void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j);
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IActionWith2RefArgumentsComposite : IActionWith2RefArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(ActionWith2RefArgumentsInterceptionAspect))]
        new void InterceptionAspect(ref int i, ref int j);

        [OnMethodBoundaryAspect(typeof(ActionWith2RefArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspect(ref int i, ref int j);

        [OnMethodBoundaryAspect(typeof(ActionWith2RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith2RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith2RefArgumentsOnMethodBoundaryAspect))]
        new void MultipleOnMethodBoundaryAspects(ref int i, ref int j);

        [MethodInterceptionAspect(typeof(ActionWith2RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith2RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith2RefArgumentsInterceptionAspect))]
        new void MultipleInterceptionAspects(ref int i, ref int j);

        [MethodInterceptionAspect(typeof(ActionWith2RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith2RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithInterception(ref int i, ref int j);

        [OnMethodBoundaryAspect(typeof(ActionWith2RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith2RefArgumentsInterceptionAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j);

        [MethodInterceptionAspect(typeof(ActionWith2RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith2RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(ActionWith2RefArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(ActionWith2RefArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(ActionWith2RefArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(ActionWith2RefArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new void AlternatelAspectsStartingWithInterception(ref int i, ref int j);

        [OnMethodBoundaryAspect(typeof(OnEntry_ActionWith2RefArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j);

        [OnMethodBoundaryAspect(typeof(ActionWith2RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith2RefArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(ActionWith2RefArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(ActionWith2RefArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(ActionWith2RefArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(ActionWith2RefArgumentsInterceptionAspect), AspectPriority = 6)]
        new void AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j);

        [OnMethodBoundaryAspect(typeof(ActionWith2RefArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_ActionWith2RefArgumentsBoundaryAspect))]
        new void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_ActionWith2RefArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurActionWith2RefArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j);
    }

    public class ActionWith2RefArgumentsOnMethodBoundaryAspect : OnActionBoundaryAspect<int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int> args) {
            args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int> args) {
            args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<int, int> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<int, int> args) {
            args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class OnEntry_ActionWith2RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_ActionWith2RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int> args) {
            args.Arg2 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_ActionWith2RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int> args) {
            args.Arg2 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnExit(ActionExecutionArgs<int, int> args) {
            args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurActionWith2RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int> args) {
            args.Arg2 = args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<int, int> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<int, int> args) {
            args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class ActionWith2RefArgumentsInterceptionAspect : ActionInterceptionAspect<int, int>
    {
        public override void OnInvoke(ActionInterceptionArgs<int, int> args) {
            args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnInvoke;
            base.OnInvoke(args);
        }
    }
}
