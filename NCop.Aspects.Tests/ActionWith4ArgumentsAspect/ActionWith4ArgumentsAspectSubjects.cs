using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Tests.ActionWith4ArgumentsAspect.Subjects
{
    public interface IActionWith4ArgumentsBoundaryAspect
    {
        void InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        void OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        void MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        void InterceptionAspectUsingInvoke(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        void MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        void AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        void AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        void AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        void AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
    }

    public class Mixin : IActionWith4ArgumentsBoundaryAspect
    {
        private void AddInMethodJoinPoint(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            first.Add(AspectJoinPoints.InMethod);
            second.Add(AspectJoinPoints.InMethod);
            third.Add(AspectJoinPoints.InMethod);
            fourth.Add(AspectJoinPoints.InMethod);
        }

        public void InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            AddInMethodJoinPoint(first, second, third, fourth);
        }

        public void OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            AddInMethodJoinPoint(first, second, third, fourth);
        }

        public void MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            AddInMethodJoinPoint(first, second, third, fourth);
        }

        public void InterceptionAspectUsingInvoke(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            AddInMethodJoinPoint(first, second, third, fourth);
        }

        public void MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            AddInMethodJoinPoint(first, second, third, fourth);
        }

        public void AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            AddInMethodJoinPoint(first, second, third, fourth);
        }

        public void AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            AddInMethodJoinPoint(first, second, third, fourth);
        }

        public void AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            AddInMethodJoinPoint(first, second, third, fourth);
        }

        public void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            AddInMethodJoinPoint(first, second, third, fourth);
        }

        public void AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            AddInMethodJoinPoint(first, second, third, fourth);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            AddInMethodJoinPoint(first, second, third, fourth);
            throw new Exception("InMethodException");
        }

        public void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth);
        }
    }

    [TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IActionWith4ArgumentsComposite : IActionWith4ArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(ActionWith4ArgumentsInterceptionAspect))]
        new void InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [OnMethodBoundaryAspect(typeof(ActionWith4ArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [OnMethodBoundaryAspect(typeof(ActionWith4ArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith4ArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith4ArgumentsOnMethodBoundaryAspect))]
        new void MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [MethodInterceptionAspect(typeof(ActionWith4ArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith4ArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith4ArgumentsInterceptionAspect))]
        new void MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [MethodInterceptionAspect(typeof(ActionWith4ArgumentsInterceptionUsinInvokeAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith4ArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new void InterceptionAspectUsingInvoke(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [MethodInterceptionAspect(typeof(ActionWith4ArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith4ArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [OnMethodBoundaryAspect(typeof(ActionWith4ArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith4ArgumentsInterceptionAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [MethodInterceptionAspect(typeof(ActionWith4ArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith4ArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(ActionWith4ArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(ActionWith4ArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(ActionWith4ArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(ActionWith4ArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new void AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [OnMethodBoundaryAspect(typeof(OnEntry_ActionWith4ArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [OnMethodBoundaryAspect(typeof(ActionWith4ArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith4ArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(ActionWith4ArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(ActionWith4ArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(ActionWith4ArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(ActionWith4ArgumentsInterceptionAspect), AspectPriority = 6)]
        new void AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [OnMethodBoundaryAspect(typeof(ActionWith4ArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_ActionWith4ArgumentsBoundaryAspect))]
        new void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_ActionWith4ArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurActionWith4ArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
    }

    public class ActionWith4ArgumentsOnMethodBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnEntry(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
                args.Arg2.Add(AspectJoinPoints.OnException);
                args.Arg3.Add(AspectJoinPoints.OnException);
                args.Arg4.Add(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.Arg3.Add(AspectJoinPoints.OnExit);
            args.Arg4.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class OnEntry_ActionWith4ArgumentsBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnEntry(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_ActionWith4ArgumentsBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnEntry(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_ActionWith4ArgumentsBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnEntry(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnExit(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.Arg3.Add(AspectJoinPoints.OnExit);
            args.Arg4.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurActionWith4ArgumentsBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnEntry(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
                args.Arg2.Add(AspectJoinPoints.OnException);
                args.Arg3.Add(AspectJoinPoints.OnException);
                args.Arg4.Add(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.Arg3.Add(AspectJoinPoints.OnExit);
            args.Arg4.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class ActionWith4ArgumentsInterceptionAspect : ActionInterceptionAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnInvoke(ActionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnInvoke);
            args.Arg2.Add(AspectJoinPoints.OnInvoke);
            args.Arg3.Add(AspectJoinPoints.OnInvoke);
            args.Arg4.Add(AspectJoinPoints.OnInvoke);
            base.OnInvoke(args);
        }
    }

    public class ActionWith4ArgumentsInterceptionUsinInvokeAspect : ActionInterceptionAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnInvoke(ActionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Invoke();
        }
    }
}
