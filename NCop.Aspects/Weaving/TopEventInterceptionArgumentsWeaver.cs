using System;
using System.Linq;
using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using System.Reflection;
using System.Reflection.Emit;
using NCop.Core.Extensions;
using NCop.Weaving.Extensions;

namespace NCop.Aspects.Weaving
{
    internal class TopEventInterceptionArgumentsWeaver : AbstractEventAspectArgumentsWeaver
    {
        internal TopEventInterceptionArgumentsWeaver(IEventAspectDefinition aspectDefinition, IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings, BindingSettings bindingSettings)
            : base(aspectDefinition, argumentWeavingSettings, aspectWeavingSettings, bindingSettings) {
        }

        public override LocalBuilder BuildArguments(ILGenerator ilGenerator) {
            var typeDefinition = (IAspectTypeDefinition)WeavingSettings.TypeDefinition;
            var aspectArgLocalBuilder = ilGenerator.DeclareLocal(ArgumentType);
            var eventLocalBuilder = ilGenerator.DeclareLocal(typeof(EventInfo));
            var contractFieldBuilder = typeDefinition.GetFieldBuilder(WeavingSettings.ContractType);
            var eventArgumentContract = Member.ToEventArgumentContract();
            var eventBrokerProperty = eventArgumentContract.GetProperty("EventBroker");
            var eventBrokerType = eventBrokerProperty.PropertyType;
            var handlerType = eventBrokerType.GetGenericArguments().First();
            var delegateLocalBuilder = ilGenerator.DeclareLocal(handlerType);
            var delegateCtor = handlerType.GetConstructor(new[] { typeof(object), typeof(IntPtr) });
            var eventBrokerFieldBuilder = typeDefinition.GetEventFieldBuilder(Member.Name, eventBrokerType);
            var eventBrokerFieldTypeDefinition = typeDefinition.GetEventBrokerFielTypeDefinition(Member);
            var ctorInterceptionArgs = ArgumentType.GetConstructors().Single(ctor => ctor.GetParameters().Length != 0);
            var nullableArgs = handlerType.GetInvokeMethod().GetParameters();

            ilGenerator.EmitLoadArg(1);
            ilGenerator.Emit(OpCodes.Ldftn, eventBrokerFieldTypeDefinition.EventType.GetInvokeMethod());
            ilGenerator.Emit(OpCodes.Newobj, delegateCtor);
            ilGenerator.EmitStoreLocal(delegateLocalBuilder);
            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);
            ilGenerator.Emit(OpCodes.Callvirt, typeof(object).GetMethod("GetType"));
            ilGenerator.Emit(OpCodes.Ldstr, Member.Name);
            ilGenerator.Emit(OpCodes.Callvirt, typeof(Type).GetMethod("GetEvent", new[] { typeof(string) }));
            ilGenerator.EmitStoreLocal(eventLocalBuilder);
            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, contractFieldBuilder);
            ilGenerator.EmitLoadLocal(eventLocalBuilder);
            ilGenerator.EmitLoadLocal(delegateLocalBuilder);
            ilGenerator.Emit(OpCodes.Ldsfld, BindingsDependency);
            ilGenerator.EmitLoadArg(0);
            ilGenerator.Emit(OpCodes.Ldfld, eventBrokerFieldBuilder);
            nullableArgs.ForEach(arg => ilGenerator.Emit(OpCodes.Ldnull));
            ilGenerator.Emit(OpCodes.Newobj, ctorInterceptionArgs);
            ilGenerator.EmitStoreLocal(aspectArgLocalBuilder);

            return aspectArgLocalBuilder;
        }
    }
}