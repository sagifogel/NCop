using System;

namespace NCop.Aspects.Weaving
{
	internal class MethodInterceptionBindingWeaver : AbstractMethodBindingWeaver
	{
		private readonly ILocalBuilderRepository localBuilderRepository = null;

		internal MethodInterceptionBindingWeaver(Type aspectType, BindingSettings bindingSettings, IAspectMethodWeavingSettings aspectWeavingSettings, IAspectWeaver methodScopeWeaver)
			: base(bindingSettings, aspectWeavingSettings, methodScopeWeaver) {
			localBuilderRepository = bindingSettings.LocalBuilderRepository;
		}
	}
}
