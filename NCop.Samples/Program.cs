using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;

namespace NCop.Samples
{
    internal static class Aspects
    {
        public static CSharpDeveloperMixin mixin = null;
        public static TraceAspect traceAspect = null;
        public static TraceAspect2 traceAspect2 = null;
        public static TraceAspect3 traceAspect3 = null;
        public static ActionWith1RefArgumentOnMethodBoundaryAspect traceAspect4 = null;
        public static WithContinueFlowBehvoiurActionWith1RefArgumentBoundaryAspect traceAspect5 = null;
        public static ActionWith1RefArgumentInterceptionAspect traceAspect6 = null;

        static Aspects() {
            mixin = new CSharpDeveloperMixin();
            traceAspect = new TraceAspect();
            traceAspect2 = new TraceAspect2();
            traceAspect3 = new TraceAspect3();
            traceAspect4 = new ActionWith1RefArgumentOnMethodBoundaryAspect();
            traceAspect5 = new WithContinueFlowBehvoiurActionWith1RefArgumentBoundaryAspect();
            traceAspect6 = new ActionWith1RefArgumentInterceptionAspect();
        }
    }

    public sealed class MethodDecoratorFunctionBinding : IActionBinding<CSharpDeveloperMixin, int>
    {
        public static MethodDecoratorFunctionBinding singleton = null;

        static MethodDecoratorFunctionBinding() {
            singleton = new MethodDecoratorFunctionBinding();
        }

        private MethodDecoratorFunctionBinding() {
        }

        public void Proceed(ref CSharpDeveloperMixin instance, IActionArgs<int> args) {
            var arg1 = args.Arg1;

            instance.Code(ref arg1);

            args.Arg1 = arg1;
        }

        public void Invoke(ref CSharpDeveloperMixin instance, IActionArgs<int> args) {
            //var arg1 = args.Arg1;

            //instance.Code(ref arg1);

            //args.Arg1 = arg1;
        }
    }

    public sealed class MethodInterceptionBindingWeaver : IActionBinding<CSharpDeveloperMixin, int>
    {
        public static MethodInterceptionBindingWeaver singleton = null;

        static MethodInterceptionBindingWeaver() {
            singleton = new MethodInterceptionBindingWeaver();
        }

        private MethodInterceptionBindingWeaver() {
        }

        public void Invoke(ref CSharpDeveloperMixin instance, IActionArgs<int> args) {

        }

        public void Proceed(ref CSharpDeveloperMixin instance, IActionArgs<int> args) {
            //var binding = MethodDecoratorFunctionBinding.singleton;
            var aspectArgs = new ActionExecutionArgsImpl<CSharpDeveloperMixin, int>(instance, args.Method, args.Arg1);
            Aspects.traceAspect4.OnEntry(aspectArgs);
            var i = aspectArgs.Arg1;

            try {
                instance.Code(ref i);
                aspectArgs.Arg1 = i;
                Aspects.traceAspect4.OnSuccess(aspectArgs);
            }
            catch (Exception ex) {
                aspectArgs.Exception = ex;
                aspectArgs.Arg1 = i;
                Aspects.traceAspect4.OnException(aspectArgs);

                switch (aspectArgs.FlowBehavior) {
                    case FlowBehavior.ThrowException:
                        throw ex;
                    case FlowBehavior.RethrowException:
                        throw;
                    default:
                        break;
                }
            }
            finally {
                Aspects.traceAspect4.OnExit(aspectArgs);
                FunctionArgsMapper.Map<int>(aspectArgs, args);
            }
        }

        public void Proceed2(ref CSharpDeveloperMixin instance, IActionArgs<int> args) {
            //var binding = MethodDecoratorFunctionBinding.singleton;
            var aspectArgs = new ActionExecutionArgsImpl<CSharpDeveloperMixin, int>(instance, args.Method, args.Arg1);
            Aspects.traceAspect4.OnEntry(aspectArgs);
            var i = aspectArgs.Arg1;

            try {
                instance.Code(ref i);
                aspectArgs.Arg1 = i;
                Aspects.traceAspect4.OnSuccess(aspectArgs);
            }
            catch (Exception ex) {
                aspectArgs.Exception = ex;
                aspectArgs.Arg1 = i;
                Aspects.traceAspect4.OnException(aspectArgs);

                switch (aspectArgs.FlowBehavior) {
                    case FlowBehavior.ThrowException:
                        throw ex;
                    case FlowBehavior.RethrowException:
                        throw;
                    default:
                        break;
                }
            }
            finally {
                Aspects.traceAspect4.OnExit(aspectArgs);
                FunctionArgsMapper.Map<int>(aspectArgs, args);
            }
        }
    }

    internal static class FunctionArgsMapper
    {
        internal static void Map<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> first, IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.Arg3 = first.Arg3;
            second.Arg4 = first.Arg4;
            second.Arg5 = first.Arg5;
            second.Arg6 = first.Arg6;
            second.Arg7 = first.Arg7;
            second.Arg8 = first.Arg8;
            second.ReturnValue = first.ReturnValue;
        }

        public static void Map<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> first, IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.Arg3 = first.Arg3;
            second.Arg4 = first.Arg4;
            second.Arg5 = first.Arg5;
            second.Arg6 = first.Arg6;
            second.Arg7 = first.Arg7;
            second.ReturnValue = first.ReturnValue;
        }

        public static void Map<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> first, IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.Arg3 = first.Arg3;
            second.Arg4 = first.Arg4;
            second.Arg5 = first.Arg5;
            second.Arg6 = first.Arg6;
            second.ReturnValue = first.ReturnValue;
        }

        public static void Map<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> first, IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.Arg3 = first.Arg3;
            second.Arg4 = first.Arg4;
            second.Arg5 = first.Arg5;
            second.ReturnValue = first.ReturnValue;
        }

        public static void Map<TArg1, TArg2, TArg3, TArg4, TResult>(IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TResult> first, IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TResult> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.Arg3 = first.Arg3;
            second.Arg4 = first.Arg4;
            second.ReturnValue = first.ReturnValue;
        }

        public static void Map<TArg1, TArg2, TArg3, TResult>(IFunctionArgs<TArg1, TArg2, TArg3, TResult> first, IFunctionArgs<TArg1, TArg2, TArg3, TResult> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.Arg3 = first.Arg3;
            second.ReturnValue = first.ReturnValue;
        }

        public static void Map<TArg1, TArg2, TResult>(IFunctionArgs<TArg1, TArg2, TResult> first, IFunctionArgs<TArg1, TArg2, TResult> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.ReturnValue = first.ReturnValue;
        }

        public static void Map<TArg1, TResult>(IFunctionArgs<TArg1, TResult> first, IFunctionArgs<TArg1, TResult> second) {
            second.Arg1 = first.Arg1;
            second.ReturnValue = first.ReturnValue;
        }

        public static void Map<TArg1>(IActionArgs<TArg1> first, IActionArgs<TArg1> second) {
            second.Arg1 = first.Arg1;
            second.Method = second.Method;
        }

        public static void Map<TArg1, TArg2, TArg3>(IActionArgs<TArg1, TArg2, TArg3> first, IActionArgs<TArg1, TArg2, TArg3> second) {
            second.Arg1 = first.Arg1;
            second.Arg2 = first.Arg2;
            second.Arg3 = first.Arg3;
            second.Method = second.Method;
        }

        public static void Map<TResult>(IFunctionArgs<TResult> first, IFunctionArgs<TResult> second) {
            second.ReturnValue = first.ReturnValue;
        }
    }

    public class Person : IPersonComposite
    {
        private CSharpDeveloperMixin developer = null;

        public Person() {
            developer = new CSharpDeveloperMixin();
        }

        public void Code(ref int i) {
            var types = new Type[] { typeof(int).MakeByRefType() };
            var codeMethod = developer.GetType().GetMethod("Code", types);
            ////var aspectArgs = new ActionExecutionArgsImpl<CSharpDeveloperMixin, int>(developer, codeMethod, i, j, k);
            ////var interArgs = new ActionInterceptionArgsImpl<CSharpDeveloperMixin, int>(developer, codeMethod, MethodInterceptionBindingWeaver.singleton, i, j, k);
            ////Aspects.traceAspect3.OnEntry(aspectArgs);
            ////Aspects.traceAspect3.OnEntry(aspectArgs);
            //var interArgs = new ActionInterceptionArgsImpl<CSharpDeveloperMixin, int>(developer, codeMethod, MethodInterceptionBindingWeaver.singleton, i);

            //try {
            //    Aspects.traceAspect6.OnInvoke(interArgs);
            //}
            //finally {
            //    i = interArgs.Arg1;
            //}

            var aspectArgs = new ActionExecutionArgsImpl<CSharpDeveloperMixin, int>(developer, codeMethod, i);
            Aspects.traceAspect4.OnEntry(aspectArgs);

            try {
                i = aspectArgs.Arg1;
                developer.Code(ref i);
                aspectArgs.Arg1 = i;
                Aspects.traceAspect4.OnSuccess(aspectArgs);
            }
            //catch (Exception ex) {
            //    aspectArgs.Exception = ex;
            //    aspectArgs.Arg1 = i;
            //    Aspects.traceAspect4.OnException(aspectArgs);

            //    switch (aspectArgs.FlowBehavior) {
            //        case FlowBehavior.ThrowException:
            //            throw ex;
            //        case FlowBehavior.RethrowException:
            //            throw;
            //        default:
            //            break;
            //    }
            //}
            finally {
                aspectArgs.Arg1 = i;
                //    Aspects.traceAspect4.OnExit(aspectArgs);
                //    i = aspectArgs.Arg1;
                //FunctionArgsMapper.Map<int>(aspectArgs, args);
            }
        }

        public void Code2(ref int i) {
            var types = new Type[] { typeof(int).MakeByRefType() };
            var codeMethod = developer.GetType().GetMethod("Code", types);
            var aspectArgs = new ActionExecutionArgsImpl<CSharpDeveloperMixin, int>(developer, codeMethod, i);
            Aspects.traceAspect3.OnEntry(aspectArgs);

            try {
                i = aspectArgs.Arg1;
                developer.Code(ref i);
                aspectArgs.Arg1 = i;
                Aspects.traceAspect3.OnSuccess(aspectArgs);
            }
            catch (Exception ex) {
                aspectArgs.Exception = ex;
                Aspects.traceAspect3.OnException(aspectArgs);

                if (aspectArgs.FlowBehavior == FlowBehavior.RethrowException) {
                    throw;
                }
            }
            finally {
                Aspects.traceAspect3.OnExit(aspectArgs);
            }
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IPersonComposite : IDeveloper<ILanguage>
    {
        [OnMethodBoundaryAspect(typeof(ActionWith1RefArgumentOnMethodBoundaryAspect), AspectPriority = 2)]
        new void Code(ref int i);
    }

    class Program
    {
        static void Main(string[] args) {
            int i = 0;

            try {
                new Person().Code(ref i);
                Console.WriteLine(i);
            }
            catch (Exception) {
                Console.WriteLine(i);
            }

            i = 0;

            try {
                var container = new CompositeContainer();
                container.Configure();
                var person = container.TryResolve<IPersonComposite>();
                person.Code(ref i);
            }
            catch (Exception) {
                Console.WriteLine(i);
            }
        }
    }

    #region Composites

    //public class GenericCovariantDeveloper<T> : IDeveloper<T>
    //	where T : ILanguage, new()
    //{
    //	private T langugae = new T();

    //	public void Code(ref int s) {
    //		Console.WriteLine(langugae.ToString());
    //	}
    //}

    public enum AspectJoinPoints
    {
        OnExit = 1,
        OnEntry,
        OnInvoke,
        InMethod,
        OnSuccess,
        OnException
    }

    public class ActionWith1RefArgumentOnMethodBoundaryAspect : OnActionBoundaryAspect<int>
    {
        public override void OnEntry(ActionExecutionArgs<int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int> args) {
            args.Arg1 += (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        //public override void OnException(ActionExecutionArgs<int> args) {
        //    var ex = args.Exception;

        //    if (ex != null && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
        //        args.Arg1 += (int)AspectJoinPoints.OnException;
        //    }

        //    base.OnException(args);
        //}

        //public override void OnExit(ActionExecutionArgs<int> args) {
        //    args.Arg1 += (int)AspectJoinPoints.OnExit;
        //    base.OnExit(args);
        //}
    }

    public class WithContinueFlowBehvoiurActionWith1RefArgumentBoundaryAspect : OnActionBoundaryAspect<int>
    {
        public override void OnEntry(ActionExecutionArgs<int> args) {
            args.FlowBehavior = FlowBehavior.Continue;
            args.Arg1 += (int)AspectJoinPoints.OnEntry;
            base.OnEntry(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int> args) {
            args.Arg1 = args.Arg1 + (int)AspectJoinPoints.OnSuccess;
            base.OnSuccess(args);
        }

        public override void OnException(ActionExecutionArgs<int> args) {
            var ex = args.Exception;

            if (ex != null && ex.GetType() == typeof(Exception) && ex.Message.Equals("InMethodException")) {
                args.Arg1 += (int)AspectJoinPoints.OnException;
            }

            base.OnException(args);
        }

        public override void OnExit(ActionExecutionArgs<int> args) {
            args.Arg1 += (int)AspectJoinPoints.OnExit;
            base.OnExit(args);
        }
    }

    public class ActionWith1RefArgumentInterceptionAspect : ActionInterceptionAspect<int>
    {
        public override void OnInvoke(ActionInterceptionArgs<int> args) {
            //args.Arg1 += (int)AspectJoinPoints.OnInvoke;
            base.OnInvoke(args);
        }
    }

    [PerThreadAspect]
    public class TraceAspect3 : OnActionBoundaryAspect<int>
    {
        public override void OnEntry(ActionExecutionArgs<int> args) {
            Console.WriteLine("Code from TraceAspect3 OnEntry");
            base.OnEntry(args);
        }

        public override void OnExit(ActionExecutionArgs<int> args) {
            Console.WriteLine("Code from TraceAspect3 OnExit");
            args.Arg1 = 10;
            base.OnExit(args);
        }

        //public override void OnException(ActionExecutionArgs<int> args) {
        //    Console.WriteLine("Code from TraceAspect3 OnException");
        //    base.OnException(args);
        //}

        public override void OnSuccess(ActionExecutionArgs<int> args) {
            Console.WriteLine("Code from TraceAspect3 OnSuccess");
            base.OnSuccess(args);
        }
    }

    public class TraceAspect : ActionInterceptionAspect<int>
    {
        public override void OnInvoke(ActionInterceptionArgs<int> args) {
            Console.WriteLine("Code from TraceAspect OnInvoke");
            args.Proceed();
        }
    }

    public class TraceAspect1 : FunctionInterceptionAspect<int>
    {
        public override void OnInvoke(FunctionInterceptionArgs<int> args) {
            base.OnInvoke(args);
        }
    }

    [PerThreadAspect]
    public class TraceAspect2 : OnFunctionBoundaryAspect<int>
    {
        public override void OnEntry(FunctionExecutionArgs<int> args) {
            base.OnEntry(args);
        }

        //public override void OnSuccess(FunctionExecutionArgs<string, bool> args) {
        //    base.OnSuccess(args);
        //}

        //public override void OnException(FunctionExecutionArgs<string, bool> args) {
        //    base.OnException(args);
        //}

        //public override void OnExit(FunctionExecutionArgs<string, bool> args) {
        //    base.OnExit(args);
        //}
    }

    public class CSharpDeveloperMixin : AbstractDeveloper<CSharpLanguage5>
    {
        public override void Code(ref int i) {
            i += (int)AspectJoinPoints.InMethod;
            throw new Exception("InMethodException");
        }
    }

    public class JavaScriptDeveloperMixin : AbstractDeveloper<JavaScriptLanguage>
    {

    }

    public abstract class AbstractDeveloper<TLanguage> : IDeveloper<TLanguage>
        where TLanguage : ILanguage, new()
    {
        private readonly ILanguage language = new TLanguage();

        public virtual void Code(ref int i) {
            Console.WriteLine("I am coding in " + language.ToString());
        }
    }

    public interface ILanguage
    {
        string Description { get; }
    }

    public class CSharpLanguage : ILanguage
    {
        public virtual string Description {
            get {
                return "C#";
            }
        }
    }

    public class JavaScriptLanguage : ILanguage
    {
        public string Description {
            get {
                return "JavaScript";
            }
        }
    }

    public class CSharpLanguage5 : CSharpLanguage
    {
        public override string Description {
            get {
                return "C# 5";
            }
        }
    }

    public interface IDeveloper<out TLanguage>
    {
        void Code(ref int i);
    }

    public interface IDeveloper
    {
        void Code(int code);
    }

    #endregion Composites
}