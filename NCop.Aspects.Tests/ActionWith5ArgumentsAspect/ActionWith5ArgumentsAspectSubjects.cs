using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Tests.ActionWith5ArgumentsAspect.Subjects
{
    public interface IActionWith5ArgumentsBoundaryAspect
    {
        void InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);
        void OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);
        void MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);
        void InterceptionAspectUsingInvoke(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);
        void MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);
        void AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);
        void AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);
        void AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);
        void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);
        void AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);
        void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);
    }

    public class Mixin : IActionWith5ArgumentsBoundaryAspect
    {
        private void AddInMethodJoinPoint(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth) {
            first.Add(AspectJoinPoints.InMethod);
            second.Add(AspectJoinPoints.InMethod);
            third.Add(AspectJoinPoints.InMethod);
            fourth.Add(AspectJoinPoints.InMethod);
            fifth.Add(AspectJoinPoints.InMethod);
        }

        public void InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth);
        }

        public void OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth);
        }

        public void MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth);
        }

        public void InterceptionAspectUsingInvoke(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth);
        }

        public void MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth);
        }

        public void AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth);
        }

        public void AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth);
        }

        public void AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth);
        }

        public void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth);
        }

        public void AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth);
            throw new Exception("InMethodException");
        }

        public void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth, fifth);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth, fifth);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth, fifth);
        }
    }

    [TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IActionWith5ArgumentsComposite : IActionWith5ArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(ActionWith5ArgumentsInterceptionAspect))]
        new void InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);

        [OnMethodBoundaryAspect(typeof(ActionWith5ArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);

        [OnMethodBoundaryAspect(typeof(ActionWith5ArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith5ArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith5ArgumentsOnMethodBoundaryAspect))]
        new void MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);

        [MethodInterceptionAspect(typeof(ActionWith5ArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith5ArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith5ArgumentsInterceptionAspect))]
        new void MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);

        [MethodInterceptionAspect(typeof(ActionWith5ArgumentsInterceptionUsinInvokeAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith5ArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new void InterceptionAspectUsingInvoke(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);

        [MethodInterceptionAspect(typeof(ActionWith5ArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith5ArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);

        [OnMethodBoundaryAspect(typeof(ActionWith5ArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith5ArgumentsInterceptionAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);

        [MethodInterceptionAspect(typeof(ActionWith5ArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith5ArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(ActionWith5ArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(ActionWith5ArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(ActionWith5ArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(ActionWith5ArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new void AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);

        [OnMethodBoundaryAspect(typeof(OnEntry_ActionWith5ArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);

        [OnMethodBoundaryAspect(typeof(ActionWith5ArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith5ArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(ActionWith5ArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(ActionWith5ArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(ActionWith5ArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(ActionWith5ArgumentsInterceptionAspect), AspectPriority = 6)]
        new void AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);

        [OnMethodBoundaryAspect(typeof(ActionWith5ArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_ActionWith5ArgumentsBoundaryAspect))]
        new void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_ActionWith5ArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurActionWith5ArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth);
    }

    public class ActionWith5ArgumentsOnMethodBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnEntry(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.Arg5.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            args.Arg5.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
                args.Arg2.Add(AspectJoinPoints.OnException);
                args.Arg3.Add(AspectJoinPoints.OnException);
                args.Arg4.Add(AspectJoinPoints.OnExit);
                args.Arg5.Add(AspectJoinPoints.OnExit);
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.Arg3.Add(AspectJoinPoints.OnExit);
            args.Arg4.Add(AspectJoinPoints.OnExit);
            args.Arg5.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class OnEntry_ActionWith5ArgumentsBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnEntry(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.Arg5.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_ActionWith5ArgumentsBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnEntry(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.Arg5.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            args.Arg5.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_ActionWith5ArgumentsBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnEntry(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.Arg5.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            args.Arg5.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnExit(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.Arg3.Add(AspectJoinPoints.OnExit);
            args.Arg4.Add(AspectJoinPoints.OnExit);
            args.Arg5.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurActionWith5ArgumentsBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnEntry(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.Arg5.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            args.Arg5.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
                args.Arg2.Add(AspectJoinPoints.OnException);
                args.Arg3.Add(AspectJoinPoints.OnException);
                args.Arg4.Add(AspectJoinPoints.OnException);
                args.Arg5.Add(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.Arg3.Add(AspectJoinPoints.OnExit);
            args.Arg4.Add(AspectJoinPoints.OnExit);
            args.Arg5.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class ActionWith5ArgumentsInterceptionAspect : ActionInterceptionAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnInvoke(ActionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnInvoke);
            args.Arg2.Add(AspectJoinPoints.OnInvoke);
            args.Arg3.Add(AspectJoinPoints.OnInvoke);
            args.Arg4.Add(AspectJoinPoints.OnInvoke);
            args.Arg5.Add(AspectJoinPoints.OnInvoke);
            base.OnInvoke(args);
        }
    }

    public class ActionWith5ArgumentsInterceptionUsinInvokeAspect : ActionInterceptionAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnInvoke(ActionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Invoke();
        }
    }
}
