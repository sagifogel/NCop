using System;

namespace NCop.Aspects.Weaving
{
    internal class PropertyInterceptionBindingWeaver : AbstractPropertyBindingWeaver
    {
        private readonly ILocalBuilderRepository localBuilderRepository = null;

        internal PropertyInterceptionBindingWeaver(Type aspectType, BindingSettings bindingSettings, IAspectPropertyMethodWeavingSettings aspectWeavingSettings, IAspectWeaver methodScopeWeaver)
            : base(bindingSettings, aspectWeavingSettings, methodScopeWeaver) {
            localBuilderRepository = bindingSettings.LocalBuilderRepository;
        }
    }
}
