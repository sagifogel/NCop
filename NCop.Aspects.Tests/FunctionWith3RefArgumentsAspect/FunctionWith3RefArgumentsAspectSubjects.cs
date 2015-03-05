using NCop.Aspects.Framework;
using NCop.Aspects.Tests.Extensions;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using System;

namespace NCop.Aspects.Tests.FunctionWith3RefArgumentsAspect.Subjects
{
    public interface IFunctionWith3RefArgumentsBoundaryAspect
    {
        string InterceptionAspect(ref int i, ref int j, ref int k);
        string OnMethodBoundaryAspect(ref int i, ref int j, ref int k);
        string MultipleInterceptionAspects(ref int i, ref int j, ref int k);
        string InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k);
        string MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k);
        string AllAspectsStartingWithInterception(ref int i, ref int j, ref int k);
        string AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k);
        string AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k);
        string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k);
        string AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k);
        string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k);
    }

    public class CSharpDeveloperMixin : IFunctionWith3RefArgumentsBoundaryAspect
    {
        private string AddInMethodJoinPoint(ref int i, ref int j, ref int k) {
            k = j = i += (int)AspectJoinPoints.InMethod;
            return AspectJoinPoints.InMethod.ToString();
        }

        public string InterceptionAspect(ref int i, ref int j, ref int k) {
            return AddInMethodJoinPoint(ref i, ref j, ref k);
        }

        public string OnMethodBoundaryAspect(ref int i, ref int j, ref int k) {
            return AddInMethodJoinPoint(ref i, ref j, ref k);
        }

        public string InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k) {
            return AddInMethodJoinPoint(ref i, ref j, ref k);
        }

        public string MultipleInterceptionAspects(ref int i, ref int j, ref int k) {
            return AddInMethodJoinPoint(ref i, ref j, ref k);
        }

        public string MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k) {
            return AddInMethodJoinPoint(ref i, ref j, ref k);
        }

        public string AllAspectsStartingWithInterception(ref int i, ref int j, ref int k) {
            return AddInMethodJoinPoint(ref i, ref j, ref k);
        }

        public string AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k) {
            return AddInMethodJoinPoint(ref i, ref j, ref k);
        }

        public string AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k) {
            return AddInMethodJoinPoint(ref i, ref j, ref k);
        }

        public string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k) {
            return AddInMethodJoinPoint(ref i, ref j, ref k);
        }

        public string AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k) {
            return AddInMethodJoinPoint(ref i, ref j, ref k);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k) {
            AddInMethodJoinPoint(ref i, ref j, ref k);
            throw new Exception("InMethodException");
        }

        public string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k);
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IFunctionWith3RefArgumentsComposite : IFunctionWith3RefArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(FunctionWith3RefArgumentsInterceptionAspect))]
        new string InterceptionAspect(ref int i, ref int j, ref int k);

        [OnMethodBoundaryAspect(typeof(FunctionWith3RefArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspect(ref int i, ref int j, ref int k);

        [OnMethodBoundaryAspect(typeof(FunctionWith3RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith3RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith3RefArgumentsOnMethodBoundaryAspect))]
        new string MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k);

        [MethodInterceptionAspect(typeof(FunctionWith3RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith3RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith3RefArgumentsInterceptionAspect))]
        new string MultipleInterceptionAspects(ref int i, ref int j, ref int k);

        [MethodInterceptionAspect(typeof(FunctionWith3RefArgumentsInterceptionUsinInvokeAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith3RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new string InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k);

        [MethodInterceptionAspect(typeof(FunctionWith3RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith3RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithInterception(ref int i, ref int j, ref int k);

        [OnMethodBoundaryAspect(typeof(FunctionWith3RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith3RefArgumentsInterceptionAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k);

        [MethodInterceptionAspect(typeof(FunctionWith3RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith3RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(FunctionWith3RefArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(FunctionWith3RefArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(FunctionWith3RefArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(FunctionWith3RefArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new string AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k);

        [OnMethodBoundaryAspect(typeof(OnEntry_FunctionWith3RefArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k);

        [OnMethodBoundaryAspect(typeof(FunctionWith3RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith3RefArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(FunctionWith3RefArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(FunctionWith3RefArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(FunctionWith3RefArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(FunctionWith3RefArgumentsInterceptionAspect), AspectPriority = 6)]
        new string AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k);

        [OnMethodBoundaryAspect(typeof(FunctionWith3RefArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_FunctionWith3RefArgumentsBoundaryAspect))]
        new string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_FunctionWith3RefArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurFunctionWith3RefArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k);
    }

    public class FunctionWith3RefArgumentsOnMethodBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, string> args) {
            args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, string> args) {
            args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnSuccess;
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<int, int, int, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, int, int, string> args) {
            args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class OnEntry_FunctionWith3RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_FunctionWith3RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_FunctionWith3RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, int, int, string> args) {
            args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurFunctionWith3RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<int, int, int, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
                args.AddToReturnValue(AspectJoinPoints.InMethod);
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, int, int, string> args) {
            args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class FunctionWith3RefArgumentsInterceptionAspect : FunctionInterceptionAspect<int, int, int, string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<int, int, int, string> args) {
            args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnInvoke;
            args.AddToReturnValue(AspectJoinPoints.OnInvoke);
            base.OnInvoke(args);
        }
    }

    public class FunctionWith3RefArgumentsInterceptionUsinInvokeAspect : FunctionInterceptionAspect<int, int, int, string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<int, int, int, string> args) {
            args.Invoke();
        }
    }
}
