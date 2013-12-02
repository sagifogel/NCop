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
        private readonly Type bindingType = null; 
        private readonly IMethodScopeWeaver methodScopeWeaver = null;

        internal OnMethodInvokeBindingWeaver(Type bindingType, IMethodScopeWeaver methodScopeWeaver) {
            this.bindingType = bindingType;
            this.methodScopeWeaver = methodScopeWeaver;
        }

        public MemberInfo Weave() {
            Type bindingMethodType = null;
            MemberInfo weavedMember = null;
            var fieldBuilders = new List<FieldBuilder>();
            var attrs = TypeAttributes.NotPublic | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit;
            var typeBuilder = bindingType.DefineType("MethodBinding_{0}".Fmt(bindingCounter).ToUniqueName(), attributes: attrs);
            var fieldAttrs = FieldAttributes.FamANDAssem | FieldAttributes.Static;
            var ctorAttrs = MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName;
            var cctor = typeBuilder.DefineConstructor(ctorAttrs | MethodAttributes.Static | MethodAttributes.PrivateScope, CallingConventions.Standard, Type.EmptyTypes).GetILGenerator();
            var defaultCtor = typeBuilder.DefineConstructor(ctorAttrs, CallingConventions.Standard, Type.EmptyTypes).GetILGenerator();
            var bindingTypeCtor = bindingType.GetConstructor(Type.EmptyTypes);
            var fieldBuilder = typeBuilder.DefineField("singleton", typeBuilder, fieldAttrs);

            defaultCtor.EmitLoadArg(0);
            defaultCtor.Emit(OpCodes.Call, bindingTypeCtor);
            defaultCtor.Emit(OpCodes.Ret);

            cctor.Emit(OpCodes.Newobj, typeBuilder);
            cctor.Emit(OpCodes.Stsfld, fieldBuilder);
            cctor.Emit(OpCodes.Ret);

            bindingMethodType = typeBuilder.CreateType();
            weavedMember = bindingMethodType.GetField(fieldBuilder.Name, BindingFlags.NonPublic | BindingFlags.Static);
            Interlocked.Increment(ref bindingCounter);

            return weavedMember;
        }
    }
}
