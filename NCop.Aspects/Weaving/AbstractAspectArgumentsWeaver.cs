using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NCop.Aspects.Extensions;
using System.Reflection.Emit;
using System.Reflection;
using NCop.Weaving;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractAspectArgumentsWeaver : AbstractArgumentsWeaver, IAspectArgumentsWeaver
    {
        protected readonly Type aspectType = null;

        public AbstractAspectArgumentsWeaver(Type aspectType, Type argumentType, Type[] parameters, IAspectWeavingSettings aspectWeavingSettings, ILocalBuilderRepository localBuilderRepository)
            : base(argumentType, parameters, aspectWeavingSettings, localBuilderRepository) {
            this.aspectType = aspectType;
        }

        public override void Weave(ILGenerator ilGenerator) {
            var localBuilder = BuildArguments(ilGenerator, Parameters);

            LocalBuilderRepository.Add(localBuilder);
        }

        public abstract LocalBuilder BuildArguments(ILGenerator ilGenerator, Type[] parameters);
    }
}
