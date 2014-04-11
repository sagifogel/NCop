using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;
using NCop.IoC;
using NCop.Composite.Runtime;
using StructureMap.Configuration.DSL;
using StructureMap;
using System.Linq;

namespace NCop.Samples
{
    internal static class Aspects
    {
        public static CSharpDeveloperMixin mixin = null;
        public static TraceAspect traceAspect = null;
        public static TraceAspect1 traceAspect1 = null;
        public static TraceAspect2 traceAspect2 = null;
        public static TraceAspect3 traceAspect3 = null;

        static Aspects() {
            mixin = new CSharpDeveloperMixin();
            traceAspect = new TraceAspect();
            traceAspect1 = new TraceAspect1();
            traceAspect2 = new TraceAspect2();
            traceAspect3 = new TraceAspect3();
        }
    }

    public sealed class ActionDecoratorFunctionBinding : IActionBinding<CSharpDeveloperMixin>
    {
        public static ActionDecoratorFunctionBinding singleton = null;

        static ActionDecoratorFunctionBinding() {
            singleton = new ActionDecoratorFunctionBinding();
        }

        private ActionDecoratorFunctionBinding() {
        }

        public void Proceed(ref CSharpDeveloperMixin instance, IActionArgs args) {
            instance.Code();

        }

        public void Invoke(ref CSharpDeveloperMixin instance, IActionArgs args) {
            instance.Code();
        }
    }

    public sealed class MethodDecoratorActionBinding : IActionBinding<CSharpDeveloperMixin>
    {
        public static MethodDecoratorActionBinding singleton = null;

        static MethodDecoratorActionBinding() {
            singleton = new MethodDecoratorActionBinding();
        }

        private MethodDecoratorActionBinding() {
        }

        public void Proceed(ref CSharpDeveloperMixin instance, IActionArgs args) {
            instance.Code();
        }

        public void Invoke(ref CSharpDeveloperMixin instance, IActionArgs args) {
            instance.Code();
        }
    }

    public sealed class MethodInterceptionBindingWeaver : IActionBinding<CSharpDeveloperMixin>
    {
        public static MethodInterceptionBindingWeaver singleton = null;

        static MethodInterceptionBindingWeaver() {
            singleton = new MethodInterceptionBindingWeaver();
        }
        public void Invoke(ref CSharpDeveloperMixin instance, IActionArgs args) {
            var aspectArgs = new ActionInterceptionArgsImpl<CSharpDeveloperMixin>(instance, args.Method, ActionDecoratorFunctionBinding.singleton);
            Aspects.traceAspect1.OnInvoke(aspectArgs);
        }

        public void Proceed(ref CSharpDeveloperMixin instance, IActionArgs args) {
            var aspectArgs = new ActionInterceptionArgsImpl<CSharpDeveloperMixin>(instance, args.Method, ActionDecoratorFunctionBinding.singleton);
            Aspects.traceAspect1.OnInvoke(aspectArgs);
        }
    }

    //public sealed class MethodInterceptionBindingWeaver : IFunctionBinding<CSharpDeveloperMixin, string, string>
    //{
    //    public static MethodInterceptionBindingWeaver singleton = null;

    //    static MethodInterceptionBindingWeaver() {
    //        singleton = new MethodInterceptionBindingWeaver();
    //    }

    //    private MethodInterceptionBindingWeaver() {
    //    }

    //    public string Invoke(ref CSharpDeveloperMixin instance, IFunctionArgs<string, string> args) {
    //        var aspectArgs = new FunctionExecutionArgsImpl<CSharpDeveloperMixin, string, string>(instance, args.Method, args.Arg1);
    //        Aspects.traceAspect2.OnEntry(aspectArgs);

    //        try {
    //            var interArgs = new FunctionInterceptionArgsImpl<CSharpDeveloperMixin, string, string>(instance, aspectArgs.Method, MethodDecoratorFunctionBinding.singleton, aspectArgs.Arg1);
    //            Aspects.traceAspect1.OnInvoke(interArgs);
    //            FunctionArgsMapper.Map<string, string>(interArgs, aspectArgs);
    //            Aspects.traceAspect2.OnSuccess(aspectArgs);
    //        }
    //        catch (Exception ex) {
    //            Aspects.traceAspect2.OnException(aspectArgs);

    //            switch (aspectArgs.FlowBehavior) {
    //                case FlowBehavior.ThrowException:
    //                    throw ex;
    //                case FlowBehavior.RethrowException:
    //                    throw;
    //                default:
    //                    break;
    //            }
    //        }
    //        finally {
    //            Aspects.traceAspect2.OnExit(aspectArgs);
    //        }

    //        return aspectArgs.ReturnValue;
    //    }

    //    public string Proceed(ref CSharpDeveloperMixin instance, IFunctionArgs<string, string> args) {
    //        var aspectArgs = new FunctionExecutionArgsImpl<CSharpDeveloperMixin, string, string>(instance, args.Method, args.Arg1);
    //        Aspects.traceAspect2.OnEntry(aspectArgs);

    //        try {
    //            aspectArgs.ReturnValue = instance.Code2(aspectArgs.Arg1);
    //            Aspects.traceAspect2.OnSuccess(aspectArgs);
    //        }
    //        catch (Exception ex) {
    //            Aspects.traceAspect2.OnException(aspectArgs);

    //            switch (aspectArgs.FlowBehavior) {
    //                case FlowBehavior.ThrowException:
    //                    throw ex;
    //                case FlowBehavior.RethrowException:
    //                    throw;
    //                default:
    //                    break;
    //            }
    //        }
    //        finally {
    //            Aspects.traceAspect2.OnExit(aspectArgs);
    //        }

    //        return aspectArgs.ReturnValue;
    //    }
    //}

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

        public static void Map<TArg1, TArg2, TArg3>(IActionArgs first, IActionArgs second) {
            second.Method = first.Method;
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

        public void Code() {
            var codeMethod = developer.GetType().GetMethod("Code", Type.EmptyTypes);
            var aspectArgs = new ActionInterceptionArgsImpl<CSharpDeveloperMixin>(developer, codeMethod, MethodInterceptionBindingWeaver.singleton);
            Aspects.traceAspect1.OnInvoke(aspectArgs);
        }

        public string Code2() {
            var codeMethod = developer.GetType().GetMethod("Code", Type.EmptyTypes);
            var aspectArgs = new ActionInterceptionArgsImpl<CSharpDeveloperMixin>(developer, codeMethod, MethodInterceptionBindingWeaver.singleton);
            Aspects.traceAspect1.OnInvoke(aspectArgs);

            return string.Empty;
        }

        //public string Code2(string s) {
        //    var types = new Type[] { typeof(int).MakeByRefType() };
        //    var codeMethod = developer.GetType().GetMethod("Code", types);
        //    var aspectArgs = new FunctionExecutionArgsImpl<CSharpDeveloperMixin, string, string>(developer, codeMethod, s);

        //    Aspects.traceAspect2.OnEntry(aspectArgs);

        //    try {
        //        Aspects.traceAspect2.OnEntry(aspectArgs);

        //        try {
        //            aspectArgs.ReturnValue = developer.Code2(aspectArgs.Arg1);
        //            Aspects.traceAspect2.OnSuccess(aspectArgs);
        //        }
        //        catch (Exception ex) {
        //            aspectArgs.Exception = ex;
        //            Aspects.traceAspect2.OnException(aspectArgs);

        //            switch (aspectArgs.FlowBehavior) {
        //                case FlowBehavior.ThrowException:
        //                    throw ex;
        //                case FlowBehavior.RethrowException:
        //                    throw;
        //                default:
        //                    break;
        //            }
        //        }
        //        finally {
        //            Aspects.traceAspect2.OnExit(aspectArgs);
        //        }

        //        Aspects.traceAspect2.OnSuccess(aspectArgs);
        //    }
        //    catch (Exception ex) {
        //        aspectArgs.Exception = ex;
        //        Aspects.traceAspect2.OnException(aspectArgs);

        //        switch (aspectArgs.FlowBehavior) {
        //            case FlowBehavior.ThrowException:
        //                throw ex;
        //            case FlowBehavior.RethrowException:
        //                throw;
        //            default:
        //                break;
        //        }
        //    }
        //    finally {
        //        Aspects.traceAspect2.OnExit(aspectArgs);
        //    }

        //    return aspectArgs.ReturnValue;
        //}
    }

    //[TransientComposite(As = typeof(IPersonComposite))]

    [TransientComposite]
    [Mixins(typeof(CSharpDeveloperMixin))]
    public interface IPersonComposite : IDeveloper<ILanguage>
    {
        //[OnMethodBoundaryAspect(typeof(TraceAspect2), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(TraceAspect1), AspectPriority = 1)]
        [MethodInterceptionAspect(typeof(TraceAspect1), AspectPriority = 3)]
        new void Code();

        [OnMethodBoundaryAspect(typeof(TraceAspect3), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(TraceAspect3), AspectPriority = 1)]
        [OnMethodBoundaryAspect(typeof(TraceAspect3), AspectPriority = 1)]
        new string Code2();
    }

    class Program
    {
        static void Main(string[] args) {
            //new Person().Code();return;
            var settings = new CompositeRuntimeSettings {
                DependencyContainerAdapter = new StructureMapAdapter()
            };

            var container = new CompositeContainer(settings);
            container.Configure();
            var person = container.TryResolve<IPersonComposite>();
            person.Code();
        }
    }

    #region Composites

    public class TraceAspect3 : OnFunctionBoundaryAspect<string>
    {
        int counter = 0;

        public override void OnEntry(FunctionExecutionArgs<string> args) {
            Console.WriteLine("Code from TraceAspect3 OnEntry");
            if (counter == 2) {
                args.FlowBehavior = FlowBehavior.Continue;
                throw new Exception();
            }

            base.OnEntry(args);

            if (counter != 2) {
                counter++;
            }
        }

        public override void OnExit(FunctionExecutionArgs<string> args) {
            Console.WriteLine("Code from TraceAspect3 OnExit");
            base.OnExit(args);
        }

        public override void OnException(FunctionExecutionArgs<string> args) {
            Console.WriteLine("Code from TraceAspect3 OnException");
            try {
                base.OnException(args);
            }
            catch (Exception) {
            }
        }

        public override void OnSuccess(FunctionExecutionArgs<string> args) {
            Console.WriteLine("Code from TraceAspect3 OnSuccess");
            base.OnSuccess(args);
        }
    }

    public class TraceAspect : FunctionInterceptionAspect<int, int, int, int>
    {
        public override void OnInvoke(FunctionInterceptionArgs<int, int, int, int> args) {
            Console.WriteLine("Code from TraceAspect OnInvoke");
            args.Proceed();
        }
    }

    public class TraceAspect1 : ActionInterceptionAspect
    {
        public override void OnInvoke(ActionInterceptionArgs args) {
            Console.WriteLine("Code from TraceAspect1 OnInvoke");
            base.OnInvoke(args);
        }
    }

    [PerThreadAspect]
    public class TraceAspect2 : OnActionBoundaryAspect
    {
        public override void OnEntry(ActionExecutionArgs args) {
            base.OnEntry(args);
        }

        public override void OnException(ActionExecutionArgs args) {
            base.OnException(args);
        }

        public override void OnSuccess(ActionExecutionArgs args) {
            base.OnSuccess(args);
        }

        public override void OnExit(ActionExecutionArgs args) {
            base.OnExit(args);
        }
    }

    public class CSharpDeveloperMixin2
    {
        public int Code(int i, int j, int k) {
            return i = k = 10;
        }
    }

    [Named("CSharpDeveloperMixin")]
    public class CSharpDeveloperMixin : AbstractDeveloper<CSharpLanguage5>
    {
    }

    public class JavaScriptDeveloperMixin : AbstractDeveloper<JavaScriptLanguage>
    {

    }

    public abstract class AbstractDeveloper<TLanguage> : IDeveloper<TLanguage>
        where TLanguage : ILanguage, new()
    {
        private readonly ILanguage language = new TLanguage();

        public virtual void Code() { }

        public virtual string Code2() { return string.Empty; }
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
        string Code2();
        void Code();
    }

    public interface IDeveloper
    {
        void Code(int code);
    }

    #endregion Composites
}