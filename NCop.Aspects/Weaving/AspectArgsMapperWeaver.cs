using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NCop.Weaving;
using NCop.Core.Extensions;
using System.Reflection.Emit;
using NCop.Aspects.Engine;
using NCop.Weaving.Extensions;

namespace NCop.Aspects.Weaving
{
	internal class AspectArgsMapperWeaver : IWeaver
	{
		internal Dictionary<int, MethodInfo> funcAspectArgMapperMethodsDictionary = null;
		internal Dictionary<int, MethodInfo> actionAspectArgMapperMethodsDictionary = null;

		public AspectArgsMapperWeaver() {
			funcAspectArgMapperMethodsDictionary = new Dictionary<int, MethodInfo>();
			actionAspectArgMapperMethodsDictionary = new Dictionary<int, MethodInfo>();
		}

		public void Weave() {
			var typeAttrs = TypeAttributes.NotPublic | TypeAttributes.Abstract | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit;
			var funcAspectArgMapperTypeBuilder = typeof(object).DefineType("FunctionArgsMapper".ToUniqueName(), attributes: typeAttrs);
			var actionAspectArgMapperTypeBuilder = typeof(object).DefineType("ActionArgsMapper".ToUniqueName(), attributes: typeAttrs);
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
				actionArgumentType = ResolveIFunctionArgsType(i).MakeGenericType(genericParameters);
				actionArgsMethodBuilder.SetParameters(new Type[] { actionArgumentType, actionArgumentType });
				genericArgumentsArray.Add("TResult");
				genericParameters = funcArgsMethodBuilder.DefineGenericParameters(genericArgumentsArray.ToArray());
				funcArgumentType = ResolveIActionArgsType(i).MakeGenericType(genericParameters);
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
		}

		private Type ResolveIFunctionArgsType(int count) {
			switch (count) {
				case 0:
					return typeof(IFunctionArgs<>);
				case 1:
					return typeof(IFunctionArgs<,>);
				case 2:
					return typeof(IFunctionArgs<,,>);
				case 3:
					return typeof(IFunctionArgs<,,,>);
				case 4:
					return typeof(IFunctionArgs<,,,,>);
				case 5:
					return typeof(IFunctionArgs<,,,,,>);
				case 6:
					return typeof(IFunctionArgs<,,,,,,>);
				case 7:
					return typeof(IFunctionArgs<,,,,,,,>);
				case 8:
					return typeof(IFunctionArgs<,,,,,,,,>);
				default:
					return null;
			}
		}

		private Type ResolveIActionArgsType(int count) {
			switch (count) {
				case 0:
					return typeof(IActionArgs);
				case 1:
					return typeof(IActionArgs<>);
				case 2:
					return typeof(IActionArgs<,>);
				case 3:
					return typeof(IActionArgs<,,>);
				case 4:
					return typeof(IActionArgs<,,,>);
				case 5:
					return typeof(IActionArgs<,,,,>);
				case 6:
					return typeof(IActionArgs<,,,,,>);
				case 7:
					return typeof(IActionArgs<,,,,,,>);
				case 8:
					return typeof(IActionArgs<,,,,,,,>);
				default:
					return null;
			}
		}
	}
}
