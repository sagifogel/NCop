using NCop.Aspects.Framework;
using NCop.Aspects.Tests.Extensions;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;

namespace NCop.Aspects.Tests.FunctionWith5RefArgumentsAspect.Subjects
{
    public interface IFunctionWith5RefArgumentsBoundaryAspect
    {
        string InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m);
        string OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m);
        string MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m);
        string InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l, ref int m);
        string MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m);
        string AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m);
        string AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m);
        string AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m);
        string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m);
        string AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m);
        string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m);
    }

    public class Mixin : IFunctionWith5RefArgumentsBoundaryAspect
    {
        private string AddInMethodJoinPoint(ref int i, ref int j, ref int k, ref int l, ref int m) {
            m = l = k = j = i += (int)AspectJoinPoints.InMethod;
            return AspectJoinPoints.InMethod.ToString();
        }

        public string InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
        }

        public string OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
        }

        public string MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
        }

        public string InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l, ref int m) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
        }

        public string MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
        }

        public string AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
        }

        public string AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
        }

        public string AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
        }

        public string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
        }

        public string AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m);
            throw new Exception("InMethodException");
        }

        public string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m);
        }
    }

    [TransientComposite]
    [Mixins(typeof(Mixin))]
    public interface IFunctionWith5RefArgumentsComposite : IFunctionWith5RefArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(FunctionWith5RefArgumentsInterceptionAspect))]
        new string InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m);

        [OnMethodBoundaryAspect(typeof(FunctionWith5RefArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m);

        [OnMethodBoundaryAspect(typeof(FunctionWith5RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith5RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith5RefArgumentsOnMethodBoundaryAspect))]
        new string MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m);

        [MethodInterceptionAspect(typeof(FunctionWith5RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith5RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith5RefArgumentsInterceptionAspect))]
        new string MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m);

        [MethodInterceptionAspect(typeof(FunctionWith5RefArgumentsInterceptionUsinInvokeAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith5RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new string InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l, ref int m);

        [MethodInterceptionAspect(typeof(FunctionWith5RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith5RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m);

        [OnMethodBoundaryAspect(typeof(FunctionWith5RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith5RefArgumentsInterceptionAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m);

        [MethodInterceptionAspect(typeof(FunctionWith5RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith5RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(FunctionWith5RefArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(FunctionWith5RefArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(FunctionWith5RefArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(FunctionWith5RefArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new string AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m);

        [OnMethodBoundaryAspect(typeof(OnEntry_FunctionWith5RefArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m);

        [OnMethodBoundaryAspect(typeof(FunctionWith5RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith5RefArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(FunctionWith5RefArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(FunctionWith5RefArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(FunctionWith5RefArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(FunctionWith5RefArgumentsInterceptionAspect), AspectPriority = 6)]
        new string AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m);

        [OnMethodBoundaryAspect(typeof(FunctionWith5RefArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_FunctionWith5RefArgumentsBoundaryAspect))]
        new string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_FunctionWith5RefArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurFunctionWith5RefArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m);
    }

    public class FunctionWith5RefArgumentsOnMethodBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, int, string> args) {
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, int, int, string> args) {
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnSuccess;
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<int, int, int, int, int, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, int, int, int, int, string> args) {
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class OnEntry_FunctionWith5RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_FunctionWith5RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, int, int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_FunctionWith5RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, int, int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, int, int, int, int, string> args) {
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurFunctionWith5RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, int, int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<int, int, int, int, int, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
                args.AddToReturnValue(AspectJoinPoints.InMethod);
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, int, int, int, int, string> args) {
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class FunctionWith5RefArgumentsInterceptionAspect : FunctionInterceptionAspect<int, int, int, int, int, string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<int, int, int, int, int, string> args) {
            args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnInvoke;
            args.AddToReturnValue(AspectJoinPoints.OnInvoke);
            base.OnInvoke(args);
        }
    }

    public class FunctionWith5RefArgumentsInterceptionUsinInvokeAspect : FunctionInterceptionAspect<int, int, int, int, int, string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<int, int, int, int, int, string> args) {
            args.Invoke();
        }
    }
}
