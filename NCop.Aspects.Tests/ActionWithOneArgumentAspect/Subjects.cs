using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;

namespace NCop.Aspects.Tests.ActionWithOneArgumentAspect.Subjects
{
    public interface IActionWithOneArgumentBoundaryAspect
    {
        void InterceptionAspect(List<AspectJoinPoints> joinPoints);
        void OnMethodBoundaryAspect(List<AspectJoinPoints> joinPoints);
        void MultipleInterceptionAspects(List<AspectJoinPoints> joinPoints);
        void MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> joinPoints);
        void AllAspectsStartingWithInterception(List<AspectJoinPoints> joinPoints);
        void AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> joinPoints);
        void AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> joinPoints);
        void AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> joinPoints);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> joinPoints);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> joinPoints);
    }

    public class CSharpDeveloperMixin : IActionWithOneArgumentBoundaryAspect
    {
        private void AddInMethodJoinPoint(List<AspectJoinPoints> joinPoints) {
            joinPoints.Add(AspectJoinPoints.InMethod);
        }

        public void InterceptionAspect(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
        }

        public void OnMethodBoundaryAspect(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
        }

        public void MultipleInterceptionAspects(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
        }

        public void MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
        }

        public void AllAspectsStartingWithInterception(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
        }

        public void AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
        }

        public void AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
        }

        public void AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
        }
        
        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
            throw new Exception("InMethodException");
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> joinPoints) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(joinPoints);
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IActionWithOneArgumentComposite : IActionWithOneArgumentBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(ActionWithOneArgumentInterceptionAspect))]
        new void InterceptionAspect(List<AspectJoinPoints> language);

        [OnMethodBoundaryAspect(typeof(ActionWithOneArgumentOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspect(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(ActionWithOneArgumentOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWithOneArgumentOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWithOneArgumentOnMethodBoundaryAspect))]
        new void MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> joinPoints);

        [MethodInterceptionAspect(typeof(ActionWithOneArgumentInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWithOneArgumentInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWithOneArgumentInterceptionAspect))]
        new void MultipleInterceptionAspects(List<AspectJoinPoints> joinPoints);

        [MethodInterceptionAspect(typeof(ActionWithOneArgumentInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWithOneArgumentOnMethodBoundaryAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithInterception(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(ActionWithOneArgumentOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWithOneArgumentInterceptionAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> joinPoints);

        [MethodInterceptionAspect(typeof(ActionWithOneArgumentInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWithOneArgumentOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(ActionWithOneArgumentInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(ActionWithOneArgumentOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(ActionWithOneArgumentInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(ActionWithOneArgumentOnMethodBoundaryAspect), AspectPriority = 6)]
        new void AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(ActionWithOneArgumentOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWithOneArgumentInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(ActionWithOneArgumentOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(ActionWithOneArgumentInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(ActionWithOneArgumentOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(ActionWithOneArgumentInterceptionAspect), AspectPriority = 6)]
        new void AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(ActionWithOneArgumentOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurActionWithOneArgumentBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> joinPoints);
    }

    public class ActionWithOneArgumentOnMethodBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>>
    {
        public override void OnEntry(ActionExecutionArgs<List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<List<AspectJoinPoints>> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurActionWithOneArgumentBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>>
    {
        public override void OnEntry(ActionExecutionArgs<List<AspectJoinPoints>> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<List<AspectJoinPoints>> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class ActionWithOneArgumentInterceptionAspect : ActionInterceptionAspect<List<AspectJoinPoints>>
    {
        public override void OnInvoke(ActionInterceptionArgs<List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnInvoke);
            base.OnInvoke(args);
        }
    }
}
