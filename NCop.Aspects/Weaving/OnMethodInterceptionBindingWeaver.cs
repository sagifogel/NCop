using NCop.Aspects.Advices;
using NCop.Aspects.Aspects;
using NCop.Aspects.Weaving.Expressions;
using NCop.Composite.Weaving;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using NCop.Aspects.Framework;
using NCop.Aspects.Engine;
using NCop.Core.Extensions;
using System.Threading;
using NCop.Weaving.Extensions;

namespace NCop.Aspects.Weaving
{
	internal class OnMethodInterceptionBindingWeaver : IMethodBindingWeaver, ITypeDefinition
	{
		private static int bindingCounter = 1;
		private FieldBuilder fieldBuilder = null;
		private readonly BindingSettings bindingSettings = null;
		private readonly IMethodScopeWeaver methodScopeWeaver = null;

		internal OnMethodInterceptionBindingWeaver(BindingSettings bindingSettings, IMethodScopeWeaver methodScopeWeaver) {
			this.bindingSettings = bindingSettings;
			this.methodScopeWeaver = methodScopeWeaver;
		}

		public MemberInfo Weave() {
			MemberInfo weavedMember = null;
			Type bindingMethodType = null;
			var typeBuilder = WeaveTypeBuilder();

			WeaveConstructors(typeBuilder);
			WeaveInvokeMethod(typeBuilder);
			bindingMethodType = typeBuilder.CreateType();
			weavedMember = bindingMethodType.GetField(fieldBuilder.Name, BindingFlags.NonPublic | BindingFlags.Static);
			Interlocked.Increment(ref bindingCounter);

			return weavedMember;
		}

		private TypeBuilder WeaveTypeBuilder() {
			var attrs = TypeAttributes.NotPublic | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit;

			return TypeBuilder = typeof(object).DefineType("MethodBinding_{0}".Fmt(bindingCounter).ToUniqueName(), new[] { bindingSettings.BindingType }, attrs);
		}

		private void WeaveInvokeMethod(TypeBuilder typeBuilder) {
			Type[] parametersTypes = null;
			Type returnType = typeof(void);
			ILGenerator ilGenerator = null;
			LocalBuilder argsBuilder = null;
			LocalBuilder returnTypeBuilder = null;
			var methodAttr = MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual;
			var arguments = bindingSettings.BindingType.GetGenericArguments();

			if (bindingSettings.IsFunction) {
				int length = arguments.Length - 1;

				returnType = arguments.Last();
				parametersTypes = new Type[length];
				Array.Copy(arguments, 0, parametersTypes, 0, length);
			}
			else {
				parametersTypes = arguments;
			}

			parametersTypes[0] = parametersTypes[0].MakeByRefType();
			ilGenerator = typeBuilder.DefineMethod("Invoke", methodAttr, returnType, parametersTypes).GetILGenerator();
			argsBuilder = bindingSettings.ArgumentsWeaver.Weave(ilGenerator);

			if (bindingSettings.IsFunction) {
				returnTypeBuilder = ilGenerator.DeclareLocal(returnType);
			}

			ilGenerator.EmitLoadArg(1);
			ilGenerator.Emit(OpCodes.Ldind_Ref);

			parametersTypes.ForEach(1, (parameter, i) => {
				ilGenerator.EmitLoadArg(i);
			});

			ilGenerator.Emit(OpCodes.Newobj, bindingSettings.ArgumentsWeaver.ArgsType);
			ilGenerator.EmitStoreLocal(argsBuilder);
			methodScopeWeaver.Weave(ilGenerator);
		}

		private void WeaveConstructors(TypeBuilder typeBuilder) {
			var fieldAttrs = FieldAttributes.FamANDAssem | FieldAttributes.Static;
			var ctorAttrs = MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName;
			var cctor = typeBuilder.DefineConstructor(ctorAttrs | MethodAttributes.Static | MethodAttributes.PrivateScope, CallingConventions.Standard, Type.EmptyTypes).GetILGenerator();
			var defaultCtor = typeBuilder.DefineConstructor(ctorAttrs, CallingConventions.Standard, Type.EmptyTypes).GetILGenerator();
			var bindingTypeCtor = typeof(object).GetConstructor(Type.EmptyTypes);

			fieldBuilder = typeBuilder.DefineField("singleton", typeBuilder, fieldAttrs);

			defaultCtor.EmitLoadArg(0);
			defaultCtor.Emit(OpCodes.Call, bindingTypeCtor);
			defaultCtor.Emit(OpCodes.Ret);

			cctor.Emit(OpCodes.Newobj, typeBuilder);
			cctor.Emit(OpCodes.Stsfld, fieldBuilder);
			cctor.Emit(OpCodes.Ret);
		}

		public Type Type {
			get {
				return TypeBuilder;
			}
		}

		public TypeBuilder TypeBuilder { get; private set; }

		public FieldBuilder GetFieldBuilder(Type type) {
			return null;
		}
	}
}
