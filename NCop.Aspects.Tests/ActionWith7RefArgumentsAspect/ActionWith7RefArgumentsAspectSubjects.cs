using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;

namespace NCop.Aspects.Tests.ActionWith7RefArgumentsAspect.Subjects
{
    public interface IActionWith7RefArgumentsBoundaryAspect
    {
        void InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        void OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        void MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        void InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        void MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        void AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        void AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        void AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        void AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
    }

    public class CSharpDeveloperMixin : IActionWith7RefArgumentsBoundaryAspect
    {
        private void AddInMethodJoinPoint(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            o = n = m = l = k = j = i += (int)AspectJoinPoints.InMethod;
        }

        public void InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public void OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public void MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public void InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public void MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public void AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public void AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public void AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public void AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
            throw new Exception("InMethodException");
        }

        public void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IActionWith7RefArgumentsComposite : IActionWith7RefArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(ActionWith7RefArgumentsInterceptionAspect))]
        new void InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [OnMethodBoundaryAspect(typeof(ActionWith7RefArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [OnMethodBoundaryAspect(typeof(ActionWith7RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith7RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith7RefArgumentsOnMethodBoundaryAspect))]
        new void MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [MethodInterceptionAspect(typeof(ActionWith7RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith7RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith7RefArgumentsInterceptionAspect))]
        new void MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [MethodInterceptionAspect(typeof(ActionWith7RefArgumentsInterceptionUsinInvokeAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith7RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new void InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [MethodInterceptionAspect(typeof(ActionWith7RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith7RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [OnMethodBoundaryAspect(typeof(ActionWith7RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith7RefArgumentsInterceptionAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [MethodInterceptionAspect(typeof(ActionWith7RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith7RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(ActionWith7RefArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(ActionWith7RefArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(ActionWith7RefArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(ActionWith7RefArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new void AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [OnMethodBoundaryAspect(typeof(OnEntry_ActionWith7RefArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [OnMethodBoundaryAspect(typeof(ActionWith7RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith7RefArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(ActionWith7RefArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(ActionWith7RefArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(ActionWith7RefArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(ActionWith7RefArgumentsInterceptionAspect), AspectPriority = 6)]
        new void AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [OnMethodBoundaryAspect(typeof(ActionWith7RefArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_ActionWith7RefArgumentsBoundaryAspect))]
        new void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_ActionWith7RefArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurActionWith7RefArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
    }

    public class ActionWith7RefArgumentsOnMethodBoundaryAspect : OnActionBoundaryAspect<int, int, int, int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int, int, int, int> args) {
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int, int, int, int, int> args) {
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<int, int, int, int, int, int, int> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<int, int, int, int, int, int, int> args) {
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class OnEntry_ActionWith7RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int, int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int, int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_ActionWith7RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int, int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int, int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int, int, int, int, int> args) {
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_ActionWith7RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int, int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int, int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int, int, int, int, int> args) {
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnExit(ActionExecutionArgs<int, int, int, int, int, int, int> args) {
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurActionWith7RefArgumentsBoundaryAspect : OnActionBoundaryAspect<int, int, int, int, int, int, int>
    {
        public override void OnEntry(ActionExecutionArgs<int, int, int, int, int, int, int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int, int, int, int, int, int, int> args) {
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<int, int, int, int, int, int, int> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<int, int, int, int, int, int, int> args) {
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class ActionWith7RefArgumentsInterceptionAspect : ActionInterceptionAspect<int, int, int, int, int, int, int>
    {
        public override void OnInvoke(ActionInterceptionArgs<int, int, int, int, int, int, int> args) {
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnInvoke;
            base.OnInvoke(args);
        }
    }

    public class ActionWith7RefArgumentsInterceptionUsinInvokeAspect : ActionInterceptionAspect<int, int, int, int, int, int, int>
    {
        public override void OnInvoke(ActionInterceptionArgs<int, int, int, int, int, int, int> args) {
            args.Invoke();
        }
    }
}
