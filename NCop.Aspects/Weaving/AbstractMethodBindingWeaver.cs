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
using NCop.Aspects.Extensions;
using MA = System.Reflection.MethodAttributes;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractMethodBindingWeaver : IMethodBindingWeaver
    {
        protected static int bindingCounter = 0;
        protected TypeBuilder typeBuilder = null;
        protected FieldBuilder fieldBuilder = null;
        protected BindingSettings bindingSettings = null;
        protected readonly IMethodScopeWeaver methodScopeWeaver = null;
        protected readonly MethodAttributes methodAttr = MA.Public | MA.Final | MA.HideBySig | MA.NewSlot | MA.Virtual;
        protected readonly CallingConventions callingConventions = CallingConventions.Standard | CallingConventions.HasThis;

        internal AbstractMethodBindingWeaver(BindingSettings bindingSettings, IMethodScopeWeaver methodScopeWeaver) {
            this.bindingSettings = bindingSettings;
            this.methodScopeWeaver = methodScopeWeaver;
        }

        public FieldInfo Weave() {
            FieldInfo weavedMember = null;
            Type bindingMethodType = null;
            var typeBuilder = WeaveTypeBuilder();

            WeaveConstructors(typeBuilder);
            WeaveInvokeMethod();
            bindingMethodType = typeBuilder.CreateType();
            weavedMember = bindingMethodType.GetField(fieldBuilder.Name, BindingFlags.NonPublic | BindingFlags.Static);

            return weavedMember;
        }

        protected TypeBuilder WeaveTypeBuilder() {
            var attrs = TypeAttributes.Public | TypeAttributes.Sealed;

            return typeBuilder = typeof(object).DefineType("MethodBinding_{0}".Fmt(Interlocked.Increment(ref bindingCounter)).ToUniqueName(), new[] { bindingSettings.BindingType }, attrs);            
        }

        protected virtual void WeaveConstructors(TypeBuilder typeBuilder) {
            var fieldAttrs = FieldAttributes.Private | FieldAttributes.FamANDAssem | FieldAttributes.Static;
            var ctorAttrs = MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName;
            var cctor = typeBuilder.DefineConstructor(ctorAttrs | MethodAttributes.Static, CallingConventions.Standard, Type.EmptyTypes);
            var cctorILGenerator = cctor.GetILGenerator();
            var defaultCtor = typeBuilder.DefineConstructor(ctorAttrs, CallingConventions.Standard | CallingConventions.HasThis, Type.EmptyTypes);
            var bindingTypeCtor = typeof(object).GetConstructor(Type.EmptyTypes);
            var defaultCtorGenerator = defaultCtor.GetILGenerator();

            fieldBuilder = typeBuilder.DefineField("singleton", typeBuilder, fieldAttrs);

            defaultCtorGenerator.EmitLoadArg(0);
            defaultCtorGenerator.Emit(OpCodes.Call, bindingTypeCtor);
            defaultCtorGenerator.Emit(OpCodes.Ret);

            cctorILGenerator.Emit(OpCodes.Newobj, defaultCtor);
            cctorILGenerator.Emit(OpCodes.Stsfld, fieldBuilder);
            cctorILGenerator.Emit(OpCodes.Ret);
        }

        protected virtual MethodParameters ResolveParameterTypes() {
			Func<Type[], Type> argumentResolver = null;
            var methodParameters = new MethodParameters();
            var arguments = bindingSettings.BindingType.GetGenericArguments();

			methodParameters.Parameters = new Type[2];
            methodParameters.Parameters[0] = arguments[0].MakeByRefType();
			arguments = arguments.Skip(1).ToArray();

            if (bindingSettings.ArgumentsWeaver.IsFunction) {
                methodParameters.ReturnType = arguments.Last();
				argumentResolver = AspectArgsContractResolver.ToFunctionAspectArgument;
            }
            else {
				argumentResolver = AspectArgsContractResolver.ToActionAspectArgument;
            }

			methodParameters.Parameters[1] = argumentResolver(arguments);
            return methodParameters;
        }

        protected abstract void WeaveInvokeMethod();
    }
}
