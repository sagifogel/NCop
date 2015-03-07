using NCop.Aspects.Framework;
using NCop.Aspects.Tests.Extensions;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;
using System.Collections.Generic;

namespace NCop.Aspects.Tests.FunctionWith4ArgumentsAspect.Subjects
{
    public interface IFunctionWith4ArgumentsBoundaryAspect
    {
        string InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        string OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        string MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        string InterceptionAspectUsingInvoke(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        string MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        string AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        string AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        string AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        string AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
    }

    public class Mixin : IFunctionWith4ArgumentsBoundaryAspect
    {
        private string AddInMethodJoinPoint(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            first.Add(AspectJoinPoints.InMethod);
            second.Add(AspectJoinPoints.InMethod);
            third.Add(AspectJoinPoints.InMethod);
            fourth.Add(AspectJoinPoints.InMethod);

            return AspectJoinPoints.InMethod.ToString();
        }

        public string InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            return AddInMethodJoinPoint(first, second, third, fourth);
        }

        public string OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            return AddInMethodJoinPoint(first, second, third, fourth);
        }

        public string MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            return AddInMethodJoinPoint(first, second, third, fourth);
        }

        public string InterceptionAspectUsingInvoke(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            return AddInMethodJoinPoint(first, second, third, fourth);
        }

        public string MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            return AddInMethodJoinPoint(first, second, third, fourth);
        }

        public string AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            return AddInMethodJoinPoint(first, second, third, fourth);
        }

        public string AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            return AddInMethodJoinPoint(first, second, third, fourth);
        }

        public string AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            return AddInMethodJoinPoint(first, second, third, fourth);
        }

        public string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            return AddInMethodJoinPoint(first, second, third, fourth);
        }

        public string AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            return AddInMethodJoinPoint(first, second, third, fourth);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            AddInMethodJoinPoint(first, second, third, fourth);
            throw new Exception("InMethodException");
        }

        public string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth);
        }
    }

    [TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IFunctionWith4ArgumentsComposite : IFunctionWith4ArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(FunctionWith4ArgumentsInterceptionAspect))]
        new string InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [OnMethodBoundaryAspect(typeof(FunctionWith4ArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [OnMethodBoundaryAspect(typeof(FunctionWith4ArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith4ArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith4ArgumentsOnMethodBoundaryAspect))]
        new string MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [MethodInterceptionAspect(typeof(FunctionWith4ArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith4ArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith4ArgumentsInterceptionAspect))]
        new string MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [MethodInterceptionAspect(typeof(FunctionWith4ArgumentsInterceptionUsinInvokeAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith4ArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new string InterceptionAspectUsingInvoke(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [MethodInterceptionAspect(typeof(FunctionWith4ArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith4ArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [OnMethodBoundaryAspect(typeof(FunctionWith4ArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith4ArgumentsInterceptionAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [MethodInterceptionAspect(typeof(FunctionWith4ArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith4ArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(FunctionWith4ArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(FunctionWith4ArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(FunctionWith4ArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(FunctionWith4ArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new string AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [OnMethodBoundaryAspect(typeof(OnEntry_FunctionWith4ArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [OnMethodBoundaryAspect(typeof(FunctionWith4ArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith4ArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(FunctionWith4ArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(FunctionWith4ArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(FunctionWith4ArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(FunctionWith4ArgumentsInterceptionAspect), AspectPriority = 6)]
        new string AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [OnMethodBoundaryAspect(typeof(FunctionWith4ArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_FunctionWith4ArgumentsBoundaryAspect))]
        new string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_FunctionWith4ArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurFunctionWith4ArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth);
    }

    public class FunctionWith4ArgumentsOnMethodBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
                args.Arg2.Add(AspectJoinPoints.OnException);
                args.Arg3.Add(AspectJoinPoints.OnException);
                args.Arg4.Add(AspectJoinPoints.OnException);
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.Arg3.Add(AspectJoinPoints.OnExit);
            args.Arg4.Add(AspectJoinPoints.OnExit);
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class OnEntry_FunctionWith4ArgumentsBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_FunctionWith4ArgumentsBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_FunctionWith4ArgumentsBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnExit(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.Arg3.Add(AspectJoinPoints.OnExit);
            args.Arg4.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurFunctionWith4ArgumentsBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
                args.Arg2.Add(AspectJoinPoints.OnException);
                args.Arg3.Add(AspectJoinPoints.OnException);
                args.Arg4.Add(AspectJoinPoints.OnException);
                args.AddToReturnValue(AspectJoinPoints.InMethod);
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.Arg3.Add(AspectJoinPoints.OnExit);
            args.Arg4.Add(AspectJoinPoints.OnExit);
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class FunctionWith4ArgumentsInterceptionAspect : FunctionInterceptionAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnInvoke);
            args.Arg2.Add(AspectJoinPoints.OnInvoke);
            args.Arg3.Add(AspectJoinPoints.OnInvoke);
            args.Arg4.Add(AspectJoinPoints.OnInvoke);
            args.AddToReturnValue(AspectJoinPoints.OnInvoke);
            base.OnInvoke(args);
        }
    }

    public class FunctionWith4ArgumentsInterceptionUsinInvokeAspect : FunctionInterceptionAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Invoke();
        }
    }
}
