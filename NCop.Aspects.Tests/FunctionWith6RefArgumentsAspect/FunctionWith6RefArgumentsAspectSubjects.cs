using NCop.Aspects.Framework;
using NCop.Aspects.Tests.Extensions;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;

namespace NCop.Aspects.Tests.FunctionWith6RefArgumentsAspect.Subjects
{
    public interface IFunctionWith6RefArgumentsBoundaryAspect
    {
        string InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        string OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        string MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        string InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        string MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        string AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        string AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        string AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        string AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
    }

    public class CSharpDeveloperMixin : IFunctionWith6RefArgumentsBoundaryAspect
    {
        private string AddInMethodJoinPoint(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            n = m = l = k = j = i += (int)AspectJoinPoints.InMethod;
            return AspectJoinPoints.InMethod.ToString();
        }

        public string InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public string OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public string MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public string InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public string MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public string AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public string AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public string AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public string AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n);
            throw new Exception("InMethodException");
        }

        public string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n);
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IFunctionWith6RefArgumentsComposite : IFunctionWith6RefArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(FunctionWith6RefArgumentsInterceptionAspect))]
        new string InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [OnMethodBoundaryAspect(typeof(FunctionWith6RefArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [OnMethodBoundaryAspect(typeof(FunctionWith6RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith6RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith6RefArgumentsOnMethodBoundaryAspect))]
        new string MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [MethodInterceptionAspect(typeof(FunctionWith6RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith6RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith6RefArgumentsInterceptionAspect))]
        new string MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [MethodInterceptionAspect(typeof(FunctionWith6RefArgumentsInterceptionUsinInvokeAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith6RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new string InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [MethodInterceptionAspect(typeof(FunctionWith6RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith6RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [OnMethodBoundaryAspect(typeof(FunctionWith6RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith6RefArgumentsInterceptionAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [MethodInterceptionAspect(typeof(FunctionWith6RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith6RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(FunctionWith6RefArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(FunctionWith6RefArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(FunctionWith6RefArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(FunctionWith6RefArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new string AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [OnMethodBoundaryAspect(typeof(OnEntry_FunctionWith6RefArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [OnMethodBoundaryAspect(typeof(FunctionWith6RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith6RefArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(FunctionWith6RefArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(FunctionWith6RefArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(FunctionWith6RefArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(FunctionWith6RefArgumentsInterceptionAspect), AspectPriority = 6)]
        new string AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [OnMethodBoundaryAspect(typeof(FunctionWith6RefArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_FunctionWith6RefArgumentsBoundaryAspect))]
        new string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_FunctionWith6RefArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurFunctionWith6RefArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n);
    }

    public class FunctionWith6RefArgumentsOnMethodBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, int, int, string> args) {
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, int, int, int, string> args) {
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnSuccess;
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<int, int, int, int, int, int, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, int, int, int, int, int, string> args) {
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class OnEntry_FunctionWith6RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_FunctionWith6RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, int, int, int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_FunctionWith6RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, int, int, int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, int, int, int, int, int, string> args) {
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurFunctionWith6RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, int, int, int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<int, int, int, int, int, int, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
                args.AddToReturnValue(AspectJoinPoints.InMethod);
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, int, int, int, int, int, string> args) {
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class FunctionWith6RefArgumentsInterceptionAspect : FunctionInterceptionAspect<int, int, int, int, int, int, string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<int, int, int, int, int, int, string> args) {
            args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnInvoke;
            args.AddToReturnValue(AspectJoinPoints.OnInvoke);
            base.OnInvoke(args);
        }
    }

    public class FunctionWith6RefArgumentsInterceptionUsinInvokeAspect : FunctionInterceptionAspect<int, int, int, int, int, int, string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<int, int, int, int, int, int, string> args) {
            args.Invoke();
        }
    }
}
