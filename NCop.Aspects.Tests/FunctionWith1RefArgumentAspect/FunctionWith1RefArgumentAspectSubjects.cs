using NCop.Aspects.Framework;
using NCop.Aspects.Tests.Extensions;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;

namespace NCop.Aspects.Tests.FunctionWith1RefArgumentAspect.Subjects
{
    public interface IFunctionWith1RefArgumentBoundaryAspect
    {
        string InterceptionAspect(ref int i);
        string OnMethodBoundaryAspect(ref int i);
        string MultipleInterceptionAspects(ref int i);
        string InterceptionAspectUsingInvoke(ref int i);
        string MultipleOnMethodBoundaryAspects(ref int i);
        string AllAspectsStartingWithInterception(ref int i);
        string AllAspectsStartingWithOnMethodBoundary(ref int i);
        string AlternatelAspectsStartingWithInterception(ref int i);
        string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i);
        string AlternateAspectsStartingWithOnMethodBoundary(ref int i);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i);
        string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i);
    }

    public class Mixin : IFunctionWith1RefArgumentBoundaryAspect
    {
        private string AddInMethodJoinPoint(ref int i) {
            i += (int)AspectJoinPoints.InMethod;
            return AspectJoinPoints.InMethod.ToString();
        }

        public string InterceptionAspect(ref int i) {
            return AddInMethodJoinPoint(ref i);
        }

        public string OnMethodBoundaryAspect(ref int i) {
            return AddInMethodJoinPoint(ref i);
        }

        public string MultipleInterceptionAspects(ref int i) {
            return AddInMethodJoinPoint(ref i);
        }

        public string InterceptionAspectUsingInvoke(ref int i) {
            return AddInMethodJoinPoint(ref i);
        }

        public string MultipleOnMethodBoundaryAspects(ref int i) {
            return AddInMethodJoinPoint(ref i);
        }

        public string AllAspectsStartingWithInterception(ref int i) {
            return AddInMethodJoinPoint(ref i);
        }

        public string AllAspectsStartingWithOnMethodBoundary(ref int i) {
            return AddInMethodJoinPoint(ref i);
        }

        public string AlternatelAspectsStartingWithInterception(ref int i) {
            return AddInMethodJoinPoint(ref i);
        }

        public string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i) {
            return AddInMethodJoinPoint(ref i);
        }

        public string AlternateAspectsStartingWithOnMethodBoundary(ref int i) {
            return AddInMethodJoinPoint(ref i);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i) {
            AddInMethodJoinPoint(ref i);
            throw new Exception("InMethodException");
        }

        public string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i);
        }
    }

    [TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IFunctionWith1RefArgumentComposite : IFunctionWith1RefArgumentBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(FunctionWith1RefArgumentInterceptionAspect))]
        new string InterceptionAspect(ref int i);

        [OnMethodBoundaryAspect(typeof(FunctionWith1RefArgumentOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspect(ref int i);

        [OnMethodBoundaryAspect(typeof(FunctionWith1RefArgumentOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith1RefArgumentOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith1RefArgumentOnMethodBoundaryAspect))]
        new string MultipleOnMethodBoundaryAspects(ref int i);

        [MethodInterceptionAspect(typeof(FunctionWith1RefArgumentInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith1RefArgumentInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith1RefArgumentInterceptionAspect))]
        new string MultipleInterceptionAspects(ref int i);

        [MethodInterceptionAspect(typeof(FunctionWith1RefArgumentInterceptionUsinInvokeAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith1RefArgumentOnMethodBoundaryAspect), AspectPriority = 2)]
        new string InterceptionAspectUsingInvoke(ref int i);

        [MethodInterceptionAspect(typeof(FunctionWith1RefArgumentInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith1RefArgumentOnMethodBoundaryAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithInterception(ref int i);

        [OnMethodBoundaryAspect(typeof(FunctionWith1RefArgumentOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith1RefArgumentInterceptionAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithOnMethodBoundary(ref int i);

        [MethodInterceptionAspect(typeof(FunctionWith1RefArgumentInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith1RefArgumentOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(FunctionWith1RefArgumentInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(FunctionWith1RefArgumentOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(FunctionWith1RefArgumentInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(FunctionWith1RefArgumentOnMethodBoundaryAspect), AspectPriority = 6)]
        new string AlternatelAspectsStartingWithInterception(ref int i);

        [OnMethodBoundaryAspect(typeof(OnEntry_FunctionWith1RefArgumentBoundaryAspect))]
        new string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i);

        [OnMethodBoundaryAspect(typeof(FunctionWith1RefArgumentOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith1RefArgumentInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(FunctionWith1RefArgumentOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(FunctionWith1RefArgumentInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(FunctionWith1RefArgumentOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(FunctionWith1RefArgumentInterceptionAspect), AspectPriority = 6)]
        new string AlternateAspectsStartingWithOnMethodBoundary(ref int i);

        [OnMethodBoundaryAspect(typeof(FunctionWith1RefArgumentOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_FunctionWith1RefArgumentBoundaryAspect))]
        new string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_FunctionWith1RefArgumentBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurFunctionWith1RefArgumentBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i);
    }

    public class FunctionWith1RefArgumentOnMethodBoundaryAspect : OnFunctionBoundaryAspect<int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, string> args) {
            args.Arg1 += (int)AspectJoinPoints.OnEntry;
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, string> args) {
            args.Arg1 += (int)AspectJoinPoints.OnSuccess;
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<int, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1 += (int)AspectJoinPoints.OnException;
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, string> args) {
            args.Arg1 += (int)AspectJoinPoints.OnExit;
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class OnEntry_FunctionWith1RefArgumentBoundaryAspect : OnFunctionBoundaryAspect<int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_FunctionWith1RefArgumentBoundaryAspect : OnFunctionBoundaryAspect<int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_FunctionWith1RefArgumentBoundaryAspect : OnFunctionBoundaryAspect<int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, string> args) {
            args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurFunctionWith1RefArgumentBoundaryAspect : OnFunctionBoundaryAspect<int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1 += (int)AspectJoinPoints.OnEntry;
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<int, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1 += (int)AspectJoinPoints.OnException;
                args.AddToReturnValue(AspectJoinPoints.InMethod);
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, string> args) {
            args.Arg1 += (int)AspectJoinPoints.OnExit;
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class FunctionWith1RefArgumentInterceptionAspect : FunctionInterceptionAspect<int, string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<int, string> args) {
            args.Arg1 += (int)AspectJoinPoints.OnInvoke;
            args.AddToReturnValue(AspectJoinPoints.OnInvoke);
            base.OnInvoke(args);
        }
    }

    public class FunctionWith1RefArgumentInterceptionUsinInvokeAspect : FunctionInterceptionAspect<int, string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<int, string> args) {
            args.Invoke();
        }
    }
}
