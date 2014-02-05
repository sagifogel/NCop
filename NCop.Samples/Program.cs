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

        static Aspects() {
            mixin = new CSharpDeveloperMixin();
            traceAspect = new TraceAspect();
            traceAspect2 = new TraceAspect2();
            traceAspect3 = new TraceAspect3();
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

        public void Invoke(ref CSharpDeveloperMixin instance, IActionArgs<int> args) {
            var args1 = args.Arg1;
            instance.Code(ref args1);
        }

        public void Invoke(ref CSharpDeveloperMixin instance, ref int arg1) {
            instance.Code(ref arg1);
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
            //var binding = MethodDecoratorFunctionBinding.singleton;
            var aspectArgs = new ActionExecutionArgsImpl<CSharpDeveloperMixin, int>(instance, args.Method, args.Arg1);
            Aspects.traceAspect3.OnEntry(aspectArgs);
            var interceptionArgs = new ActionInterceptionArgsImpl<CSharpDeveloperMixin, int>(instance, args.Method, MethodDecoratorFunctionBinding.singleton, args.Arg1);
            Aspects.traceAspect.OnInvoke(interceptionArgs);
        }

        public void Invoke(ref CSharpDeveloperMixin instance, ref int arg1) {
            throw new NotImplementedException();
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

        public void Code(ref int sagi) {
            var codeMethod = developer.GetType().GetMethod("Code");
            var interArgs = new ActionInterceptionArgsImpl<CSharpDeveloperMixin, int>(developer, codeMethod, MethodDecoratorFunctionBinding.singleton, sagi);
            Aspects.traceAspect.OnInvoke(interArgs);
            sagi = interArgs.Arg1;
            //FunctionArgsMapper.Map<int>(interArgs, aspectArgs);
            //try {
            //    developer.Code(aspectArgs.Arg1);
            //    Aspects.traceAspect3.OnSuccess(aspectArgs);
            //}
            //catch (Exception ex) {
            //    aspectArgs.Exception = ex;
            //    Aspects.traceAspect3.OnException(aspectArgs);

            //    if (aspectArgs.FlowBehavior == FlowBehavior.RethrowException) {
            //        throw;
            //    }
            //}
            //finally {
            //    Aspects.traceAspect3.OnExit(aspectArgs);
            //}
        }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IPersonComposite : IDeveloper<ILanguage>
    {
        [MethodInterceptionAspect(typeof(TraceAspect), AspectPriority = 1)]
        //[OnMethodBoundaryAspect(typeof(TraceAspect3), AspectPriority = 2)]
        new void Code(ref int s);

    }

    class Program
    {
        static void Main(string[] args) {
            int i = 0;
            new Person().Code(ref i); return;
            var container = new CompositeContainer();
            container.Configure();
            var person = container.TryResolve<IPersonComposite>();
            person.Code(ref i);
        }
    }

    #region Composites

    public class GenericCovariantDeveloper<T> : IDeveloper<T>
        where T : ILanguage, new()
    {
        private T langugae = new T();

        public void Code(ref int s) {
            Console.WriteLine(langugae.ToString());
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
            base.OnExit(args);
        }

        public override void OnException(ActionExecutionArgs<int> args) {
            Console.WriteLine("Code from TraceAspect3 OnException");
            base.OnException(args);
        }

        public override void OnSuccess(ActionExecutionArgs<int> args) {
            Console.WriteLine("Code from TraceAspect3 OnSuccess");
            base.OnSuccess(args);
        }
    }

    public class TraceAspect : ActionInterceptionAspect<int>
    {
        public override void OnInvoke(ActionInterceptionArgs<int> args) {
            Console.WriteLine("Code from TraceAspect OnInvoke");
            args.Invoke();
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
            i = 10;
        }
    }

    public class JavaScriptDeveloperMixin : AbstractDeveloper<JavaScriptLanguage>
    {

    }

    public abstract class AbstractDeveloper<TLanguage> : IDeveloper<TLanguage>
        where TLanguage : ILanguage, new()
    {
        private readonly ILanguage language = new TLanguage();

        public virtual void Code(ref int s) {
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
        void Code(ref int s);
    }

    public interface IDeveloper
    {
        void Code(ref int code);
    }

    #endregion Composites
}