using NCop.Aspects.Framework;
using NCop.Aspects.Tests.Extensions;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Tests.FunctionWith3ArgumentsAspect.Subjects
{
    public interface IFunctionWith3ArgumentsBoundaryAspect
    {
        string InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);
        string OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);
        string MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);
        string InterceptionAspectUsingInvoke(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);
        string MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);
        string AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);
        string AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);
        string AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);
        string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);
        string AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);
        string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);
    }

    public class Mixin : IFunctionWith3ArgumentsBoundaryAspect
    {
        private string AddInMethodJoinPoint(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third) {
            first.Add(AspectJoinPoints.InMethod);
            second.Add(AspectJoinPoints.InMethod);
            third.Add(AspectJoinPoints.InMethod);

            return AspectJoinPoints.InMethod.ToString();
        }

        public string InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third) {
            return AddInMethodJoinPoint(first, second, third);
        }

        public string OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third) {
            return AddInMethodJoinPoint(first, second, third);
        }

        public string MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third) {
            return AddInMethodJoinPoint(first, second, third);
        }

        public string InterceptionAspectUsingInvoke(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third) {
            return AddInMethodJoinPoint(first, second, third);
        }

        public string MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third) {
            return AddInMethodJoinPoint(first, second, third);
        }

        public string AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third) {
            return AddInMethodJoinPoint(first, second, third);
        }

        public string AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third) {
            return AddInMethodJoinPoint(first, second, third);
        }

        public string AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third) {
            return AddInMethodJoinPoint(first, second, third);
        }

        public string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third) {
            return AddInMethodJoinPoint(first, second, third);
        }

        public string AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third) {
            return AddInMethodJoinPoint(first, second, third);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third) {
            AddInMethodJoinPoint(first, second, third);
            throw new Exception("InMethodException");
        }

        public string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third);
        }
    }

    [TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IFunctionWith3ArgumentsComposite : IFunctionWith3ArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(FunctionWith3ArgumentsInterceptionAspect))]
        new string InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);

        [OnMethodBoundaryAspect(typeof(FunctionWith3ArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);

        [OnMethodBoundaryAspect(typeof(FunctionWith3ArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith3ArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith3ArgumentsOnMethodBoundaryAspect))]
        new string MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);

        [MethodInterceptionAspect(typeof(FunctionWith3ArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith3ArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith3ArgumentsInterceptionAspect))]
        new string MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);

        [MethodInterceptionAspect(typeof(FunctionWith3ArgumentsInterceptionUsinInvokeAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith3ArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new string InterceptionAspectUsingInvoke(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);

        [MethodInterceptionAspect(typeof(FunctionWith3ArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith3ArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);

        [OnMethodBoundaryAspect(typeof(FunctionWith3ArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith3ArgumentsInterceptionAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);

        [MethodInterceptionAspect(typeof(FunctionWith3ArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith3ArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(FunctionWith3ArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(FunctionWith3ArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(FunctionWith3ArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(FunctionWith3ArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new string AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);

        [OnMethodBoundaryAspect(typeof(OnEntry_FunctionWith3ArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);

        [OnMethodBoundaryAspect(typeof(FunctionWith3ArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith3ArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(FunctionWith3ArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(FunctionWith3ArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(FunctionWith3ArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(FunctionWith3ArgumentsInterceptionAspect), AspectPriority = 6)]
        new string AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);

        [OnMethodBoundaryAspect(typeof(FunctionWith3ArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_FunctionWith3ArgumentsBoundaryAspect))]
        new string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_FunctionWith3ArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurFunctionWith3ArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third);
    }

    public class FunctionWith3ArgumentsOnMethodBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
                args.Arg2.Add(AspectJoinPoints.OnException);
                args.Arg3.Add(AspectJoinPoints.OnException);
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.Arg3.Add(AspectJoinPoints.OnExit);
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class OnEntry_FunctionWith3ArgumentsBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>,List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>,List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_FunctionWith3ArgumentsBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>,List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>,List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>,List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_FunctionWith3ArgumentsBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>,List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>,List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>,List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnExit(FunctionExecutionArgs<List<AspectJoinPoints>,List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.Arg3.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurFunctionWith3ArgumentsBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
                args.Arg2.Add(AspectJoinPoints.OnException);
                args.Arg3.Add(AspectJoinPoints.OnException);
                args.AddToReturnValue(AspectJoinPoints.InMethod);
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.Arg3.Add(AspectJoinPoints.OnExit);
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class FunctionWith3ArgumentsInterceptionAspect : FunctionInterceptionAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnInvoke);
            args.Arg2.Add(AspectJoinPoints.OnInvoke);
            args.Arg3.Add(AspectJoinPoints.OnInvoke);
            args.AddToReturnValue(AspectJoinPoints.OnInvoke);
            base.OnInvoke(args);
        }
    }

    public class FunctionWith3ArgumentsInterceptionUsinInvokeAspect : FunctionInterceptionAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Invoke();
        }
    }
}
