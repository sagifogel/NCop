using NCop.Aspects.Aspects;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
using System.Reflection;

namespace NCop.Aspects.Weaving
{
    internal class MethodInterceptionBindingWeaver : AbstractBindingAspectWeaver
    {
        protected readonly IAspectExpression aspectExpression = null;
        protected IAspectWeavingSettings aspectWeavingSettings = null;
        protected readonly NCop.Core.Lib.Lazy<FieldInfo> lazyWeavedType = null;

        internal MethodInterceptionBindingWeaver(IAspectExpression aspectExpression, IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings = null)
            : base(aspectDefinition) {
            this.aspectExpression = aspectExpression;
            this.aspectWeavingSettings = aspectWeavingSettings;
            lazyWeavedType = new Core.Lib.Lazy<FieldInfo>(WeaveType);
        }

        public override FieldInfo WeavedType {
            get {
                return lazyWeavedType.Value;
            }
        }

        protected virtual FieldInfo WeaveType() {
            IAspectWeaver aspectWeaver = null;
            IMethodBindingWeaver bindingWeaver = null;
            IBindingTypeReflector bindingTypeReflector = null;
            var aspectType = aspectDefinition.Aspect.AspectType;
            var aspectSettings = GetAspectsWeavingSettings();

            aspectWeaver = aspectExpression.Reduce(aspectSettings);
            bindingTypeReflector = aspectWeaver as IBindingTypeReflector;
            bindingSettings.BindingDependency = bindingTypeReflector.WeavedType;
            bindingSettings.LocalBuilderRepository = aspectSettings.LocalBuilderRepository;
            bindingWeaver = new OnMethodInterceptionBindingWeaver(aspectType, bindingSettings, aspectWeaver);

            return bindingWeaver.Weave();
        }

        protected virtual IAspectWeavingSettings GetAspectsWeavingSettings() {
            return aspectWeavingSettings.CloneWith(settings => {
                settings.LocalBuilderRepository = new LocalBuilderRepository();
            });
        }
    }
}
