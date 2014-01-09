using NCop.Aspects.Weaving.Expressions;
using NCop.Weaving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using NCop.Aspects.Extensions;
using NCop.Aspects.Aspects;

namespace NCop.Aspects.Weaving
{
    internal class BindingAspectDecoratorWeaver : AbstractMethodScopeWeaver, IAspectWeaver, IBindingTypeReflector
    {
        private readonly IMethodBindingWeaver weaver = null;
        private readonly IArgumentsWeaver argumentsWeaver = null;
        private readonly NCop.Core.Lib.Lazy<FieldInfo> lazyWeavedType = null;

        internal BindingAspectDecoratorWeaver(IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings, IArgumentsWeavingSettings argumentWeavingSettings)
            : base(aspectWeavingSettings.WeavingSettings) {
            var bindingSettings = aspectDefinition.ToBindingSettings();

            lazyWeavedType = new Core.Lib.Lazy<FieldInfo>(WeaveType);
            bindingSettings.LocalBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;
            argumentsWeaver = new MethodDecoratorArgumentsWeaver(argumentWeavingSettings);
            weaver = new MethodDecoratorBindingWeaver(bindingSettings, aspectWeavingSettings, this);
        }

        public FieldInfo WeavedType {
            get {
                return lazyWeavedType.Value;
            }
        }

        public override ILGenerator Weave(ILGenerator ilGenerator) {
            argumentsWeaver.Weave(ilGenerator);
            ilGenerator.Emit(OpCodes.Callvirt, MethodInfoImpl);

            return ilGenerator;
        }

        protected FieldInfo WeaveType() {
            return weaver.Weave();
        }
    }
}
