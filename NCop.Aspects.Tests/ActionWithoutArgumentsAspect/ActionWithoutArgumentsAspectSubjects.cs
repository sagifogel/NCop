using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;

namespace NCop.Aspects.Tests.ActionWithoutArgumentAspect.Subjects
{
    public static class JoinPointsContainer
    {
        public static AspectOrderedJoinPoints JoinPoints = new AspectOrderedJoinPoints();
    }

    public interface IActionWithoutArgumentsBoundaryAspect
    {
        void InterceptionAspect();
        void OnMethodBoundaryAspect();
        void MultipleInterceptionAspects();
        void MultipleOnMethodBoundaryAspects();
        void AllAspectsStartingWithInterception();
        void AllAspectsStartingWithOnMethodBoundary();
        void AlternatelAspectsStartingWithInterception();
        void AlternateAspectsStartingWithOnMethodBoundary();
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl();
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect();
    }

    public class CSharpDeveloperMixin : IActionWithoutArgumentsBoundaryAspect
    {
        private void AddInMethodJoinPoint() {
            JoinPointsContainer.JoinPoints.Add(AspectJoinPoints.InMethod);
        }

        public void InterceptionAspect() {
            AddInMethodJoinPoint();
        }

        public void OnMethodBoundaryAspect() {
            AddInMethodJoinPoint();
        }

        public void MultipleInterceptionAspects() {
            AddInMethodJoinPoint();
        }

        public void MultipleOnMethodBoundaryAspects() {
            AddInMethodJoinPoint();
        }

        public void AllAspectsStartingWithInterception() {
            AddInMethodJoinPoint();
        }

        public void AllAspectsStartingWithOnMethodBoundary() {
            AddInMethodJoinPoint();
        }

        public void AlternatelAspectsStartingWithInterception() {
            AddInMethodJoinPoint();
        }

        public void AlternateAspectsStartingWithOnMethodBoundary() {
            AddInMethodJoinPoint();
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl() {
            AddInMethodJoinPoint();
            throw new Exception("InMethodException");
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect() {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl();
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IActionWithoutArgumentsComposite : IActionWithoutArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(ActionWithoutArgumentsInterceptionAspect))]
        new void InterceptionAspect();

        [OnMethodBoundaryAspect(typeof(ActionWithoutArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspect();

        [OnMethodBoundaryAspect(typeof(ActionWithoutArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWithoutArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWithoutArgumentsOnMethodBoundaryAspect))]
        new void MultipleOnMethodBoundaryAspects();

        [MethodInterceptionAspect(typeof(ActionWithoutArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWithoutArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWithoutArgumentsInterceptionAspect))]
        new void MultipleInterceptionAspects();

        [MethodInterceptionAspect(typeof(ActionWithoutArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWithoutArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithInterception();

        [OnMethodBoundaryAspect(typeof(ActionWithoutArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWithoutArgumentsInterceptionAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithOnMethodBoundary();

        [MethodInterceptionAspect(typeof(ActionWithoutArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWithoutArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(ActionWithoutArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(ActionWithoutArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(ActionWithoutArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(ActionWithoutArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new void AlternatelAspectsStartingWithInterception();

        [OnMethodBoundaryAspect(typeof(ActionWithoutArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWithoutArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(ActionWithoutArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(ActionWithoutArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(ActionWithoutArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(ActionWithoutArgumentsInterceptionAspect), AspectPriority = 6)]
        new void AlternateAspectsStartingWithOnMethodBoundary();

        [OnMethodBoundaryAspect(typeof(ActionWithoutArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl();

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurActionWithoutArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect();
    }

    public class ActionWithoutArgumentsOnMethodBoundaryAspect : OnActionBoundaryAspect
    {
        public override void OnEntry(ActionExecutionArgs args) {
            JoinPointsContainer.JoinPoints.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs args) {
            JoinPointsContainer.JoinPoints.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                JoinPointsContainer.JoinPoints.Add(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs args) {
            JoinPointsContainer.JoinPoints.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurActionWithoutArgumentsBoundaryAspect : OnActionBoundaryAspect
    {
        public override void OnEntry(ActionExecutionArgs args) {
            args.FlowBehavior = FlowBehavior.Continue;
            JoinPointsContainer.JoinPoints.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs args) {
            JoinPointsContainer.JoinPoints.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                JoinPointsContainer.JoinPoints.Add(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs args) {
            JoinPointsContainer.JoinPoints.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class ActionWithoutArgumentsInterceptionAspect : ActionInterceptionAspect
    {
        public override void OnInvoke(ActionInterceptionArgs args) {
            JoinPointsContainer.JoinPoints.Add(AspectJoinPoints.OnInvoke);
            base.OnInvoke(args);
        }
    }
}
