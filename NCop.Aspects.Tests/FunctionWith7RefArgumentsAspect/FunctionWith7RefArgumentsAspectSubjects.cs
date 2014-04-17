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

namespace NCop.Aspects.Tests.FunctionWith7RefArgumentsAspect.Subjects
{
    public interface IFunctionWith7RefArgumentsBoundaryAspect
    {
        string InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        string OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        string MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        string MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        string AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        string AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        string AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        string AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
    }

    public class CSharpDeveloperMixin : IFunctionWith7RefArgumentsBoundaryAspect
    {
        private string AddInMethodJoinPoint(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            o = n = m = l = k = j = i += (int)AspectJoinPoints.InMethod;
            return AspectJoinPoints.InMethod.ToString();
        }

        public string InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public string OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public string MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public string MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public string AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public string AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public string AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public string AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
            throw new Exception("InMethodException");
        }

        public string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n, ref o);
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IFunctionWith7RefArgumentsComposite : IFunctionWith7RefArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(FunctionWith7RefArgumentsInterceptionAspect))]
        new string InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [OnMethodBoundaryAspect(typeof(FunctionWith7RefArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [OnMethodBoundaryAspect(typeof(FunctionWith7RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith7RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith7RefArgumentsOnMethodBoundaryAspect))]
        new string MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [MethodInterceptionAspect(typeof(FunctionWith7RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith7RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith7RefArgumentsInterceptionAspect))]
        new string MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [MethodInterceptionAspect(typeof(FunctionWith7RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith7RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [OnMethodBoundaryAspect(typeof(FunctionWith7RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith7RefArgumentsInterceptionAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [MethodInterceptionAspect(typeof(FunctionWith7RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith7RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(FunctionWith7RefArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(FunctionWith7RefArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(FunctionWith7RefArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(FunctionWith7RefArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new string AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [OnMethodBoundaryAspect(typeof(OnEntry_FunctionWith7RefArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [OnMethodBoundaryAspect(typeof(FunctionWith7RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith7RefArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(FunctionWith7RefArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(FunctionWith7RefArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(FunctionWith7RefArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(FunctionWith7RefArgumentsInterceptionAspect), AspectPriority = 6)]
        new string AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [OnMethodBoundaryAspect(typeof(FunctionWith7RefArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_FunctionWith7RefArgumentsBoundaryAspect))]
        new string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_FunctionWith7RefArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurFunctionWith7RefArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o);
    }

    public class FunctionWith7RefArgumentsOnMethodBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, int, int, int, string> args) {
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, int, int, int, int, string> args) {
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnSuccess;
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<int, int, int, int, int, int, int, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, int, int, int, int, int, int, string> args) {
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class OnEntry_FunctionWith7RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_FunctionWith7RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, int, int, int, int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_FunctionWith7RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, int, int, int, int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, int, int, int, int, int, int, string> args) {
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurFunctionWith7RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, int, int, int, int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<int, int, int, int, int, int, int, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
                args.AddToReturnValue(AspectJoinPoints.InMethod);
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, int, int, int, int, int, int, string> args) {
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class FunctionWith7RefArgumentsInterceptionAspect : FunctionInterceptionAspect<int, int, int, int, int, int, int, string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<int, int, int, int, int, int, int, string> args) {
            args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnInvoke;
            args.AddToReturnValue(AspectJoinPoints.OnInvoke);
            base.OnInvoke(args);
        }
    }
}
