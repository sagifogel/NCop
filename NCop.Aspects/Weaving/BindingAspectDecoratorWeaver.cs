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
        private readonly IArgumentsWeaver argumentsWeaver = null;
        private readonly NCop.Core.Lib.Lazy<FieldInfo> lazyWeavedType = null;
        private readonly MethodDecoratorByRefArgumentsStoreWeaver byRefArgumentsStoreWeaver = null;

        internal BindingAspectDecoratorWeaver(IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings) {
            var bindingSettings = aspectDefinition.ToBindingSettings();
            var methodInfoImpl = aspectWeavingSettings.WeavingSettings.MethodInfoImpl;
            var localBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            var aspectArgumentContract = methodInfoImpl.ToAspectArgumentContract();
            MethodDecoratorByRefArgumentsStoreWeaver methodDecoratorByRefArgumentsStoreWeaver = null;

            lazyWeavedType = new Core.Lib.Lazy<FieldInfo>(WeaveType);
            bindingSettings.LocalBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            methodDecoratorByRefArgumentsStoreWeaver = new MethodDecoratorByRefArgumentsStoreWeaver(aspectArgumentContract, methodInfoImpl, localBuilderRepository);
            argumentsWeaver = new MethodDecoratorArgumentsWeaver(methodInfoImpl, argumentWeavingSettings, methodDecoratorByRefArgumentsStoreWeaver);
            this.byRefArgumentsStoreWeaver = methodDecoratorByRefArgumentsStoreWeaver;
            weaver = new MethodDecoratorBindingWeaver(bindingSettings, aspectWeavingSettings, this);
        }

        public FieldInfo WeavedType {
            get {
                return lazyWeavedType.Value;
            }
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            byRefArgumentsStoreWeaver.StoreArgsIfNeeded(ilGenerator);
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, MethodInfoImpl);
            byRefArgumentsStoreWeaver.RestoreArgsIfNeeded(ilGenerator);
            
            return ilGenerator;
        }

        protected FieldInfo WeaveType() {
            return weaver.Weave();
        }
    }
}
