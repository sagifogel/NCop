using NCop.Aspects.Framework;
using NCop.Aspects.Tests.Extensions;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Tests.FunctionWith6ArgumentsAspect.Subjects
{
    public interface IFunctionWith6ArgumentsBoundaryAspect
    {
        string InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);
        string OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);
        string MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);
        string InterceptionAspectUsingInvoke(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);
        string MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);
        string AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);
        string AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);
        string AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);
        string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);
        string AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);
        string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);        
    }

    public class Mixin : IFunctionWith6ArgumentsBoundaryAspect
    {
        private string AddInMethodJoinPoint(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth) {
            first.Add(AspectJoinPoints.InMethod);
            second.Add(AspectJoinPoints.InMethod);
            third.Add(AspectJoinPoints.InMethod);
            fourth.Add(AspectJoinPoints.InMethod);
            fifth.Add(AspectJoinPoints.InMethod);
            sixth.Add(AspectJoinPoints.InMethod);

            return AspectJoinPoints.InMethod.ToString();
        }

        public string InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth) {
            return AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth);
        }

        public string OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth) {
            return AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth);
        }

        public string MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth) {
            return AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth);
        }

        public string InterceptionAspectUsingInvoke(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth) {
            return AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth);
        }

        public string MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth) {
            return AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth);
        }

        public string AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth) {
            return AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth);
        }

        public string AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth) {
            return AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth);
        }

        public string AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth) {
            return AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth);
        }

        public string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth) {
            return AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth);
        }

        public string AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth) {
            return AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth);
            throw new Exception("InMethodException");
        }

        public string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth, fifth, sixth);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth, fifth, sixth);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth, fifth, sixth);
        }
    }

    [TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IFunctionWith6ArgumentsComposite : IFunctionWith6ArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(FunctionWith6ArgumentsInterceptionAspect))]
        new string InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);

        [OnMethodBoundaryAspect(typeof(FunctionWith6ArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);

        [OnMethodBoundaryAspect(typeof(FunctionWith6ArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith6ArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith6ArgumentsOnMethodBoundaryAspect))]
        new string MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);

        [MethodInterceptionAspect(typeof(FunctionWith6ArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith6ArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith6ArgumentsInterceptionAspect))]
        new string MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);

        [MethodInterceptionAspect(typeof(FunctionWith6ArgumentsInterceptionUsinInvokeAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith6ArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new string InterceptionAspectUsingInvoke(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);

        [MethodInterceptionAspect(typeof(FunctionWith6ArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith6ArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);

        [OnMethodBoundaryAspect(typeof(FunctionWith6ArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith6ArgumentsInterceptionAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);

        [MethodInterceptionAspect(typeof(FunctionWith6ArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith6ArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(FunctionWith6ArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(FunctionWith6ArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(FunctionWith6ArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(FunctionWith6ArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new string AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);

        [OnMethodBoundaryAspect(typeof(OnEntry_FunctionWith6ArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);

        [OnMethodBoundaryAspect(typeof(FunctionWith6ArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith6ArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(FunctionWith6ArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(FunctionWith6ArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(FunctionWith6ArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(FunctionWith6ArgumentsInterceptionAspect), AspectPriority = 6)]
        new string AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);

        [OnMethodBoundaryAspect(typeof(FunctionWith6ArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_FunctionWith6ArgumentsBoundaryAspect))]
        new string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_FunctionWith6ArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurFunctionWith6ArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth);
    }

    public class FunctionWith6ArgumentsOnMethodBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.Arg5.Add(AspectJoinPoints.OnEntry);
            args.Arg6.Add(AspectJoinPoints.OnEntry);
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            args.Arg5.Add(AspectJoinPoints.OnSuccess);
            args.Arg6.Add(AspectJoinPoints.OnSuccess);
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
                args.Arg2.Add(AspectJoinPoints.OnException);
                args.Arg3.Add(AspectJoinPoints.OnException);
                args.Arg4.Add(AspectJoinPoints.OnException);
                args.Arg5.Add(AspectJoinPoints.OnException);
                args.Arg6.Add(AspectJoinPoints.OnException);
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.Arg3.Add(AspectJoinPoints.OnExit);
            args.Arg4.Add(AspectJoinPoints.OnExit);
            args.Arg5.Add(AspectJoinPoints.OnExit);
            args.Arg6.Add(AspectJoinPoints.OnExit);
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class OnEntry_FunctionWith6ArgumentsBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.Arg5.Add(AspectJoinPoints.OnEntry);
            args.Arg6.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_FunctionWith6ArgumentsBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.Arg5.Add(AspectJoinPoints.OnEntry);
            args.Arg6.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            args.Arg5.Add(AspectJoinPoints.OnSuccess);
            args.Arg6.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_FunctionWith6ArgumentsBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.Arg5.Add(AspectJoinPoints.OnEntry);
            args.Arg6.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            args.Arg5.Add(AspectJoinPoints.OnSuccess);
            args.Arg6.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnExit(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.Arg3.Add(AspectJoinPoints.OnExit);
            args.Arg4.Add(AspectJoinPoints.OnExit);
            args.Arg5.Add(AspectJoinPoints.OnExit);
            args.Arg6.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurFunctionWith6ArgumentsBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.Arg5.Add(AspectJoinPoints.OnEntry);
            args.Arg6.Add(AspectJoinPoints.OnEntry);
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            args.Arg5.Add(AspectJoinPoints.OnSuccess);
            args.Arg6.Add(AspectJoinPoints.OnSuccess);
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
                args.Arg2.Add(AspectJoinPoints.OnException);
                args.Arg3.Add(AspectJoinPoints.OnException);
                args.Arg4.Add(AspectJoinPoints.OnException);
                args.Arg5.Add(AspectJoinPoints.OnException);
                args.Arg6.Add(AspectJoinPoints.OnException);
                args.AddToReturnValue(AspectJoinPoints.InMethod);
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.Arg3.Add(AspectJoinPoints.OnExit);
            args.Arg4.Add(AspectJoinPoints.OnExit);
            args.Arg5.Add(AspectJoinPoints.OnExit);
            args.Arg6.Add(AspectJoinPoints.OnExit);
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class FunctionWith6ArgumentsInterceptionAspect : FunctionInterceptionAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnInvoke);
            args.Arg2.Add(AspectJoinPoints.OnInvoke);
            args.Arg3.Add(AspectJoinPoints.OnInvoke);
            args.Arg4.Add(AspectJoinPoints.OnInvoke);
            args.Arg5.Add(AspectJoinPoints.OnInvoke);
            args.Arg6.Add(AspectJoinPoints.OnInvoke);
            args.AddToReturnValue(AspectJoinPoints.OnInvoke);
            base.OnInvoke(args);
        }
    }

    public class FunctionWith6ArgumentsInterceptionUsinInvokeAspect : FunctionInterceptionAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Invoke();
        }
    }
}
