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

namespace NCop.Aspects.Tests.FunctionWith2RefArgumentsAspect.Subjects
{
    public interface IFunctionWith2RefArgumentsBoundaryAspect
    {
        string InterceptionAspect(ref int i, ref int j);
        string OnMethodBoundaryAspect(ref int i, ref int j);
        string MultipleInterceptionAspects(ref int i, ref int j);
        string MultipleOnMethodBoundaryAspects(ref int i, ref int j);
        string AllAspectsStartingWithInterception(ref int i, ref int j);
        string AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j);
        string AlternatelAspectsStartingWithInterception(ref int i, ref int j);
        string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j);
        string AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j);
        string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j);
    }

    public class CSharpDeveloperMixin : IFunctionWith2RefArgumentsBoundaryAspect
    {
        private string AddInMethodJoinPoint(ref int i, ref int j) {
            j = i += (int)AspectJoinPoints.InMethod;
            return AspectJoinPoints.InMethod.ToString();
        }

        public string InterceptionAspect(ref int i, ref int j) {
            return AddInMethodJoinPoint(ref i, ref j);
        }

        public string OnMethodBoundaryAspect(ref int i, ref int j) {
            return AddInMethodJoinPoint(ref i, ref j);
        }

        public string MultipleInterceptionAspects(ref int i, ref int j) {
            return AddInMethodJoinPoint(ref i, ref j);
        }

        public string MultipleOnMethodBoundaryAspects(ref int i, ref int j) {
            return AddInMethodJoinPoint(ref i, ref j);
        }

        public string AllAspectsStartingWithInterception(ref int i, ref int j) {
            return AddInMethodJoinPoint(ref i, ref j);
        }

        public string AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j) {
            return AddInMethodJoinPoint(ref i, ref j);
        }

        public string AlternatelAspectsStartingWithInterception(ref int i, ref int j) {
            return AddInMethodJoinPoint(ref i, ref j);
        }

        public string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j) {
            return AddInMethodJoinPoint(ref i, ref j);
        }

        public string AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j) {
            return AddInMethodJoinPoint(ref i, ref j);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j) {
            AddInMethodJoinPoint(ref i, ref j);
            throw new Exception("InMethodException");
        }

        public string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j);
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IFunctionWith2RefArgumentsComposite : IFunctionWith2RefArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(FunctionWith2RefArgumentsInterceptionAspect))]
        new string InterceptionAspect(ref int i, ref int j);

        [OnMethodBoundaryAspect(typeof(FunctionWith2RefArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspect(ref int i, ref int j);

        [OnMethodBoundaryAspect(typeof(FunctionWith2RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith2RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith2RefArgumentsOnMethodBoundaryAspect))]
        new string MultipleOnMethodBoundaryAspects(ref int i, ref int j);

        [MethodInterceptionAspect(typeof(FunctionWith2RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith2RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith2RefArgumentsInterceptionAspect))]
        new string MultipleInterceptionAspects(ref int i, ref int j);

        [MethodInterceptionAspect(typeof(FunctionWith2RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith2RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithInterception(ref int i, ref int j);

        [OnMethodBoundaryAspect(typeof(FunctionWith2RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith2RefArgumentsInterceptionAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j);

        [MethodInterceptionAspect(typeof(FunctionWith2RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith2RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(FunctionWith2RefArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(FunctionWith2RefArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(FunctionWith2RefArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(FunctionWith2RefArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new string AlternatelAspectsStartingWithInterception(ref int i, ref int j);

        [OnMethodBoundaryAspect(typeof(OnEntry_FunctionWith2RefArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j);

        [OnMethodBoundaryAspect(typeof(FunctionWith2RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith2RefArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(FunctionWith2RefArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(FunctionWith2RefArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(FunctionWith2RefArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(FunctionWith2RefArgumentsInterceptionAspect), AspectPriority = 6)]
        new string AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j);

        [OnMethodBoundaryAspect(typeof(FunctionWith2RefArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_FunctionWith2RefArgumentsBoundaryAspect))]
        new string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_FunctionWith2RefArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurFunctionWith2RefArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j);
    }

    public class FunctionWith2RefArgumentsOnMethodBoundaryAspect : OnFunctionBoundaryAspect<int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, string> args) {
            args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, string> args) {
            args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnSuccess;
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<int, int, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, int, string> args) {
            args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class OnEntry_FunctionWith2RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_FunctionWith2RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_FunctionWith2RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, int, string> args) {
            args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurFunctionWith2RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<int, int, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
                args.AddToReturnValue(AspectJoinPoints.InMethod);
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, int, string> args) {
            args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class FunctionWith2RefArgumentsInterceptionAspect : FunctionInterceptionAspect<int, int, string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<int, int, string> args) {
            args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnInvoke;
            args.AddToReturnValue(AspectJoinPoints.OnInvoke);
            base.OnInvoke(args);
        }
    }
}
