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

namespace NCop.Aspects.Tests.FunctionWith1ArgumentAspect.Subjects
{
    public interface IFunctionWith1ArgumentBoundaryAspect
    {
        string InterceptionAspect(List<AspectJoinPoints> joinPoints);
        string OnMethodBoundaryAspect(List<AspectJoinPoints> joinPoints);
        string MultipleInterceptionAspects(List<AspectJoinPoints> joinPoints);
        string MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> joinPoints);
        string AllAspectsStartingWithInterception(List<AspectJoinPoints> joinPoints);
        string AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> joinPoints);
        string AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> joinPoints);
        string AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> joinPoints);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> joinPoints);
        string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> joinPoints);
    }

    public class CSharpDeveloperMixin : IFunctionWith1ArgumentBoundaryAspect
    {
        private string AddInMethodJoinPoint(List<AspectJoinPoints> joinPoints) {
            joinPoints.Add(AspectJoinPoints.InMethod);

            return string.Join(":", joinPoints);
        }

        public string InterceptionAspect(List<AspectJoinPoints> joinPoints) {
            return AddInMethodJoinPoint(joinPoints);
        }

        public string OnMethodBoundaryAspect(List<AspectJoinPoints> joinPoints) {
            return AddInMethodJoinPoint(joinPoints);
        }

        public string MultipleInterceptionAspects(List<AspectJoinPoints> joinPoints) {
            return AddInMethodJoinPoint(joinPoints);
        }

        public string MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> joinPoints) {
            return AddInMethodJoinPoint(joinPoints);
        }

        public string AllAspectsStartingWithInterception(List<AspectJoinPoints> joinPoints) {
            return AddInMethodJoinPoint(joinPoints);
        }

        public string AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> joinPoints) {
            return AddInMethodJoinPoint(joinPoints);
        }

        public string AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> joinPoints) {
            return AddInMethodJoinPoint(joinPoints);
        }

        public string AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> joinPoints) {
            return AddInMethodJoinPoint(joinPoints);
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> joinPoints) {
            AddInMethodJoinPoint(joinPoints);
            throw new Exception("InMethodException");
        }

        public string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> joinPoints) {
            return OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(joinPoints);
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IFunctionWith1ArgumentComposite : IFunctionWith1ArgumentBoundaryAspect
    {
        [MethodInterceptionAspect(typeof(FunctionWith1ArgumentInterceptionAspect))]
        new string InterceptionAspect(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(FunctionWith1ArgumentOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspect(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(FunctionWith1ArgumentOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith1ArgumentOnMethodBoundaryAspect))]
        [OnMethodBoundaryAspect(typeof(FunctionWith1ArgumentOnMethodBoundaryAspect))]
        new string MultipleOnMethodBoundaryAspects(List<AspectJoinPoints> joinPoints);

        [MethodInterceptionAspect(typeof(FunctionWith1ArgumentInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith1ArgumentInterceptionAspect))]
        [MethodInterceptionAspect(typeof(FunctionWith1ArgumentInterceptionAspect))]
        new string MultipleInterceptionAspects(List<AspectJoinPoints> joinPoints);

        [MethodInterceptionAspect(typeof(FunctionWith1ArgumentInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith1ArgumentOnMethodBoundaryAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithInterception(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(FunctionWith1ArgumentOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith1ArgumentInterceptionAspect), AspectPriority = 2)]
        new string AllAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> joinPoints);

        [MethodInterceptionAspect(typeof(FunctionWith1ArgumentInterceptionAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(FunctionWith1ArgumentOnMethodBoundaryAspect), AspectPriority = 2)]
        [MethodInterceptionAspect(typeof(FunctionWith1ArgumentInterceptionAspect), AspectPriority = 3)]
        [OnMethodBoundaryAspect(typeof(FunctionWith1ArgumentOnMethodBoundaryAspect), AspectPriority = 4)]
        [MethodInterceptionAspect(typeof(FunctionWith1ArgumentInterceptionAspect), AspectPriority = 5)]
        [OnMethodBoundaryAspect(typeof(FunctionWith1ArgumentOnMethodBoundaryAspect), AspectPriority = 6)]
        new string AlternatelAspectsStartingWithInterception(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(FunctionWith1ArgumentOnMethodBoundaryAspect), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(FunctionWith1ArgumentInterceptionAspect), AspectPriority = 2)]
        [OnMethodBoundaryAspect(typeof(FunctionWith1ArgumentOnMethodBoundaryAspect), AspectPriority = 3)]
        [MethodInterceptionAspect(typeof(FunctionWith1ArgumentInterceptionAspect), AspectPriority = 4)]
        [OnMethodBoundaryAspect(typeof(FunctionWith1ArgumentOnMethodBoundaryAspect), AspectPriority = 5)]
        [MethodInterceptionAspect(typeof(FunctionWith1ArgumentInterceptionAspect), AspectPriority = 6)]
        new string AlternateAspectsStartingWithOnMethodBoundary(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(FunctionWith1ArgumentOnMethodBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImpl(List<AspectJoinPoints> joinPoints);

        [OnMethodBoundaryAspect(typeof(WithContinueFlowBehvoiurFunctionWith1ArgumentBoundaryAspect))]
        new string OnMethodBoundaryAspectThatRaiseAnExceptionInMethodImplDecoratedWithContinueFlowBehaviourAspect(List<AspectJoinPoints> joinPoints);
    }

    public class FunctionWith1ArgumentOnMethodBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
        }

        public override void OnException(FunctionExecutionArgs<List<AspectJoinPoints>, string> args) {
            var ex = args.Exception;
            
            base.OnException(args);
            
            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }
        }

        public override void OnExit(FunctionExecutionArgs<List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
            args.AddToReturnValue(AspectJoinPoints.OnExit);
        }
    }

    public class WithContinueFlowBehvoiurFunctionWith1ArgumentBoundaryAspect : OnFunctionBoundaryAspect<List<AspectJoinPoints>, string>
    {
        public override void OnEntry(FunctionExecutionArgs<List<AspectJoinPoints>, string> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1.Add(AspectJoinPoints.OnEntry);
            base.OnEntry(args);
            args.AddToReturnValue(AspectJoinPoints.OnEntry);
        }

        public override void OnSuccess(FunctionExecutionArgs<List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnSuccess);
            base.OnSuccess(args);
            args.AddToReturnValue(AspectJoinPoints.OnSuccess);
        }

        public override void OnException(FunctionExecutionArgs<List<AspectJoinPoints>, string> args) {
            var ex = args.Exception;

            base.OnException(args);

            if (ex.IsNotNull() && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1.Add(AspectJoinPoints.OnException);
                args.AddToReturnValue(AspectJoinPoints.OnException);
            }
        }

        public override void OnExit(FunctionExecutionArgs<List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnExit);
            base.OnExit(args);
            args.AddToReturnValue(AspectJoinPoints.OnExit);
        }
    }

    public class FunctionWith1ArgumentInterceptionAspect : FunctionInterceptionAspect<List<AspectJoinPoints>, string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<List<AspectJoinPoints>, string> args) {
            args.Arg1.Add(AspectJoinPoints.OnInvoke);
            base.OnInvoke(args);
            args.AddToReturnValue(AspectJoinPoints.OnInvoke);
        }
    }
}
