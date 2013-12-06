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
    internal abstract class AbstractMethodBindingWeaver : IMethodBindingWeaver
    {
        protected static int bindingCounter = 1;
        protected TypeBuilder typeBuilder = null;
        protected FieldBuilder fieldBuilder = null;
        protected readonly BindingSettings bindingSettings = null;
        protected readonly IMethodScopeWeaver methodScopeWeaver = null;

        internal AbstractMethodBindingWeaver(BindingSettings bindingSettings, IMethodScopeWeaver methodScopeWeaver) {
            this.bindingSettings = bindingSettings;
            this.methodScopeWeaver = methodScopeWeaver;
        }

        public FieldInfo Weave(ILGenerator ilGenerator) {
            FieldInfo weavedMember = null;
            Type bindingMethodType = null;
            var typeBuilder = WeaveTypeBuilder();

            WeaveConstructors(typeBuilder);
            WeaveInvokeMethod();
            bindingMethodType = typeBuilder.CreateType();
            weavedMember = bindingMethodType.GetField(fieldBuilder.Name, BindingFlags.NonPublic | BindingFlags.Static);
            Interlocked.Increment(ref bindingCounter);

            return weavedMember;
        }

        protected TypeBuilder WeaveTypeBuilder() {
            var attrs = TypeAttributes.NotPublic | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit;

            return typeBuilder = typeof(object).DefineType("MethodBinding_{0}".Fmt(bindingCounter).ToUniqueName(), new[] { bindingSettings.BindingType }, attrs);
        }

        protected virtual void WeaveConstructors(TypeBuilder typeBuilder) {
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

        protected virtual ILGenerator WeaveLoadArgs() {
            Type[] parametersTypes = null;
            Type returnType = typeof(void);
            ILGenerator ilGenerator = null;
            LocalBuilder returnTypeBuilder = null;
            IAspectArgumentWeaver argumentsWeaver = null;
            var arguments = bindingSettings.BindingType.GetGenericArguments();
            var methodAttr = MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual;

            if (bindingSettings.ArgumentsWeaver.IsFunction) {
                int length = arguments.Length - 1;

                returnType = arguments.Last();
                parametersTypes = new Type[length];
                Array.Copy(arguments, 0, parametersTypes, 0, length);
            }
            else {
                parametersTypes = arguments;
            }

            argumentsWeaver = new AspectArgumentsWeaver(bindingSettings.ArgumentsWeaver.ArgumentType, parametersTypes);
            parametersTypes[0] = parametersTypes[0].MakeByRefType();
            ilGenerator = typeBuilder.DefineMethod("Invoke", methodAttr, returnType, parametersTypes).GetILGenerator();

            if (bindingSettings.ArgumentsWeaver.IsFunction) {
                returnTypeBuilder = ilGenerator.DeclareLocal(returnType);
            }

            argumentsWeaver.Weave(ilGenerator);

            return ilGenerator;
        }

        protected abstract void WeaveInvokeMethod();
    }
}
