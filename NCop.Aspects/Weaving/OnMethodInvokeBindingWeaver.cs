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
	internal class OnMethodInvokeBindingWeaver : IMethodBindingWeaver
	{
		private static int bindingCounter = 1;
		private FieldBuilder fieldBuilder = null;
        private readonly BindingSettings bindingSettings = null;
		private readonly IMethodScopeWeaver methodScopeWeaver = null;

        internal OnMethodInvokeBindingWeaver(BindingSettings bindingSettings, IMethodScopeWeaver methodScopeWeaver) {
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

		private void WeaveInvokeMethod(TypeBuilder typeBuilder) {
			Type[] parametersTypes = null;
			Type returnType = typeof(void);
			ILGenerator ilGenerator = null;
            LocalBuilder argsBuilder = null;
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

			ilGenerator = typeBuilder.DefineMethod("Invoke", methodAttr, returnType, parametersTypes).GetILGenerator();
            argsBuilder = bindingSettings.ArgumentsWeaver.Weave(ilGenerator);
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

		private TypeBuilder WeaveTypeBuilder() {
			var attrs = TypeAttributes.NotPublic | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit;

            return typeof(object).DefineType("MethodBinding_{0}".Fmt(bindingCounter).ToUniqueName(), interfaces: new[] { bindingSettings.BindingType }, attributes: attrs);
		}
	}
}
