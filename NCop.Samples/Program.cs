using System;
using System.Linq;
using System.Reflection;
using NCop.Aspects.Aspects;
using NCop.Aspects.Framework;
using NCop.Composite.Framework;
using NCop.Core.Extensions;
using NCop.Mixins.Framework;
using NCop.Aspects.Advices;
using NCop.Aspects.Engine;
using System.Runtime.CompilerServices;
using System.Reflection.Emit;
using NCop.IoC;
using System.Collections.Generic;

namespace NCop.Samples
{
	internal static class Aspects
	{
		public static TraceAspect traceAspect = null;
		public static TraceAspect2 traceAspect2 = null;
		public static TraceAspect2 traceAspect3 = null;

		static Aspects() {
			traceAspect = new TraceAspect();
			traceAspect2 = new TraceAspect2();
			traceAspect3 = new TraceAspect2();
		}
	}

	public sealed class MethodDecoratorFunctionBinding : IFunctionBinding<CSharpDeveloperMixin, string, bool>
	{
		public static MethodDecoratorFunctionBinding singleton = null;

		static MethodDecoratorFunctionBinding() {
			singleton = new MethodDecoratorFunctionBinding();
		}

		private MethodDecoratorFunctionBinding() {
		}

		public bool Invoke(ref CSharpDeveloperMixin instance, IFunctionArgs<string, bool> args) {
			return instance.Code(args.Arg1);
		}
	}

	public sealed class OnMethodInterceptionBindingWeaver : IFunctionBinding<CSharpDeveloperMixin, string, bool>
	{
		public static OnMethodInterceptionBindingWeaver singleton = null;

		static OnMethodInterceptionBindingWeaver() {
			singleton = new OnMethodInterceptionBindingWeaver();
		}

		private OnMethodInterceptionBindingWeaver() {
		}

		public bool Invoke(ref CSharpDeveloperMixin instance, IFunctionArgs<string, bool> args) {
			var aspectArgs = new FunctionInterceptionArgsImpl<CSharpDeveloperMixin, string, bool>(instance, MethodDecoratorFunctionBinding.singleton, args.Arg1);

			Aspects.traceAspect.OnInvoke(aspectArgs);
			FunctionArgsMapper.Map(aspectArgs, args);

			return args.ReturnValue;
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

		public static void Map<TResult>(IFunctionArgs<TResult> first, IFunctionArgs<TResult> second) {
			second.ReturnValue = first.ReturnValue;
		}
	}

	internal class AspectArgsMapperWeaver
	{
		public void Weave() {
			var assemblyName = new AssemblyName("Stam");
			var da = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
			string assemblyNameStr = "{0}.dll".Fmt("Stam");
			var dm = da.DefineDynamicModule(assemblyNameStr, false);

			var typeAttrs = TypeAttributes.NotPublic | TypeAttributes.Abstract | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit;
			var funcAspectArgMapperTypeBuilder = dm.DefineType("FunctionArgsMapper", typeAttrs, typeof(object));
			var actionAspectArgMapperTypeBuilder = dm.DefineType("ActionArgsMapper", typeAttrs, typeof(object));
			var methodAttr = MethodAttributes.Private | MethodAttributes.FamANDAssem | MethodAttributes.Static | MethodAttributes.HideBySig;

			Enumerable.Range(1, 8).ForEach(i => {
				Type funcArgumentType = null;
				Type actionArgumentType = null;
				ILGenerator funcILGenerator = null;
				ILGenerator actionILGenerator = null;
				PropertyInfo returnValueProperty = null;
				Type genericTypeFuncArgumentType = null;
				Type genericTypeActionArgumentType = null;
				GenericTypeParameterBuilder[] genericParameters = null;
				var funcArgsMethodBuilder = funcAspectArgMapperTypeBuilder.DefineMethod("Map", methodAttr, CallingConventions.Standard);
				var actionArgsMethodBuilder = actionAspectArgMapperTypeBuilder.DefineMethod("Map", methodAttr, CallingConventions.Standard);
				var genericArgumentsArray = Enumerable.Range(1, i)
													  .Select(j => "Arg{0}".Fmt(j))
													  .ToList();

				genericParameters = actionArgsMethodBuilder.DefineGenericParameters(genericArgumentsArray.ToArray());
				actionArgumentType = typeof(IActionArgs<>).MakeGenericType(genericParameters);
				genericTypeActionArgumentType = actionArgumentType.GetGenericTypeDefinition();
				actionArgsMethodBuilder.SetParameters(new Type[] { actionArgumentType, actionArgumentType });
				genericArgumentsArray.Add("TResult");
				genericParameters = funcArgsMethodBuilder.DefineGenericParameters(genericArgumentsArray.ToArray());
				funcArgumentType = typeof(IFunctionArgs<,>).MakeGenericType(genericParameters);
				genericTypeFuncArgumentType = funcArgumentType.GetGenericTypeDefinition();
				funcArgsMethodBuilder.SetParameters(new Type[] { funcArgumentType, funcArgumentType });
				funcILGenerator = actionArgsMethodBuilder.GetILGenerator();
				actionILGenerator = actionArgsMethodBuilder.GetILGenerator();

				Enumerable.Range(1, i)
						  .ForEach(j => {
							  var funcPropertyInfo = genericTypeFuncArgumentType.GetPublicProperty("Arg{0}".Fmt(j));
							  var actionPropertyInfo = genericTypeActionArgumentType.GetPublicProperty("Arg{0}".Fmt(j));

							  funcILGenerator.Emit(OpCodes.Ldarg_1);
							  actionILGenerator.Emit(OpCodes.Ldarg_1);
							  funcILGenerator.Emit(OpCodes.Ldarg_0);
							  actionILGenerator.Emit(OpCodes.Ldarg_0);

							  funcILGenerator.Emit(OpCodes.Callvirt, funcPropertyInfo.GetGetMethod());
							  actionILGenerator.Emit(OpCodes.Callvirt, actionPropertyInfo.GetGetMethod());
							  funcILGenerator.Emit(OpCodes.Callvirt, funcPropertyInfo.GetSetMethod());
							  actionILGenerator.Emit(OpCodes.Callvirt, actionPropertyInfo.GetSetMethod());
						  });

				returnValueProperty = genericTypeFuncArgumentType.GetPublicProperty("ReturnValue");
				funcILGenerator.Emit(OpCodes.Callvirt, returnValueProperty.GetGetMethod());
				actionILGenerator.Emit(OpCodes.Callvirt, returnValueProperty.GetGetMethod());

				funcILGenerator.Emit(OpCodes.Ret);
				actionILGenerator.Emit(OpCodes.Ret);
			});

			var type = funcAspectArgMapperTypeBuilder.CreateType();
			type = funcAspectArgMapperTypeBuilder.CreateType();
		}
	}

	public class ExampleBase { }

	public interface IExampleA { }

	public interface IExampleB { }

	// Define a trivial type that can substitute for type parameter  
	// TSecond. 
	// 
	public class ExampleDerived : ExampleBase, IExampleA, IExampleB { }

	class Program
	{
		static void Main(string[] args) {
			new AspectArgsMapperWeaver().Weave();
			new Person().Code("CSharp");
			var container = new CompositeContainer();
			container.Configure();

			var person = container.TryResolve<IPersonComposite>();
			person.Code("CSharp");
		}
	}

	#region Composites

	public class GenericCovariantDeveloper<T> : IDeveloper<T>
		where T : ILanguage, new()
	{
		private T langugae = new T();

		public bool Code(string code) {
			Console.WriteLine(code);

			return false;
		}
	}

	public class TraceAspect : FunctionInterceptionAspect<string, bool>
	{
		public override bool OnInvoke(FunctionInterceptionArgs<string, bool> args) {
			args.Arg1 = "JavaScript";
			return base.OnInvoke(args);
		}
	}

	[PerThreadAspect]
	public class TraceAspect2 : OnFunctionBoundaryAspect<string, bool>
	{
		public override void OnEntry(FunctionExecutionArgs<string, bool> args) {
			base.OnEntry(args);
		}

		public override void OnSuccess(FunctionExecutionArgs<string, bool> args) {
			base.OnSuccess(args);
		}

		public override void OnException(FunctionExecutionArgs<string, bool> args) {
			base.OnException(args);
		}

		public override void OnExit(FunctionExecutionArgs<string, bool> args) {
			base.OnExit(args);
		}
	}

	[TransientComposite]
	[Mixins(typeof(CSharpDeveloperMixin))]
	public interface IPersonComposite : IDeveloper<ILanguage>
	{
		//[OnMethodBoundaryAspect(typeof(TraceAspect2), AspectPriority = 2)]
		//[OnMethodBoundaryAspect(typeof(TraceAspect2), AspectPriority = 4)]
		[MethodInterceptionAspect(typeof(TraceAspect), AspectPriority = 1)]
		//[OnMethodBoundaryAspect(typeof(TraceAspect2), AspectPriority = 3)]
		//[MethodInterceptionAspect(typeof(TraceAspect), AspectPriority = 2)]
		new bool Code(string code);
	}

	public class Person : IPersonComposite
	{
		private CSharpDeveloperMixin developer = null;

		public Person() {
			developer = new CSharpDeveloperMixin();
		}

		public bool Code(string code) {
			var binding = OnMethodInterceptionBindingWeaver.singleton;
			var args = new FunctionInterceptionArgsImpl<CSharpDeveloperMixin, string, bool>(developer, binding, code);
			return Aspects.traceAspect.OnInvoke(args);
		}
	}

	public class CSharpDeveloperMixin : AbstractDeveloper<CSharpLanguage5>
	{
		public override bool Code(string code) {
			return base.Code(code);
		}
	}

	public class JavaScriptDeveloperMixin : AbstractDeveloper<JavaScriptLanguage>
	{

	}

	public abstract class AbstractDeveloper<TLanguage> : IDeveloper<TLanguage>
		where TLanguage : ILanguage, new()
	{
		public virtual bool Code(string code) {
			Console.WriteLine("I am coding in " + code);
			return false;
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
		bool Code(string code);
	}

	public interface IDeveloper
	{
		void Code(string code);
	}

	#endregion Composites
}