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

    public sealed class MethodDecoratorFunctionBinding : IActionBinding<CSharpDeveloperMixin, string>
    {
        public static MethodDecoratorFunctionBinding singleton = null;

        static MethodDecoratorFunctionBinding() {
            singleton = new MethodDecoratorFunctionBinding();
        }

        private MethodDecoratorFunctionBinding() {
        }

        public void Invoke(ref CSharpDeveloperMixin instance, IActionArgs<string> args) {
            instance.Code(args.Arg1);
        }
    }

    public sealed class MethodInterceptionBindingWeaver : IActionBinding<CSharpDeveloperMixin, string>
    {
        public static MethodInterceptionBindingWeaver singleton = null;

        static MethodInterceptionBindingWeaver() {
            singleton = new MethodInterceptionBindingWeaver();
        }

        private MethodInterceptionBindingWeaver() {
        }

        public void Invoke(ref CSharpDeveloperMixin instance, IActionArgs<string> args) {
            //var binding = MethodDecoratorFunctionBinding.singleton;
            var aspectArgs = new ActionExecutionArgsImpl<CSharpDeveloperMixin, string>(instance, args.Method, args.Arg1);
            Aspects.traceAspect3.OnEntry(aspectArgs);
            instance.Code(args.Arg1);
            //Aspects.traceAspect3.OnSuccess(aspectArgs);
            //Action<string> code = instance.Code;
            //var aspectArgs = new ActionInterceptionArgsImpl<CSharpDeveloperMixin, string>(instance, code.Method, binding, args.Arg1);
            //Aspects.traceAspect.OnInvoke(aspectArgs);
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

        public void Code(string sagi) {
            Action<string> code = developer.Code;
            //var aspectArgs = new ActionExecutionArgsImpl<CSharpDeveloperMixin, string>(developer, code.Method, sagi);
            //Aspects.traceAspect3.OnEntry(aspectArgs);
            var interArgs = new ActionInterceptionArgsImpl<CSharpDeveloperMixin, string>(developer, code.Method, MethodInterceptionBindingWeaver.singleton, sagi);
            Aspects.traceAspect.OnInvoke(interArgs);
            //FunctionArgsMapper.Map<string>(interArgs, aspectArgs);
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

        //    public string Code2(string sagi) {
        //        var aspectArgs = new FunctionExecutionArgsImpl<CSharpDeveloperMixin, string, string>(developer, sagi);
        //        Aspects.traceAspect3.OnEntry(aspectArgs);

        //        try {
        //            aspectArgs.ReturnValue = developer.Code(aspectArgs.Arg1);
        //            Aspects.traceAspect3.OnSuccess(aspectArgs);
        //        }
        //        catch (Exception ex) {
        //            aspectArgs.Exception = ex;
        //            Aspects.traceAspect3.OnException(aspectArgs);

        //            if (aspectArgs.FlowBehavior == FlowBehavior.RethrowException) {
        //                throw;
        //            }
        //        }
        //        finally {
        //            Aspects.traceAspect3.OnExit(aspectArgs);
        //        }

        //        return aspectArgs.ReturnValue;
        //    }
    }

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IPersonComposite : IDeveloper<ILanguage>
    {
        [MethodInterceptionAspect(typeof(TraceAspect), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(TraceAspect3), AspectPriority = 2)]
        //[OnMethodBoundaryAspect(typeof(TraceAspect3), AspectPriority = 3)]
        //[MethodInterceptionAspect(typeof(TraceAspect), AspectPriority = 4)]
        //[OnMethodBoundaryAspect(typeof(TraceAspect3), AspectPriority = 5)]
        //[MethodInterceptionAspect(typeof(TraceAspect), AspectPriority = 6)]
        //[OnMethodBoundaryAspect(typeof(TraceAspect3), AspectPriority = 1)]
        //[OnMethodBoundaryAspect(typeof(TraceAspect3), AspectPriority = 1)]
        new void Code(string s);

    }

    class Program
    {   
        static void Main(string[] args) {
            //new Person().Code("Sagi"); return;
            var container = new CompositeContainer();
            container.Configure();
            var person = container.TryResolve<IPersonComposite>();
            person.Code("Sagi");
        }
    }

    #region Composites

    public class GenericCovariantDeveloper<T> : IDeveloper<T>
        where T : ILanguage, new()
    {
        private T langugae = new T();

        public void Code(string s) {
            Console.WriteLine(langugae.ToString());
        }
    }


    [PerThreadAspect]
    public class TraceAspect3 : OnActionBoundaryAspect<string>
    {
        public override void OnEntry(ActionExecutionArgs<string> args) {
            Console.WriteLine("Code from TraceAspect3 OnEntry");
            base.OnEntry(args);
        }

        //public override void OnExit(ActionExecutionArgs<string> args) {
        //    Console.WriteLine("Code from TraceAspect3 OnExit");
        //    base.OnExit(args);
        //}

        //public override void OnException(ActionExecutionArgs<string> args) {
        //    Console.WriteLine("Code from TraceAspect3 OnException");
        //    base.OnException(args);
        //}

        //public override void OnSuccess(ActionExecutionArgs<string> args) {
        //    Console.WriteLine("Code from TraceAspect3 OnSuccess");
        //    base.OnSuccess(args);
        //}
    }

    public class TraceAspect : ActionInterceptionAspect<string>
    {
        public override void OnInvoke(ActionInterceptionArgs<string> args) {
            Console.WriteLine("Code from TraceAspect OnInvoke");
            base.OnInvoke(args);
        }
    }

    public class TraceAspect1 : FunctionInterceptionAspect<string>
    {
        public override void OnInvoke(FunctionInterceptionArgs<string> args) {
            base.OnInvoke(args);
        }
    }

    [PerThreadAspect]
    public class TraceAspect2 : OnFunctionBoundaryAspect<string>
    {
        public override void OnEntry(FunctionExecutionArgs<string> args) {
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
        public override void Code(string s) {
            Console.WriteLine(s);
        }

        public string Code5(ref string s) {
            s = "sascascascaca";
            return "Code";
        }
    }

    public class JavaScriptDeveloperMixin : AbstractDeveloper<JavaScriptLanguage>
    {

    }

    public abstract class AbstractDeveloper<TLanguage> : IDeveloper<TLanguage>
        where TLanguage : ILanguage, new()
    {
        private readonly ILanguage language = new TLanguage();

        public virtual void Code(string s) {
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
        void Code(string s);
    }

    public interface IDeveloper
    {
        void Code(string code);
    }

    #endregion Composites
}