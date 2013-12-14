using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractAdviceWeaver : IMethodScopeWeaver
    {
        protected readonly Type aspectType = null;
        protected readonly IArgumentsWeaver argumentsWeaver = null;
        protected readonly IAspectRepository aspectRepository = null;

        public AbstractAdviceWeaver(IAdviceWeavingSettings adviceWeavingSettings) {
            aspectType = adviceWeavingSettings.AspectType;
            argumentsWeaver = adviceWeavingSettings.ArgumentsWeaver;
            aspectRepository = adviceWeavingSettings.AspectRepository;
        }

        public abstract ILGenerator Weave(ILGenerator ilGenerator);
    }
}
