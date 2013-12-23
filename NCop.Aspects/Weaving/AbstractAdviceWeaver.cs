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
        protected readonly IAspectRepository aspectRepository = null;
		protected readonly ILocalBuilderRepository localBuilderRepository = null;
        protected readonly IArgumentsWeavingSettings argumentsWeavingSettings = null;

        public AbstractAdviceWeaver(IAdviceWeavingSettings adviceWeavingSettings) {
            aspectType = adviceWeavingSettings.AspectType;
            aspectRepository = adviceWeavingSettings.AspectRepository;
			localBuilderRepository = adviceWeavingSettings.LocalBuilderRepository;
            argumentsWeavingSettings = adviceWeavingSettings.ArgumentsWeavingSettings;
		}

        public abstract ILGenerator Weave(ILGenerator ilGenerator);
    }
}
