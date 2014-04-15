using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;
using NCop.Aspects.Framework;

namespace NCop.Aspects.Tests.ActionWith8ArgumentsAspect.Subjects
{
    public interface IActionWith8ArgumentsBoundaryAspect
    {
        void InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);
        void OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);
        void MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);
        void MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);
        void AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);
        void AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);
        void AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);
        void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);
        void AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);
        void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);
        void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);
    }

    public class CSharpDeveloperMixin : IActionWith8ArgumentsBoundaryAspect
    {
        private void AddInMethodJoinPoint(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights) {
            first.Add(AspectJoinPoints.InMethod);
            second.Add(AspectJoinPoints.InMethod);
            third.Add(AspectJoinPoints.InMethod);
            fourth.Add(AspectJoinPoints.InMethod);
            fifth.Add(AspectJoinPoints.InMethod);
            sixth.Add(AspectJoinPoints.InMethod);
            seventh.Add(AspectJoinPoints.InMethod);
            eights.Add(AspectJoinPoints.InMethod);
        }

        public void InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth, seventh, eights);
        }

        public void OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth, seventh, eights);
        }

        public void MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth, seventh, eights);
        }

        public void MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth, seventh, eights);
        }

        public void AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth, seventh, eights);
        }

        public void AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth, seventh, eights);
        }

        public void AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth, seventh, eights);
        }

        public void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth, seventh, eights);
        }

        public void AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth, seventh, eights);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth, seventh, eights);
            throw new Exception("InMethodException");
        }

        public void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth, fifth, sixth, seventh, eights);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth, fifth, sixth, seventh, eights);
        }

        public void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights) {
            OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth, fifth, sixth, seventh, eights);
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IActionWith8ArgumentsComposite : IActionWith8ArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(ActionWith8ArgumentsInterceptionAspect))]
        new void InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);

        [OnMethodBoundaryAspect(typeof(ActionWith8ArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);

        [OnMethodBoundaryAspect(typeof(ActionWith8ArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith8ArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(ActionWith8ArgumentsOnMethodBoundaryAspect))]
        new void MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);

        [MethodInterceptionAspect(typeof(ActionWith8ArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith8ArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(ActionWith8ArgumentsInterceptionAspect))]
        new void MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);

        [MethodInterceptionAspect(typeof(ActionWith8ArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith8ArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);

        [OnMethodBoundaryAspect(typeof(ActionWith8ArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith8ArgumentsInterceptionAspect), AspectPriority = 2)]
        new void AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);

        [MethodInterceptionAspect(typeof(ActionWith8ArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(ActionWith8ArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(ActionWith8ArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(ActionWith8ArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(ActionWith8ArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(ActionWith8ArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new void AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);

        [OnMethodBoundaryAspect(typeof(OnEntry_ActionWith8ArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);

        [OnMethodBoundaryAspect(typeof(ActionWith8ArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(ActionWith8ArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(ActionWith8ArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(ActionWith8ArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(ActionWith8ArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(ActionWith8ArgumentsInterceptionAspect), AspectPriority = 6)]
        new void AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);

        [OnMethodBoundaryAspect(typeof(ActionWith8ArgumentsOnMethodBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_ActionWith8ArgumentsBoundaryAspect))]
        new void TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_ActionWith8ArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurActionWith8ArgumentsBoundaryAspect))]
        new void OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh, List<AspectJoinPoints> eights);
    }

    public class ActionWith8ArgumentsOnMethodBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnEntry(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.Arg5.Add(AspectJoinPoints.OnEntry);
            args.Arg6.Add(AspectJoinPoints.OnEntry);
            args.Arg7.Add(AspectJoinPoints.OnEntry);
            args.Arg8.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            args.Arg5.Add(AspectJoinPoints.OnSuccess);
            args.Arg6.Add(AspectJoinPoints.OnSuccess);
            args.Arg7.Add(AspectJoinPoints.OnSuccess);
            args.Arg8.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
                args.Arg2.Add(AspectJoinPoints.OnException);
                args.Arg3.Add(AspectJoinPoints.OnException);
                args.Arg4.Add(AspectJoinPoints.OnExit);
                args.Arg5.Add(AspectJoinPoints.OnExit);
                args.Arg6.Add(AspectJoinPoints.OnExit);
                args.Arg7.Add(AspectJoinPoints.OnExit);
                args.Arg8.Add(AspectJoinPoints.OnExit);
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.Arg3.Add(AspectJoinPoints.OnExit);
            args.Arg4.Add(AspectJoinPoints.OnExit);
            args.Arg5.Add(AspectJoinPoints.OnExit);
            args.Arg6.Add(AspectJoinPoints.OnExit);
            args.Arg7.Add(AspectJoinPoints.OnExit);
            args.Arg8.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class OnEntry_ActionWith8ArgumentsBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnEntry(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.Arg5.Add(AspectJoinPoints.OnEntry);
            args.Arg6.Add(AspectJoinPoints.OnEntry);
            args.Arg7.Add(AspectJoinPoints.OnEntry);
            args.Arg8.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_ActionWith8ArgumentsBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnEntry(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.Arg5.Add(AspectJoinPoints.OnEntry);
            args.Arg6.Add(AspectJoinPoints.OnEntry);
            args.Arg7.Add(AspectJoinPoints.OnEntry);
            args.Arg8.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            args.Arg5.Add(AspectJoinPoints.OnSuccess);
            args.Arg6.Add(AspectJoinPoints.OnSuccess);
            args.Arg7.Add(AspectJoinPoints.OnSuccess);
            args.Arg8.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_ActionWith8ArgumentsBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnEntry(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.Arg5.Add(AspectJoinPoints.OnEntry);
            args.Arg6.Add(AspectJoinPoints.OnEntry);
            args.Arg7.Add(AspectJoinPoints.OnEntry);
            args.Arg8.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            args.Arg5.Add(AspectJoinPoints.OnSuccess);
            args.Arg6.Add(AspectJoinPoints.OnSuccess);
            args.Arg7.Add(AspectJoinPoints.OnSuccess);
            args.Arg8.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnExit(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.Arg3.Add(AspectJoinPoints.OnExit);
            args.Arg4.Add(AspectJoinPoints.OnExit);
            args.Arg5.Add(AspectJoinPoints.OnExit);
            args.Arg6.Add(AspectJoinPoints.OnExit);
            args.Arg7.Add(AspectJoinPoints.OnExit);
            args.Arg8.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurActionWith8ArgumentsBoundaryAspect : OnActionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnEntry(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.Arg5.Add(AspectJoinPoints.OnEntry);
            args.Arg6.Add(AspectJoinPoints.OnEntry);
            args.Arg7.Add(AspectJoinPoints.OnEntry);
            args.Arg8.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            args.Arg5.Add(AspectJoinPoints.OnSuccess);
            args.Arg6.Add(AspectJoinPoints.OnSuccess);
            args.Arg7.Add(AspectJoinPoints.OnSuccess);
            args.Arg8.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
                args.Arg2.Add(AspectJoinPoints.OnException);
                args.Arg3.Add(AspectJoinPoints.OnException);
                args.Arg4.Add(AspectJoinPoints.OnException);
                args.Arg5.Add(AspectJoinPoints.OnException);
                args.Arg6.Add(AspectJoinPoints.OnException);
                args.Arg7.Add(AspectJoinPoints.OnException);
                args.Arg8.Add(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.Arg3.Add(AspectJoinPoints.OnExit);
            args.Arg4.Add(AspectJoinPoints.OnExit);
            args.Arg5.Add(AspectJoinPoints.OnExit);
            args.Arg6.Add(AspectJoinPoints.OnExit);
            args.Arg7.Add(AspectJoinPoints.OnExit);
            args.Arg8.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class ActionWith8ArgumentsInterceptionAspect : ActionInterceptionAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>>
    {
        public override void OnInvoke(ActionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>> args) {
            args.Arg1.Add(AspectJoinPoints.OnInvoke);
            args.Arg2.Add(AspectJoinPoints.OnInvoke);
            args.Arg3.Add(AspectJoinPoints.OnInvoke);
            args.Arg4.Add(AspectJoinPoints.OnInvoke);
            args.Arg5.Add(AspectJoinPoints.OnInvoke);
            args.Arg6.Add(AspectJoinPoints.OnInvoke);
            args.Arg7.Add(AspectJoinPoints.OnInvoke);
            args.Arg8.Add(AspectJoinPoints.OnInvoke);
            base.OnInvoke(args);
        }
    }
}
