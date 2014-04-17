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

namespace NCop.Aspects.Tests.FunctionWith4RefArgumentsAspect.Subjects
{
    public interface IFunctionWith4RefArgumentsBoundaryAspect
    {
        string InterceptionAspect(ref int i, ref int j, ref int k, ref int l);
        string OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l);
        string MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l);
        string MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l);
        string AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l);
        string AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l);
        string AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l);
        string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l);
        string AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l);
        string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l);
    }

    public class CSharpDeveloperMixin : IFunctionWith4RefArgumentsBoundaryAspect
    {
        private string AddInMethodJoinPoint(ref int i, ref int j, ref int k, ref int l) {
            l = k = j = i += (int)AspectJoinPoints.InMethod;
            return AspectJoinPoints.InMethod.ToString();
        }

        public string InterceptionAspect(ref int i, ref int j, ref int k, ref int l) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l);
        }

        public string OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l);
        }

        public string MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l);
        }

        public string MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l);
        }

        public string AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l);
        }

        public string AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l);
        }

        public string AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l);
        }

        public string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l);
        }

        public string AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l);
            throw new Exception("InMethodException");
        }

        public string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l);
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IFunctionWith4RefArgumentsComposite : IFunctionWith4RefArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(FunctionWith4RefArgumentsInterceptionAspect))]
        new string InterceptionAspect(ref int i, ref int j, ref int k, ref int l);

        [OnMethodBoundaryAspect(typeof(FunctionWith4RefArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l);

        [OnMethodBoundaryAspect(typeof(FunctionWith4RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith4RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith4RefArgumentsOnMethodBoundaryAspect))]
        new string MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l);

        [MethodInterceptionAspect(typeof(FunctionWith4RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith4RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith4RefArgumentsInterceptionAspect))]
        new string MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l);

        [MethodInterceptionAspect(typeof(FunctionWith4RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith4RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l);

        [OnMethodBoundaryAspect(typeof(FunctionWith4RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith4RefArgumentsInterceptionAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l);

        [MethodInterceptionAspect(typeof(FunctionWith4RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith4RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(FunctionWith4RefArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(FunctionWith4RefArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(FunctionWith4RefArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(FunctionWith4RefArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new string AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l);

        [OnMethodBoundaryAspect(typeof(OnEntry_FunctionWith4RefArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l);

        [OnMethodBoundaryAspect(typeof(FunctionWith4RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith4RefArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(FunctionWith4RefArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(FunctionWith4RefArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(FunctionWith4RefArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(FunctionWith4RefArgumentsInterceptionAspect), AspectPriority = 6)]
        new string AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l);

        [OnMethodBoundaryAspect(typeof(FunctionWith4RefArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_FunctionWith4RefArgumentsBoundaryAspect))]
        new string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_FunctionWith4RefArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurFunctionWith4RefArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l);
    }

    public class FunctionWith4RefArgumentsOnMethodBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, string> args) {
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, int, string> args) {
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnSuccess;
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<int, int, int, int, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, int, int, int, string> args) {
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class OnEntry_FunctionWith4RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_FunctionWith4RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_FunctionWith4RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, int, int, int, string> args) {
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurFunctionWith4RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<int, int, int, int, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
                args.AddToReturnValue(AspectJoinPoints.InMethod);
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, int, int, int, string> args) {
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class FunctionWith4RefArgumentsInterceptionAspect : FunctionInterceptionAspect<int, int, int, int, string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<int, int, int, int, string> args) {
            args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnInvoke;
            args.AddToReturnValue(AspectJoinPoints.OnInvoke);
            base.OnInvoke(args);
        }
    }
}
