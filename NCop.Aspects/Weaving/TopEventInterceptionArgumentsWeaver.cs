using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Core.Extensions;
using NCop.Weaving.Extensions;
using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

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
            var parameters = handlerType.GetInvokeMethod().GetParameters();

            ilGenerator.EmitLoadArg(1);
            ilGenerator.Emit(OpCodes.Ldftn, eventBrokerFieldTypeDefinition.Event.EventHandlerType.GetInvokeMethod());
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

            parameters.ForEach(1, (arg, i) => {
                var property = ArgumentType.GetProperty("Arg{0}".Fmt(i));

                ilGenerator.EmitLoadArg(1);
                ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
            });

            ilGenerator.Emit(OpCodes.Newobj, ctorInterceptionArgs);
            ilGenerator.EmitStoreLocal(aspectArgLocalBuilder);

            return aspectArgLocalBuilder;
        }
    }
}