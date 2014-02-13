using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Weaving;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingAspectDecoratorWeaver : AbstractMethodScopeWeaver, IAspectWeaver, IBindingTypeReflector
    {
        private readonly IMethodBindingWeaver weaver = null;
        private readonly NCop.Core.Lib.Lazy<FieldInfo> lazyWeavedType = null;
        private readonly IMethodScopeWeaver methodDecoratorScopeWeaver = null;

        internal BindingAspectDecoratorWeaver(IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentsWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings) {
            var bindingSettings = aspectDefinition.ToBindingSettings();
            var methodInfoImpl = aspectWeavingSettings.WeavingSettings.MethodInfoImpl;
            
            lazyWeavedType = new Core.Lib.Lazy<FieldInfo>(WeaveType);
            bindingSettings.LocalBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            methodDecoratorScopeWeaver = new MethodDecoratorScopeWeaver(aspectWeavingSettings);
            weaver = new MethodDecoratorBindingWeaver(bindingSettings, aspectWeavingSettings, this);
        }

        public FieldInfo WeavedType {
            get {
                return lazyWeavedType.Value;
            }
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            return methodDecoratorScopeWeaver.Weave(ilGenerator);
        }

        protected FieldInfo WeaveType() {
            return weaver.Weave();
        }
    }
}
