using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;
using NCop.Aspects.Tests.Extensions;

namespace NCop.Aspects.Tests.FunctionWith2ArgumentsAspect.Subjects
{
    public interface IFunctionWith2ArgumentsBoundaryAspect
    {
        string InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second);
        string OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second);
        string MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second);
        string MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second);
        string AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second);
        string AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second);
        string AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second);
        string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second);
        string AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second);
        string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second);
    }

    public class CSharpDeveloperMixin : IFunctionWith2ArgumentsBoundaryAspect
    {
        private string AddInMethodJoinPoint(List<AspectJoinPoints> first, List<AspectJoinPoints> second) {
            first.Add(AspectJoinPoints.InMethod);
            second.Add(AspectJoinPoints.InMethod);

            return AspectJoinPoints.InMethod.ToString();
        }

        public string InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second) {
            return AddInMethodJoinPoint(first, second);
        }

        public string OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second) {
            return AddInMethodJoinPoint(first, second);
        }

        public string MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second) {
            return AddInMethodJoinPoint(first, second);
        }

        public string MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second) {
            return AddInMethodJoinPoint(first, second);
        }

        public string AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second) {
            return AddInMethodJoinPoint(first, second);
        }

        public string AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second) {
            return AddInMethodJoinPoint(first, second);
        }

        public string AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second) {
            return AddInMethodJoinPoint(first, second);
        }

        public string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second) {
            return AddInMethodJoinPoint(first, second);
        }

        public string AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second) {
            return AddInMethodJoinPoint(first, second);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second) {
            AddInMethodJoinPoint(first, second);
            throw new Exception("InMethodException");
        }

        public string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second);
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IFunctionWith2ArgumentsComposite : IFunctionWith2ArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(FunctionWith2ArgumentsInterceptionAspect))]
        new string InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second);

        [OnMethodBoundaryAspect(typeof(FunctionWith2ArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second);

        [OnMethodBoundaryAspect(typeof(FunctionWith2ArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith2ArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith2ArgumentsOnMethodBoundaryAspect))]
        new string MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second);

        [MethodInterceptionAspect(typeof(FunctionWith2ArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith2ArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith2ArgumentsInterceptionAspect))]
        new string MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second);

        [MethodInterceptionAspect(typeof(FunctionWith2ArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith2ArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second);

        [OnMethodBoundaryAspect(typeof(FunctionWith2ArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith2ArgumentsInterceptionAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second);

        [MethodInterceptionAspect(typeof(FunctionWith2ArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith2ArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(FunctionWith2ArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(FunctionWith2ArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(FunctionWith2ArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(FunctionWith2ArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new string AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second);

        [OnMethodBoundaryAspect(typeof(OnEntry_FunctionWith2ArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second);

        [OnMethodBoundaryAspect(typeof(FunctionWith2ArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith2ArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(FunctionWith2ArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(FunctionWith2ArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(FunctionWith2ArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(FunctionWith2ArgumentsInterceptionAspect), AspectPriority = 6)]
        new string AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second);

        [OnMethodBoundaryAspect(typeof(FunctionWith2ArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_FunctionWith2ArgumentsBoundaryAspect))]
        new string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_FunctionWith2ArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurFunctionWith2ArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second);
    }

    public class FunctionWith2ArgumentsOnMethodBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>,string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>,string> args) {
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>,string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>,string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
                args.Arg2.Add(AspectJoinPoints.OnException);
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>,string> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class OnEntry_FunctionWith2ArgumentsBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>,string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>,string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_FunctionWith2ArgumentsBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>,string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>,string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>,string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_FunctionWith2ArgumentsBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>,string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>,string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>,string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnExit(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>,string> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurFunctionWith2ArgumentsBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>,string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>,string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>,string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>,string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
                args.Arg2.Add(AspectJoinPoints.OnException);
                args.AddToReturnValue(AspectJoinPoints.InMethod);
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>,string> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class FunctionWith2ArgumentsInterceptionAspect : FunctionInterceptionAspect<List<AspectJoinPoints>, List<AspectJoinPoints>,string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>,string> args) {
            args.Arg1.Add(AspectJoinPoints.OnInvoke);
            args.Arg2.Add(AspectJoinPoints.OnInvoke);
            args.AddToReturnValue(AspectJoinPoints.OnInvoke);
            base.OnInvoke(args);
        }
    }
}
