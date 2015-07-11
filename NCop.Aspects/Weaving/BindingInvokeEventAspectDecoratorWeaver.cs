using NCop.Aspects.Extensions;
using NCop.Core.Extensions;
using NCop.Weaving;
using NCop.Weaving.Extensions;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingInvokeEventAspectDecoratorWeaver : AbstractMethodScopeWeaver, IAspectWeaver
    {
        private readonly EventInfo @event = null;

        internal BindingInvokeEventAspectDecoratorWeaver(EventInfo @event, IAspectWeavingSettings aspectWeavingSettings)
            : base(@event.GetInvokeMethod(), aspectWeavingSettings.WeavingSettings) {
            this.@event = @event;
        }

        public override void Weave(ILGenerator ilGenerator) {
            var aspectArgsType = @event.ToEventArgumentContract();
            var eventArgs = Method.GetParameters();

            ilGenerator.EmitLoadArg(2);

            eventArgs.ForEach(1, (@param, i) => {
                var property = aspectArgsType.GetProperty("Arg{0}".Fmt(i));

                ilGenerator.EmitLoadArg(3);
                ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());
            });

            ilGenerator.Emit(OpCodes.Callvirt, Method);
        }
    }
}
