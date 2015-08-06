using System.Linq;
using System.Reflection;
using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Core.Extensions;
using NCop.Weaving.Extensions;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingEventInterceptionArgumentsWeaver : AbstractEventAspectArgumentsWeaver
    {
        internal BindingEventInterceptionArgumentsWeaver(IEventAspectDefinition aspectDefinition, IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings, BindingSettings bindingSettings)
            : base(aspectDefinition, argumentWeavingSettings, aspectWeavingSettings, bindingSettings) {
        }

        public override LocalBuilder BuildArguments(ILGenerator ilGenerator) {
            var aspectArgLocalBuilder = ilGenerator.DeclareLocal(ArgumentType);
            var eventArgumentContract = Member.ToEventArgumentContract();
            var ctorInterceptionArgs = ArgumentType.GetConstructors().Single(ctor => ctor.GetParameters().Length != 0);
            var eventBrokerProperty = eventArgumentContract.GetProperty("EventBroker");
            var eventBrokerType = eventBrokerProperty.PropertyType;
            var handlerType = eventBrokerType.GetGenericArguments().First();
            var parameters = handlerType.GetInvokeMethod().GetParameters();

            ilGenerator.EmitLoadArg(1);
            ilGenerator.Emit(OpCodes.Ldind_Ref);
            ilGenerator.EmitLoadArg(3);
            ilGenerator.Emit(OpCodes.Callvirt, eventArgumentContract.GetProperty("Event").GetGetMethod());
            ilGenerator.EmitLoadArg(3);
            ilGenerator.Emit(OpCodes.Callvirt, eventArgumentContract.GetProperty("Handler").GetGetMethod());
            ilGenerator.Emit(OpCodes.Ldsfld, BindingsDependency);
            ilGenerator.EmitLoadArg(3);
            ilGenerator.Emit(OpCodes.Callvirt, eventBrokerProperty.GetGetMethod());

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