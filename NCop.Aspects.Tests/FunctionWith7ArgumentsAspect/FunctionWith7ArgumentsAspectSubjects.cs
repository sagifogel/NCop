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

namespace NCop.Aspects.Tests.FunctionWith7ArgumentsAspect.Subjects
{
    public interface IFunctionWith7ArgumentsBoundaryAspect
    {
        string InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);
        string OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);
        string MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);
        string MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);
        string AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);
        string AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);
        string AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);
        string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);
        string AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);
        string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);
    }

    public class CSharpDeveloperMixin : IFunctionWith7ArgumentsBoundaryAspect
    {
        private string AddInMethodJoinPoint(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh) {
            first.Add(AspectJoinPoints.InMethod);
            second.Add(AspectJoinPoints.InMethod);
            third.Add(AspectJoinPoints.InMethod);
            fourth.Add(AspectJoinPoints.InMethod);
            fifth.Add(AspectJoinPoints.InMethod);
            sixth.Add(AspectJoinPoints.InMethod);
            seventh.Add(AspectJoinPoints.InMethod);

            return AspectJoinPoints.InMethod.ToString();
        }

        public string InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh) {
            return AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth, seventh);
        }

        public string OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh) {
            return AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth, seventh);
        }

        public string MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh) {
            return AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth, seventh);
        }

        public string MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh) {
            return AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth, seventh);
        }

        public string AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh) {
            return AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth, seventh);
        }

        public string AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh) {
            return AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth, seventh);
        }

        public string AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh) {
            return AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth, seventh);
        }

        public string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh) {
            return AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth, seventh);
        }

        public string AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh) {
            return AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth, seventh);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh) {
            AddInMethodJoinPoint(first, second, third, fourth, fifth, sixth, seventh);
            throw new Exception("InMethodException");
        }

        public string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth, fifth, sixth, seventh);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth, fifth, sixth, seventh);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(first, second, third, fourth, fifth, sixth, seventh);
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IFunctionWith7ArgumentsComposite : IFunctionWith7ArgumentsBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(FunctionWith7ArgumentsInterceptionAspect))]
        new string InterceptionAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);

        [OnMethodBoundaryAspect(typeof(FunctionWith7ArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);

        [OnMethodBoundaryAspect(typeof(FunctionWith7ArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith7ArgumentsOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith7ArgumentsOnMethodBoundaryAspect))]
        new string MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);

        [MethodInterceptionAspect(typeof(FunctionWith7ArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith7ArgumentsInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith7ArgumentsInterceptionAspect))]
        new string MultipleInterceptionAspects(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);

        [MethodInterceptionAspect(typeof(FunctionWith7ArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith7ArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);

        [OnMethodBoundaryAspect(typeof(FunctionWith7ArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith7ArgumentsInterceptionAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);

        [MethodInterceptionAspect(typeof(FunctionWith7ArgumentsInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith7ArgumentsOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(FunctionWith7ArgumentsInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(FunctionWith7ArgumentsOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(FunctionWith7ArgumentsInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(FunctionWith7ArgumentsOnMethodBoundaryAspect), AspectPriority = 6)]
        new string AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);

        [OnMethodBoundaryAspect(typeof(OnEntry_FunctionWith7ArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectWithOnlyOnEntryAdvide(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);

        [OnMethodBoundaryAspect(typeof(FunctionWith7ArgumentsOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith7ArgumentsInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(FunctionWith7ArgumentsOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(FunctionWith7ArgumentsInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(FunctionWith7ArgumentsOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(FunctionWith7ArgumentsInterceptionAspect), AspectPriority = 6)]
        new string AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);

        [OnMethodBoundaryAspect(typeof(FunctionWith7ArgumentsOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_OnExit_FunctionWith7ArgumentsBoundaryAspect))]
        new string TryfinallyOnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);

        [OnMethodBoundaryAspect(typeof(OnEntry_OnSuccess_FunctionWith7ArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplWithoutTryFinally(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurFunctionWith7ArgumentsBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> first, List<AspectJoinPoints> second, List<AspectJoinPoints> third, List<AspectJoinPoints> fourth, List<AspectJoinPoints> fifth, List<AspectJoinPoints> sixth, List<AspectJoinPoints> seventh);
    }

    public class FunctionWith7ArgumentsOnMethodBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.Arg5.Add(AspectJoinPoints.OnEntry);
            args.Arg6.Add(AspectJoinPoints.OnEntry);
            args.Arg7.Add(AspectJoinPoints.OnEntry);
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            args.Arg5.Add(AspectJoinPoints.OnSuccess);
            args.Arg6.Add(AspectJoinPoints.OnSuccess);
            args.Arg7.Add(AspectJoinPoints.OnSuccess);
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
                args.Arg2.Add(AspectJoinPoints.OnException);
                args.Arg3.Add(AspectJoinPoints.OnException);
                args.Arg4.Add(AspectJoinPoints.OnException);
                args.Arg5.Add(AspectJoinPoints.OnException);
                args.Arg6.Add(AspectJoinPoints.OnException);
                args.Arg7.Add(AspectJoinPoints.OnException);
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.Arg3.Add(AspectJoinPoints.OnExit);
            args.Arg4.Add(AspectJoinPoints.OnExit);
            args.Arg5.Add(AspectJoinPoints.OnExit);
            args.Arg6.Add(AspectJoinPoints.OnExit);
            args.Arg7.Add(AspectJoinPoints.OnExit);
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class OnEntry_FunctionWith7ArgumentsBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.Arg5.Add(AspectJoinPoints.OnEntry);
            args.Arg6.Add(AspectJoinPoints.OnEntry);
            args.Arg7.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }
    }

    public class OnEntry_OnSuccess_FunctionWith7ArgumentsBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.Arg5.Add(AspectJoinPoints.OnEntry);
            args.Arg6.Add(AspectJoinPoints.OnEntry);
            args.Arg7.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            args.Arg5.Add(AspectJoinPoints.OnSuccess);
            args.Arg6.Add(AspectJoinPoints.OnSuccess);
            args.Arg7.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }
    }

    public class OnEntry_OnSuccess_OnExit_FunctionWith7ArgumentsBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.Arg5.Add(AspectJoinPoints.OnEntry);
            args.Arg6.Add(AspectJoinPoints.OnEntry);
            args.Arg7.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            args.Arg5.Add(AspectJoinPoints.OnSuccess);
            args.Arg6.Add(AspectJoinPoints.OnSuccess);
            args.Arg7.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnExit(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.Arg3.Add(AspectJoinPoints.OnExit);
            args.Arg4.Add(AspectJoinPoints.OnExit);
            args.Arg5.Add(AspectJoinPoints.OnExit);
            args.Arg6.Add(AspectJoinPoints.OnExit);
            args.Arg7.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class WithContinueFlowBehvoiurFunctionWith7ArgumentsBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            args.Arg2.Add(AspectJoinPoints.OnEntry);
            args.Arg3.Add(AspectJoinPoints.OnEntry);
            args.Arg4.Add(AspectJoinPoints.OnEntry);
            args.Arg5.Add(AspectJoinPoints.OnEntry);
            args.Arg6.Add(AspectJoinPoints.OnEntry);
            args.Arg7.Add(AspectJoinPoints.OnEntry);
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            args.Arg2.Add(AspectJoinPoints.OnSuccess);
            args.Arg3.Add(AspectJoinPoints.OnSuccess);
            args.Arg4.Add(AspectJoinPoints.OnSuccess);
            args.Arg5.Add(AspectJoinPoints.OnSuccess);
            args.Arg6.Add(AspectJoinPoints.OnSuccess);
            args.Arg7.Add(AspectJoinPoints.OnSuccess);
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
        }

        public override void OnException(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            var ex = args.Exception;

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
                args.Arg2.Add(AspectJoinPoints.OnException);
                args.Arg3.Add(AspectJoinPoints.OnException);
                args.Arg4.Add(AspectJoinPoints.OnException);
                args.Arg5.Add(AspectJoinPoints.OnException);
                args.Arg6.Add(AspectJoinPoints.OnException);
                args.Arg7.Add(AspectJoinPoints.OnException);
                args.AddToReturnValue(AspectJoinPoints.InMethod);
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }

            base.OnException(args);
        }

        public override void OnExit(FunctionExecutionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            args.Arg2.Add(AspectJoinPoints.OnExit);
            args.Arg3.Add(AspectJoinPoints.OnExit);
            args.Arg4.Add(AspectJoinPoints.OnExit);
            args.Arg5.Add(AspectJoinPoints.OnExit);
            args.Arg6.Add(AspectJoinPoints.OnExit);
            args.Arg7.Add(AspectJoinPoints.OnExit);
            args.AddToReturnValue(AspectJoinPoints.OnExit);
            base.OnExit(args);
        }
    }

    public class FunctionWith7ArgumentsInterceptionAspect : FunctionInterceptionAspect<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnInvoke);
            args.Arg2.Add(AspectJoinPoints.OnInvoke);
            args.Arg3.Add(AspectJoinPoints.OnInvoke);
            args.Arg4.Add(AspectJoinPoints.OnInvoke);
            args.Arg5.Add(AspectJoinPoints.OnInvoke);
            args.Arg6.Add(AspectJoinPoints.OnInvoke);
            args.Arg7.Add(AspectJoinPoints.OnInvoke);
            args.AddToReturnValue(AspectJoinPoints.OnInvoke);
            base.OnInvoke(args);
        }
    }
}
