using NCop.Aspects.Engine;
using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Mixins.Framework;
using System;
using NCop.IoC;
using NCop.Composite.Runtime;

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

	public class A
	{
		public int Invoke(ref CSharpDeveloperMixin instance, IFunctionArgs<int, int, int, int> args) {
			var i = args.Arg1;
			var k = args.Arg3;

			args.ReturnValue = instance.Code(ref i, args.Arg2, ref k);

			args.Arg1 = i;
			args.Arg3 = k;

			return args.ReturnValue;
		}

		public int Invoke2(ref CSharpDeveloperMixin2 instance, IFunctionArgs<int, int, int, int> args) {
			//var i = args.Arg1;
			//var k = args.Arg3;

			args.ReturnValue = instance.Code(args.Arg1, args.Arg2, args.Arg3);

			//args.Arg1 = i;
			//            args.Arg3 = k;

			return args.ReturnValue;
		}

		public int Invoke3(ref CSharpDeveloperMixin2 instance, IFunctionArgs<int, int, int, int> args) {
			return instance.Code(args.Arg1, args.Arg2, args.Arg3);
		}
	}

	public sealed class MethodDecoratorFunctionBinding : IFunctionBinding<CSharpDeveloperMixin, int, int, int, int>
	{
		public static MethodDecoratorFunctionBinding singleton = null;

		static MethodDecoratorFunctionBinding() {
			singleton = new MethodDecoratorFunctionBinding();
		}

		private MethodDecoratorFunctionBinding() {
		}

		public int Proceed(ref CSharpDeveloperMixin instance, IFunctionArgs<int, int, int, int> args) {
			var arg1 = args.Arg1;
			var arg3 = args.Arg3;

			args.ReturnValue = instance.Code(ref arg1, args.Arg2, ref arg3);

			args.Arg1 = arg1;
			args.Arg3 = arg3;

			return args.ReturnValue;
		}

		public int Invoke(ref CSharpDeveloperMixin instance, IFunctionArgs<int, int, int, int> args) {
			var i = args.Arg1;
			var k = args.Arg3;

			args.ReturnValue = instance.Code(ref i, args.Arg2, ref k);

			args.Arg1 = i;
			args.Arg3 = k;

			return args.ReturnValue;
		}
	}

	public sealed class MethodInterceptionBindingWeaver : IFunctionBinding<CSharpDeveloperMixin, int, int, int, int>
	{
		public static MethodInterceptionBindingWeaver singleton = null;

		static MethodInterceptionBindingWeaver() {
			singleton = new MethodInterceptionBindingWeaver();
		}

		private MethodInterceptionBindingWeaver() {
		}

		public int Invoke(ref CSharpDeveloperMixin instance, IFunctionArgs<int, int, int, int> args) {
			var i = args.Arg1;
			var k = args.Arg3;

			args.ReturnValue = instance.Code(ref i, args.Arg2, ref k);

			args.Arg1 = i;
			args.Arg3 = k;

			return args.ReturnValue;
		}

		public int Proceed(ref CSharpDeveloperMixin instance, IFunctionArgs<int, int, int, int> args) {
			//var aspectArgs = new FunctionInterceptionArgsImpl<CSharpDeveloperMixin, int, int, int, int>(instance, args.Method, MethodDecoratorFunctionBinding.singleton, args.Arg1, args.Arg2, args.Arg3);

			//Aspects.traceAspect.OnInvoke(aspectArgs);
			//FunctionArgsMapper.Map<int, int, int, int>(aspectArgs, args);

			//return args.ReturnValue;
			//var binding = MethodDecoratorFunctionBinding.singleton;
			var aspectArgs = new FunctionExecutionArgsImpl<CSharpDeveloperMixin, int, int, int, int>(instance, args.Method, args.Arg1, args.Arg2, args.Arg3);
			Aspects.traceAspect3.OnEntry(aspectArgs);

			try {
				var i = aspectArgs.Arg1;
				var k = aspectArgs.Arg3;
				aspectArgs.ReturnValue = instance.Code(ref i, aspectArgs.Arg2, ref k);
				aspectArgs.Arg1 = i;
				aspectArgs.Arg3 = k;
				Aspects.traceAspect3.OnSuccess(aspectArgs);
			}
			finally {
				Aspects.traceAspect3.OnExit(aspectArgs);
			}

			return aspectArgs.ReturnValue;
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

		public int Code(ref int i, int j, ref int k) {
			var types = new Type[] { typeof(int).MakeByRefType() };
			var codeMethod = developer.GetType().GetMethod("Code", types);
			//var aspectArgs = new ActionExecutionArgsImpl<CSharpDeveloperMixin, int, int, int>(developer, codeMethod, i, j, k);
			//var interArgs = new ActionInterceptionArgsImpl<CSharpDeveloperMixin, int, int, int>(developer, codeMethod, MethodInterceptionBindingWeaver.singleton, i, j, k);
			//Aspects.traceAspect3.OnEntry(aspectArgs);
			//Aspects.traceAspect3.OnEntry(aspectArgs);
			var interArgs = new FunctionInterceptionArgsImpl<CSharpDeveloperMixin, int, int, int, int>(developer, codeMethod, MethodInterceptionBindingWeaver.singleton, i, j, k);

			try {
				Aspects.traceAspect.OnInvoke(interArgs);
			}
			finally {
				i = interArgs.Arg1;
				k = interArgs.Arg3;
			}
			return interArgs.ReturnValue;
		}

		public int Code2(ref int i, int j, ref int k) {
			var types = new Type[] { typeof(int).MakeByRefType() };
			var codeMethod = developer.GetType().GetMethod("Code", types);
			var aspectArgs = new FunctionExecutionArgsImpl<CSharpDeveloperMixin, int, int, int, int>(developer, codeMethod, i, j, k);
			Aspects.traceAspect3.OnEntry(aspectArgs);

			try {
				i = aspectArgs.Arg1;
				k = aspectArgs.Arg3;
				aspectArgs.ReturnValue = developer.Code(ref i, aspectArgs.Arg2, ref k);
				aspectArgs.Arg1 = i;
				aspectArgs.Arg3 = j;
				Aspects.traceAspect3.OnSuccess(aspectArgs);
			}
			//catch (Exception ex) {
			//    aspectArgs.Exception = ex;
			//    Aspects.traceAspect3.OnException(aspectArgs);

			//    if (aspectArgs.FlowBehavior == FlowBehavior.RethrowException) {
			//        throw;
			//    }
			//}
			finally {
				Aspects.traceAspect3.OnExit(aspectArgs);
			}

			return aspectArgs.ReturnValue;
		}
	}

	[TransientComposite]
	[Mixins(typeof(CSharpDeveloperMixin))]
	public interface IPersonComposite : IDeveloper<ILanguage>
	{
		[OnMethodBoundaryAspect(typeof(TraceAspect3), AspectPriority = 0)]
		[MethodInterceptionAspect(typeof(TraceAspect), AspectPriority = 1)]
		new int Code(ref int i, int j, ref int k);
	}

	public class MockContainer : INCopDependencyContainerAdapter
	{
		private object mixin = new Person();
		private Type type = null;

		int counter = 0;

		public void Configure() {
		}

		public TService Resolve<TService>() {
			return (TService)mixin;
		}

		public TService TryResolve<TService>() {
			return (TService)mixin;
		}

		public TService ResolveNamed<TService>(string name) {
			return (TService)mixin;
		}

		public TService TryResolveNamed<TService>(string name) {
			return (TService)mixin;
		}

		public void Dispose() {

		}

		public INCopDependencyResolver CreateChildContainer() {
			return this;
		}

		public void Register(Type concreteType, Type serviceType) {
			if (counter > 0) {
				type = serviceType;
				mixin = Activator.CreateInstance(concreteType, new object[] { new CSharpDeveloperMixin() });
			}

			counter++;
		}
	}

	class Program
	{
		static void Main(string[] args) {
			int i = 0, j = 0, k = 0;
			//new Person().Code(ref i, j, ref k); return;
			var settings = new CompositeRuntimeSettings {
				DependencyContainerAdapter = new MockContainer(),
				Assemblies = new[] { typeof(MockContainer).Assembly }
			};

			var container = new CompositeContainer(settings);
			container.Configure();
			var person = container.TryResolve<IPersonComposite>();
			person.Code(ref i, j, ref k);
			Console.WriteLine(i);
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


	public class TraceAspect3 : OnFunctionBoundaryAspect<int, int, int, int>
	{
		public override void OnEntry(FunctionExecutionArgs<int, int, int, int> args) {
			Console.WriteLine("Code from TraceAspect3 OnEntry");
			base.OnEntry(args);
		}

		public override void OnExit(FunctionExecutionArgs<int, int, int, int> args) {
			Console.WriteLine("Code from TraceAspect3 OnExit");
			args.Arg1 = 10;
			base.OnExit(args);
		}

		public override void OnException(FunctionExecutionArgs<int, int, int, int> args) {
			Console.WriteLine("Code from TraceAspect3 OnException");
			base.OnException(args);
		}

		public override void OnSuccess(FunctionExecutionArgs<int, int, int, int> args) {
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

	public class CSharpDeveloperMixin2
	{
		public int Code(int i, int j, int k) {
			return i = k = 10;
		}
	}

	public class CSharpDeveloperMixin : AbstractDeveloper<CSharpLanguage5>
	{
		public override int Code(ref int i, int j, ref int k) {
			return i = k = 10;
		}
	}

	public class JavaScriptDeveloperMixin : AbstractDeveloper<JavaScriptLanguage>
	{

	}

	public abstract class AbstractDeveloper<TLanguage> : IDeveloper<TLanguage>
		where TLanguage : ILanguage, new()
	{
		private readonly ILanguage language = new TLanguage();

		public virtual int Code(ref int i, int j, ref int k) {
			Console.WriteLine("I am coding in " + language.ToString());
			return 10;
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
		int Code(ref int i, int j, ref int k);
	}

	public interface IDeveloper
	{
		void Code(int code);
	}

	#endregion Composites
}