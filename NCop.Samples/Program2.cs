//using NCop.Aspects.Engine;
//using NCop.Aspects.Framework;
//using NCop.Composite.Framework;
//using NCop.Mixins.Framework;
//using System;
//using NCop.IoC;
//using NCop.Composite.Runtime;
//using StructureMap.Configuration.DSL;
//using StructureMap;
//using System.Linq;

//namespace NCop.Samples
//{
//    internal static class Aspects
//    {
//        public static CSharpDeveloperMixin mixin = null;
//        public static TraceAspect traceAspect = null;
//        public static TraceAspect1 traceAspect1 = null;
//        public static TraceAspect2 traceAspect2 = null;
//        public static TraceAspect3 traceAspect3 = null;

//        static Aspects() {
//            mixin = new CSharpDeveloperMixin();
//            traceAspect = new TraceAspect();
//            traceAspect1 = new TraceAspect1();
//            traceAspect2 = new TraceAspect2();
//            traceAspect3 = new TraceAspect3();
//        }
//    }

//    public class A
//    {
//        public int Invoke(ref CSharpDeveloperMixin instance, IFunctionArgs<int, int, int, int> args) {
//            var i = args.Arg1;
//            var k = args.Arg3;

//            args.ReturnValue = instance.Code(ref i, args.Arg2, ref k);

//            args.Arg1 = i;
//            args.Arg3 = k;

//            return args.ReturnValue;
//        }

//        public int Invoke2(ref CSharpDeveloperMixin2 instance, IFunctionArgs<int, int, int, int> args) {
//            //var i = args.Arg1;
//            //var k = args.Arg3;

//            args.ReturnValue = instance.Code(args.Arg1, args.Arg2, args.Arg3);

//            //args.Arg1 = i;
//            //            args.Arg3 = k;

//            return args.ReturnValue;
//        }

//        public int Invoke3(ref CSharpDeveloperMixin2 instance, IFunctionArgs<int, int, int, int> args) {
//            return instance.Code(args.Arg1, args.Arg2, args.Arg3);
//        }
//    }

//    public sealed class MethodDecoratorFunctionBinding : IFunctionBinding<CSharpDeveloperMixin, string, string>
//    {
//        public static MethodDecoratorFunctionBinding singleton = null;

//        static MethodDecoratorFunctionBinding() {
//            singleton = new MethodDecoratorFunctionBinding();
//        }

//        private MethodDecoratorFunctionBinding() {
//        }

//        public string Proceed(ref CSharpDeveloperMixin instance, IFunctionArgs<string, string> args) {
//            args.ReturnValue = instance.Code2(args.Arg1);

//            return args.ReturnValue;
//        }

//        public string Invoke(ref CSharpDeveloperMixin instance, IFunctionArgs<string, string> args) {
//            args.ReturnValue = instance.Code2(args.Arg1);
//            return args.ReturnValue;
//        }
//    }

//    public sealed class MethodInterceptionBindingWeaver2 : IFunctionBinding<CSharpDeveloperMixin, string, string>
//    {
//        public static MethodInterceptionBindingWeaver2 singleton = null;

//        static MethodInterceptionBindingWeaver2() {
//            singleton = new MethodInterceptionBindingWeaver2();
//        }

//        private MethodInterceptionBindingWeaver2() {
//        }

//        public string Invoke(ref CSharpDeveloperMixin instance, IFunctionArgs<string, string> args) {
//            var aspectArgs = new FunctionExecutionArgsImpl<CSharpDeveloperMixin, string, string>(instance, args.Method, args.Arg1);
//            Aspects.traceAspect2.OnEntry(aspectArgs);

//            try {
//                var interArgs = new FunctionInterceptionArgsImpl<CSharpDeveloperMixin, string, string>(instance, aspectArgs.Method, MethodDecoratorFunctionBinding.singleton, aspectArgs.Arg1);
//                interArgs.Proceed();
//                FunctionArgsMapper.Map<string, string>(interArgs, aspectArgs);
//                Aspects.traceAspect2.OnSuccess(aspectArgs);
//            }
//            finally {
//                Aspects.traceAspect2.OnExit(aspectArgs);
//            }

//            return aspectArgs.ReturnValue;
//        }

//        public string Proceed(ref CSharpDeveloperMixin instance, IFunctionArgs<string, string> args) {
//            var aspectArgs = new FunctionExecutionArgsImpl<CSharpDeveloperMixin, string, string>(instance, args.Method, args.Arg1);
//            Aspects.traceAspect2.OnEntry(aspectArgs);

//            try {
//                var interArgs = new FunctionInterceptionArgsImpl<CSharpDeveloperMixin, string, string>(instance, aspectArgs.Method, MethodDecoratorFunctionBinding.singleton, aspectArgs.Arg1);
//                interArgs.Proceed();
//                FunctionArgsMapper.Map<string, string>(interArgs, aspectArgs);
//                Aspects.traceAspect2.OnSuccess(aspectArgs);
//            }
//            finally {
//                Aspects.traceAspect2.OnExit(aspectArgs);
//            }

//            return aspectArgs.ReturnValue;
//        }
//    }

//    public sealed class MethodInterceptionBindingWeaver : IFunctionBinding<CSharpDeveloperMixin, string, string>
//    {
//        public static MethodInterceptionBindingWeaver singleton = null;

//        static MethodInterceptionBindingWeaver() {
//            singleton = new MethodInterceptionBindingWeaver();
//        }

//        private MethodInterceptionBindingWeaver() {
//        }

//        public string Invoke(ref CSharpDeveloperMixin instance, IFunctionArgs<string, string> args) {
//            var aspectArgs = new FunctionExecutionArgsImpl<CSharpDeveloperMixin, string, string>(instance, args.Method, args.Arg1);
//            Aspects.traceAspect2.OnEntry(aspectArgs);

//            try {
//                var interArgs = new FunctionInterceptionArgsImpl<CSharpDeveloperMixin, string, string>(instance, aspectArgs.Method, MethodInterceptionBindingWeaver2.singleton, aspectArgs.Arg1);
//                interArgs.Proceed();
//                FunctionArgsMapper.Map<string, string>(interArgs, aspectArgs);
//                Aspects.traceAspect2.OnSuccess(aspectArgs);
//            }
//            finally {
//                Aspects.traceAspect2.OnExit(aspectArgs);
//            }

//            return aspectArgs.ReturnValue;
//        }

//        public string Proceed(ref CSharpDeveloperMixin instance, IFunctionArgs<string, string> args) {
//            var aspectArgs = new FunctionExecutionArgsImpl<CSharpDeveloperMixin, string, string>(instance, args.Method, args.Arg1);
//            Aspects.traceAspect2.OnEntry(aspectArgs);

//            try {
//                var interArgs = new FunctionInterceptionArgsImpl<CSharpDeveloperMixin, string, string>(instance, aspectArgs.Method, MethodDecoratorFunctionBinding.singleton, aspectArgs.Arg1);
//                interArgs.Proceed();
//                FunctionArgsMapper.Map<string, string>(interArgs, aspectArgs);
//                Aspects.traceAspect2.OnSuccess(aspectArgs);
//            }
//            finally {
//                Aspects.traceAspect2.OnExit(aspectArgs);
//            }

//            return aspectArgs.ReturnValue;
//        }
//    }

//    internal static class FunctionArgsMapper
//    {
//        internal static void Map<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> first, IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> second) {
//            second.Arg1 = first.Arg1;
//            second.Arg2 = first.Arg2;
//            second.Arg3 = first.Arg3;
//            second.Arg4 = first.Arg4;
//            second.Arg5 = first.Arg5;
//            second.Arg6 = first.Arg6;
//            second.Arg7 = first.Arg7;
//            second.Arg8 = first.Arg8;
//            second.ReturnValue = first.ReturnValue;
//        }

//        public static void Map<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> first, IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> second) {
//            second.Arg1 = first.Arg1;
//            second.Arg2 = first.Arg2;
//            second.Arg3 = first.Arg3;
//            second.Arg4 = first.Arg4;
//            second.Arg5 = first.Arg5;
//            second.Arg6 = first.Arg6;
//            second.Arg7 = first.Arg7;
//            second.ReturnValue = first.ReturnValue;
//        }

//        public static void Map<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> first, IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> second) {
//            second.Arg1 = first.Arg1;
//            second.Arg2 = first.Arg2;
//            second.Arg3 = first.Arg3;
//            second.Arg4 = first.Arg4;
//            second.Arg5 = first.Arg5;
//            second.Arg6 = first.Arg6;
//            second.ReturnValue = first.ReturnValue;
//        }

//        public static void Map<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> first, IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> second) {
//            second.Arg1 = first.Arg1;
//            second.Arg2 = first.Arg2;
//            second.Arg3 = first.Arg3;
//            second.Arg4 = first.Arg4;
//            second.Arg5 = first.Arg5;
//            second.ReturnValue = first.ReturnValue;
//        }

//        public static void Map<TArg1, TArg2, TArg3, TArg4, TResult>(IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TResult> first, IFunctionArgs<TArg1, TArg2, TArg3, TArg4, TResult> second) {
//            second.Arg1 = first.Arg1;
//            second.Arg2 = first.Arg2;
//            second.Arg3 = first.Arg3;
//            second.Arg4 = first.Arg4;
//            second.ReturnValue = first.ReturnValue;
//        }

//        public static void Map<TArg1, TArg2, TArg3, TResult>(IFunctionArgs<TArg1, TArg2, TArg3, TResult> first, IFunctionArgs<TArg1, TArg2, TArg3, TResult> second) {
//            second.Arg1 = first.Arg1;
//            second.Arg2 = first.Arg2;
//            second.Arg3 = first.Arg3;
//            second.ReturnValue = first.ReturnValue;
//        }

//        public static void Map<TArg1, TArg2, TResult>(IFunctionArgs<TArg1, TArg2, TResult> first, IFunctionArgs<TArg1, TArg2, TResult> second) {
//            second.Arg1 = first.Arg1;
//            second.Arg2 = first.Arg2;
//            second.ReturnValue = first.ReturnValue;
//        }

//        public static void Map<TArg1, TResult>(IFunctionArgs<TArg1, TResult> first, IFunctionArgs<TArg1, TResult> second) {
//            second.Arg1 = first.Arg1;
//            second.ReturnValue = first.ReturnValue;
//        }

//        public static void Map<TArg1>(IActionArgs<TArg1> first, IActionArgs<TArg1> second) {
//            second.Arg1 = first.Arg1;
//            second.Method = second.Method;
//        }

//        public static void Map<TArg1, TArg2, TArg3>(IActionArgs<TArg1, TArg2, TArg3> first, IActionArgs<TArg1, TArg2, TArg3> second) {
//            second.Arg1 = first.Arg1;
//            second.Arg2 = first.Arg2;
//            second.Arg3 = first.Arg3;
//            second.Method = second.Method;
//        }

//        public static void Map<TResult>(IFunctionArgs<TResult> first, IFunctionArgs<TResult> second) {
//            second.ReturnValue = first.ReturnValue;
//        }
//    }

//    public class Person : IPersonComposite
//    {
//        private CSharpDeveloperMixin developer = null;

//        public Person() {
//            developer = new CSharpDeveloperMixin();
//        }

//        public int Code(ref int i, int j, ref int k) {
//            return 0;

//        }

//        public string Code2(string s) {
//            var types = new Type[] { typeof(int).MakeByRefType() };
//            var codeMethod = developer.GetType().GetMethod("Code", types);
//            var aspectArgs = new FunctionInterceptionArgsImpl<CSharpDeveloperMixin, string, string>(developer, codeMethod, MethodInterceptionBindingWeaver.singleton, s);
//            Aspects.traceAspect1.OnInvoke(aspectArgs);

//            return aspectArgs.ReturnValue;
//        }
//    }

//    //[TransientComposite(As = typeof(IPersonComposite))]
//    [Named("IPersonComposite")]
//    [Mixins(typeof(CSharpDeveloperMixin))]
//    public interface IPersonComposite : IDeveloper<ILanguage>
//    {
//        [OnMethodBoundaryAspect(typeof(TraceAspect3), AspectPriority = 0)]
//        [MethodInterceptionAspect(typeof(TraceAspect), AspectPriority = 1)]
//        new int Code(ref int i, int j, ref int k);
//    }


//    [TransientComposite]
//    [Mixins(typeof(CSharpDeveloperMixin))]
//    public interface IPersonComposite2 : IDeveloper<ILanguage>
//    {
//        //[OnMethodBoundaryAspect(typeof(TraceAspect2), AspectPriority = 1)]
//        [MethodInterceptionAspect(typeof(TraceAspect1), AspectPriority = 2)]
//        [OnMethodBoundaryAspect(typeof(TraceAspect2), AspectPriority = 3)]
//        //[OnMethodBoundaryAspect(typeof(TraceAspect2), AspectPriority = 4)]
//        [MethodInterceptionAspect(typeof(TraceAspect1), AspectPriority = 5)]
//        //[OnMethodBoundaryAspect(typeof(TraceAspect2), AspectPriority = 6)]
//        string Code2(string s);
//    }

//    class Program
//    {
//        static void Main(string[] args) {
//            Console.WriteLine(new Person().Code2("1")); return;
//            var settings = new CompositeRuntimeSettings {
//                DependencyContainerAdapter = new StructureMapAdapter()
//            };

//            var container = new CompositeContainer(settings);
//            container.Configure();
//            var person = container.TryResolve<IPersonComposite2>();
//            var returnValue = person.Code2("1");
//            Console.WriteLine(returnValue);
//        }
//    }

//    #region Composites

//    //public class GenericCovariantDeveloper<T> : IDeveloper<T>
//    //	where T : ILanguage, new()
//    //{
//    //	private T langugae = new T();

//    //	public void Code(ref int s) {
//    //		Console.WriteLine(langugae.ToString());
//    //	}
//    //}


//    public class TraceAspect3 : OnFunctionBoundaryAspect<int, int, int, int>
//    {
//        public override void OnEntry(FunctionExecutionArgs<int, int, int, int> args) {
//            Console.WriteLine("Code from TraceAspect3 OnEntry");
//            base.OnEntry(args);
//        }

//        public override void OnExit(FunctionExecutionArgs<int, int, int, int> args) {
//            Console.WriteLine("Code from TraceAspect3 OnExit");
//            base.OnExit(args);
//        }

//        public override void OnException(FunctionExecutionArgs<int, int, int, int> args) {
//            Console.WriteLine("Code from TraceAspect3 OnException");
//            base.OnException(args);
//        }

//        public override void OnSuccess(FunctionExecutionArgs<int, int, int, int> args) {
//            Console.WriteLine("Code from TraceAspect3 OnSuccess");
//            base.OnSuccess(args);
//        }
//    }

//    public class TraceAspect : FunctionInterceptionAspect<int, int, int, int>
//    {
//        public override void OnInvoke(FunctionInterceptionArgs<int, int, int, int> args) {
//            Console.WriteLine("Code from TraceAspect OnInvoke");
//            args.Proceed();
//        }
//    }

//    public class TraceAspect1 : FunctionInterceptionAspect<string, string>
//    {
//        public override void OnInvoke(FunctionInterceptionArgs<string, string> args) {
//            base.OnInvoke(args);

//            if (args.ReturnValue != null) {
//                args.ReturnValue = args.ReturnValue + (int.Parse(new string(new char[] { args.ReturnValue.Last() })) + 1).ToString();
//            }
//        }
//    }

//    [PerThreadAspect]
//    public class TraceAspect2 : OnFunctionBoundaryAspect<string, string>
//    {
//        public override void OnEntry(FunctionExecutionArgs<string, string> args) {
//            base.OnEntry(args);

//            if (args.ReturnValue != null) {
//                args.ReturnValue = args.ReturnValue + (int.Parse(new string(new char[] { args.ReturnValue.Last() })) + 1).ToString();
//            }
//        }

//        public override void OnSuccess(FunctionExecutionArgs<string, string> args) {
//            base.OnSuccess(args);

//            if (args.ReturnValue != null) {
//                args.ReturnValue = args.ReturnValue + (int.Parse(new string(new char[] { args.ReturnValue.Last() })) + 1).ToString();
//            }
//        }

//        public override void OnException(FunctionExecutionArgs<string, string> args) {
//            if (args.ReturnValue != null) {
//                args.ReturnValue = args.ReturnValue + (int.Parse(new string(new char[] { args.ReturnValue.Last() })) + 1).ToString();
//            }

//            base.OnException(args);
//        }

//        public override void OnExit(FunctionExecutionArgs<string, string> args) {
//            base.OnExit(args);

//            if (args.ReturnValue != null) {
//                args.ReturnValue = args.ReturnValue + (int.Parse(new string(new char[] { args.ReturnValue.Last() })) + 1).ToString();
//            }
//        }
//    }

//    public class CSharpDeveloperMixin2
//    {
//        public int Code(int i, int j, int k) {
//            return i = k = 10;
//        }
//    }

//    [Named("CSharpDeveloperMixin")]
//    public class CSharpDeveloperMixin : AbstractDeveloper<CSharpLanguage5>
//    {
//        public override int Code(ref int i, int j, ref int k) {
//            return i = k = 10;
//        }
//    }

//    public class JavaScriptDeveloperMixin : AbstractDeveloper<JavaScriptLanguage>
//    {

//    }

//    public abstract class AbstractDeveloper<TLanguage> : IDeveloper<TLanguage>
//        where TLanguage : ILanguage, new()
//    {
//        private readonly ILanguage language = new TLanguage();

//        public virtual int Code(ref int i, int j, ref int k) {
//            Console.WriteLine("I am coding in " + language.ToString());
//            return 10;
//        }

//        public string Code2(string s) {
//            return s;
//        }
//    }

//    public interface ILanguage
//    {
//        string Description { get; }
//    }

//    public class CSharpLanguage : ILanguage
//    {
//        public virtual string Description {
//            get {
//                return "C#";
//            }
//        }
//    }

//    public class JavaScriptLanguage : ILanguage
//    {
//        public string Description {
//            get {
//                return "JavaScript";
//            }
//        }
//    }

//    public class CSharpLanguage5 : CSharpLanguage
//    {
//        public override string Description {
//            get {
//                return "C# 5";
//            }
//        }
//    }

//    public interface IDeveloper<out TLanguage>
//    {
//        string Code2(string s);
//        int Code(ref int i, int j, ref int k);
//    }

//    public interface IDeveloper
//    {
//        void Code(int code);
//    }

//    #endregion Composites
//}