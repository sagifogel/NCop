using NCop.Aspects.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using NCop.Core.Extensions;
using System.Reflection;
using NCop.Aspects.Extensions;
using NCop.Aspects.Weaving.Expressions;
namespace NCop.Aspects.Weaving
{
    internal abstract class AbstractMethodInterceptionAspectWeaverWithBinding : IAspectExpression, IBindingTypeReflector
    {
        protected IAspectDefinition aspectDefinition = null;
        protected IAspectWeavingSettings aspectWeavingSettings = null;

        internal AbstractMethodInterceptionAspectWeaverWithBinding(IAspectExpression expression, IAspectDefinition aspectDefinition, IAspectWeavingSettings aspectWeavingSettings) {
            BindingSettings bindingSettings = null;

            this.aspectDefinition = aspectDefinition;
            this.aspectWeavingSettings = aspectWeavingSettings;
            bindingSettings = aspectDefinition.ToBindingSettings();
            bindingSettings.LocalBuilderRepository = aspectWeavingSettings.LocalBuilderRepository;

            if (expression.Is<BindingAspectDecoratorExpression>()) {
                var methodDecoratorBindingWeaver = new MethodDecoratorBindingWeaver(bindingSettings, aspectWeavingSettings, expression.Reduce(aspectWeavingSettings));

                WeavedType = methodDecoratorBindingWeaver.Weave();
            }
            else {
                IAspectWeaver aspectWeaver = null;
                IMethodBindingWeaver bindingWeaver = null;
                IBindingTypeReflector typeReflector = null;
                var aspectType = aspectDefinition.Aspect.AspectType;
                var localBuilderRepository = new LocalBuilderRepository();

                var clonedSettings = aspectWeavingSettings.CloneWith(settings => {
                    settings.LocalBuilderRepository = localBuilderRepository;
                });

                aspectWeaver = expression.Reduce(clonedSettings);
                typeReflector = aspectWeaver as IBindingTypeReflector;
                bindingSettings.BindingDependency = typeReflector.WeavedType;
                bindingSettings.LocalBuilderRepository = localBuilderRepository;
                bindingWeaver = new OnMethodInterceptionBindingWeaver(aspectType, bindingSettings, aspectWeaver);
                WeavedType = bindingWeaver.Weave();
            }
        }

        public FieldInfo WeavedType { get; protected set; }

        public abstract IAspectWeaver Reduce(IAspectWeavingSettings aspectWeavingSettings);
    }
}
