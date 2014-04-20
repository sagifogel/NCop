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

namespace NCop.Aspects.Tests.FunctionWith8RefArgumentsAspect.Subjects
{
    public interface IFunctionWith8RefArgumentsBoundaryAspect
    {
        string InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        string OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        string MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        string InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        string MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        string AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        string AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        string AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        string AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
    }

    public class CSharpDeveloperMixin : IFunctionWith8RefArgumentsBoundaryAspect
    {
        private string AddInMethodJoinPoint(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            p = o = n = m = l = k = j = i += (int)AspectJoinPoints.InMethod;
            return AspectJoinPoints.InMethod.ToString();
        }

        public string InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public string OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public string MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public string InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public string MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public string AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public string AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public string AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public string AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            return AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            AddInMethodJoinPoint(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
            throw new Exception("InMethodException");
        }

        public string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref i, ref j, ref k, ref l, ref m, ref n, ref o, ref p);
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IFunctionWith8RefArgumentsComposite : IFunctionWith8RefArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(FunctionWith8RefArgumentsInterceptionAspect))]
        new string InterceptionAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [OnMethodBoundaryAspect(typeof(FunctionWith8RefArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [OnMethodBoundaryAspect(typeof(FunctionWith8RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith8RefArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith8RefArgumentsOnMethodBoundaryAspect))]
        new string MultipleOnMethodBoundaryAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [MethodInterceptionAspect(typeof(FunctionWith8RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith8RefArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith8RefArgumentsInterceptionAspect))]
        new string MultipleInterceptionAspects(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [MethodInterceptionAspect(typeof(FunctionWith8RefArgumentsInterceptionUsinInvokeAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith8RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new string InterceptionAspectUsingInvoke(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [MethodInterceptionAspect(typeof(FunctionWith8RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith8RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [OnMethodBoundaryAspect(typeof(FunctionWith8RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith8RefArgumentsInterceptionAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [MethodInterceptionAspect(typeof(FunctionWith8RefArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith8RefArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(FunctionWith8RefArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(FunctionWith8RefArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(FunctionWith8RefArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(FunctionWith8RefArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new string AlternatelAspectsStartingWithInterception(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [OnMethodBoundaryAspect(typeof(OnEntry_FunctionWith8RefArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [OnMethodBoundaryAspect(typeof(FunctionWith8RefArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith8RefArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(FunctionWith8RefArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(FunctionWith8RefArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(FunctionWith8RefArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(FunctionWith8RefArgumentsInterceptionAspect), AspectPriority = 6)]
        new string AlternateAspectsStartingWithOnMethodBoundary(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [OnMethodBoundaryAspect(typeof(FunctionWith8RefArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_FunctionWith8RefArgumentsBoundaryAspect))]
        new string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_FunctionWith8RefArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurFunctionWith8RefArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(ref int i, ref int j, ref int k, ref int l, ref int m, ref int n, ref int o, ref int p);
    }

    public class FunctionWith8RefArgumentsOnMethodBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, int, int, int, int, string> args) {
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, int, int, int, int, int, string> args) {
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnSuccess;
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<int, int, int, int, int, int, int, int, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, int, int, int, int, int, int, int, string> args) {
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class OnEntry_FunctionWith8RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, int, int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_FunctionWith8RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, int, int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, int, int, int, int, int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_FunctionWith8RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, int, int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, int, int, int, int, int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, int, int, int, int, int, int, int, string> args) {
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurFunctionWith8RefArgumentsBoundaryAspect : OnFunctionBoundaryAspect<int, int, int, int, int, int, int, int, string>
    {
        public override void OnEntry(FunctionExecutionArgs<int, int, int, int, int, int, int, int, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnEntry;
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<int, int, int, int, int, int, int, int, string> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<int, int, int, int, int, int, int, int, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnException;
                args.AddToReturnValue(AspectJoinPoints.InMethod);
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<int, int, int, int, int, int, int, int, string> args) {
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnExit;
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class FunctionWith8RefArgumentsInterceptionAspect : FunctionInterceptionAspect<int, int, int, int, int, int, int, int, string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<int, int, int, int, int, int, int, int, string> args) {
            args.Arg8 = args.Arg7 = args.Arg6 = args.Arg5 = args.Arg4 = args.Arg3 = args.Arg2 = args.Arg1 += (int)AspectJoinPoints.OnInvoke;
            args.AddToReturnValue(AspectJoinPoints.OnInvoke);
            base.OnInvoke(args);
        }
    }

    public class FunctionWith8RefArgumentsInterceptionUsinInvokeAspect : FunctionInterceptionAspect<int, int, int, int, int, int, int, int, string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<int, int, int, int, int, int, int, int, string> args) {
            args.Invoke();
        }
    }
}
