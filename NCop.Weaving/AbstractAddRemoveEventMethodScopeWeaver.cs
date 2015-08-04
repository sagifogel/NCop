using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using NCop.Core.Extensions;
using NCop.Weaving.Extensions;

namespace NCop.Weaving
{
    public abstract class AbstractAddRemoveEventMethodScopeWeaver : AbstractMethodScopeWeaver
    {
        private readonly Type delegateType = null;

        protected AbstractAddRemoveEventMethodScopeWeaver(EventInfo @event, MethodInfo method, IWeavingSettings weavingSettings)
            : base(method, weavingSettings) {
            delegateType = @event.ToDelegateType();
        }

        public abstract string Action { get; }

        public override void Weave(ILGenerator ilGenerator) {
            var label = ilGenerator.DefineLabel();
            var local0 = ilGenerator.DeclareLocal(delegateType);
            var local1 = ilGenerator.DeclareLocal(delegateType);
            var local2 = ilGenerator.DeclareLocal(delegateType);
            var contractFieldBuilder = weavingSettings.TypeDefinition.GetFieldBuilder(weavingSettings.ContractType);
            var compareExchangeMethod = typeof(Interlocked).GetMethods()
                                                           .Where(method => method.Name.Equals("CompareExchange"))
                                                           .Single(method => {
                                                               var @params = method.GetParameters().Select(p => p.ParameterType);

                                                               return @params.All(p => {
                                                                   if (p.HasElementType) {
                                                                       p = p.GetElementType();
                                                                   }

                                                                   return p.IsGenericParameter;
                                                               });
                                                           });

            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);
            ilGenerator.EmitStoreLocal(local0);
            ilGenerator.MarkLabel(label);
            ilGenerator.EmitLoadLocal(local0);
            ilGenerator.EmitStoreLocal(local1);
            ilGenerator.EmitLoadLocal(local1);
            ilGenerator.EmitLoadArg(1);
            ilGenerator.Emit(OpCodes.Call, typeof(Delegate).GetMethod(Action, new[] { typeof(Delegate), typeof(Delegate) }));
            ilGenerator.Emit(OpCodes.Castclass, delegateType);
            ilGenerator.EmitStoreLocal(local2);
            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldflda, contractFieldBuilder);
            ilGenerator.EmitLoadLocal(local2);
            ilGenerator.EmitLoadLocal(local1);
            ilGenerator.Emit(OpCodes.Call, compareExchangeMethod.MakeGenericMethod(new[] { delegateType }));
            ilGenerator.EmitStoreLocal(local0);
            ilGenerator.EmitLoadLocal(local0);
            ilGenerator.EmitLoadLocal(local1);
            ilGenerator.Emit(OpCodes.Bne_Un_S, label);
        }
    }
}
