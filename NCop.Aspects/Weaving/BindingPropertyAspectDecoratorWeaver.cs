using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Weaving;
using System.Reflection;
using System.Reflection.Emit;

namespace NCop.Aspects.Weaving
{
    internal class BindingPropertyAspectDecoratorWeaver : AbstractMethodScopeWeaver, IAspectWeaver, IBindingTypeReflector
    {
        private readonly IMethodBindingWeaver weaver = null;
        private readonly Core.Lib.Lazy<FieldInfo> lazyWeavedType = null;
        private readonly IMethodScopeWeaver methodDecoratorScopeWeaver = null;

        internal BindingPropertyAspectDecoratorWeaver(IAspectDefinition aspectDefinition, IAspectMethodWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentsWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings) {
            var bindingSettings = aspectDefinition.ToBindingSettings();

            lazyWeavedType = new Core.Lib.Lazy<FieldInfo>(WeaveType);
            bindingSettings.LocalBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            methodDecoratorScopeWeaver = new MethodDecoratorScopeWeaver(aspectWeavingSettings);
            weaver = new PropertyDecorationBindingWeaver(bindingSettings, aspectWeavingSettings, this);
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
