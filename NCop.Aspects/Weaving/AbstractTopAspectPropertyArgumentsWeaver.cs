using System;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractTopAspectPropertyArgumentsWeaver : AbstractArgumentsWeaver<PropertyInfo>, IAspectArgumentsWeaver
    {
        internal AbstractTopAspectPropertyArgumentsWeaver(PropertyInfo property, IArgumentsWeavingSettings argumentWeavingSettings, IAspectWeavingSettings aspectWeavingSettings)
            : base(property, argumentWeavingSettings, aspectWeavingSettings) {
        }

        public override void Weave(ILGenerator ilGenerator) {
            var localBuilder = BuildArguments(ilGenerator, Parameters);

            LocalBuilderRepository.Add(localBuilder);
        }

        public abstract LocalBuilder BuildArguments(ILGenerator ilGenerator, Type[] parameters);
	}
}